using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Policy;
using static System.Windows.Forms.AxHost;

namespace catan
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer updateTimer;
        public int hexesToDraw = 0;
        public int maxHexes = 0;
        public int CountSystem = 0;
        public bool MenuCheck = false;
        public bool Dicecheck = false;
        public bool checkrolling = false;
        Button MenuButton;

        MasterPaint.Utils utils;
        MasterPaint.Menu Menu;
        Theif Theif;
        

        CatanGameManager gameManager;
        private Edge? hoveredEdge = null;
        private BuildingPoint? hoveredPoint = null;
        public Form1(bool isLoading)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.Paint += form1_paint;
            this.MouseClick += Form1_Click;
            this.MouseMove += Form1_MouseMove;

            utils = new MasterPaint.Utils();
            Menu = new MasterPaint.Menu();

            //generating the Board
            gameManager = new CatanGameManager();
            gameManager.Board.DrawBoard();
            gameManager.Board.FindingNeighbour();
            gameManager.Board.FindingBuildingPoints();
            gameManager.Board.FindingEdges();
            int errors = gameManager.Board.CheckBoard();
            MessageBox.Show("Board Errors: " + errors);
            gameManager.Dice.roll();


            // Testing whether BuildingPoint And Edges can locate Neighbour and validate Placement
            
            // BuildingPoint testPoint = gameManager.Board.BuildingPoints[0];
            // Player testPlayer = gameManager.Players[0];

            // bool firstPlacement = gameManager.PlaceSettlement(testPlayer,testPoint);
            // BuildingPoint neighbour = null;

            // foreach(Edge edge in testPoint.Edges)
            // {
            //     if (edge.Point1 == testPoint)
            //     {
            //         neighbour = edge.Point2;
            //         break;
            //     }
            //     if (edge.Point2 == testPoint)
            //     {
            //         neighbour = edge.Point1;
            //         break;
            //     }
            // }

            // bool neighbourPlacement = false; 
            // if(neighbour != null)
            // {
            //     neighbourPlacement = gameManager.PlaceSettlement(testPlayer, neighbour);
            // }

            // MessageBox.Show("First Settlement Placed: " + firstPlacement + "\nFirst Point Owner correct: " + (testPoint.Owner == testPlayer) + "\nFirst Point Type: " + testPoint.BuildingType + "\nNeighbour Placement Allowed: " + neighbourPlacement);

            /*//testing if OccupiedPoints & OccupiedEdges work.
            int OccupiedPoints = 0;
            int OccupiedEdges = 0;

            BuildingPoint firstPoint = gameManager.Board.BuildingPoints[0];
            MessageBox.Show("Owner: " + (firstPoint.Owner == null ? "null" : "assigned") + "\nBuildingTypee: [" + (firstPoint.BuildingType ?? "null") + "]");

            foreach(BuildingPoint Point in gameManager.Board.BuildingPoints)
            {
                if(Point.Owner!= null || Point.BuildingType!= "None")
                {
                    OccupiedPoints++;
                    MessageBox.Show("Point " + Point.ID + "\nOwner: " + (Point.Owner == null ? "null" : "assaigned") + "\nBuildingType: [" + (Point.BuildingType ?? "null") + "]");
                }
            }
            foreach(Edge edge in gameManager.Board.Edges)
            {
                if(edge.RoadOwner != null)
                {
                    OccupiedEdges++;
                }
            }
            MessageBox.Show("Occupied Points: " + OccupiedPoints + "\n Occupied Edges: " + OccupiedEdges);*/

            /*Testing BuidlingPoints & if it finds all intersections
            MessageBox.Show("Building locations found: " + gameManager.Board.BuildingPoints.Count); = Success/ Expected Outcome */ 

            /*Testing if the Turn System works
            string TurnTest = "";
            for (int i = 0; i < 3; i++)
            {
                TurnTest += gameManager.Players[gameManager.CurrentPlayerIndex].Username + "\n";
                gameManager.NextTurn();
            }
            TurnTest += gameManager.Players[gameManager.CurrentPlayerIndex].Username;
            MessageBox.Show(TurnTest); = Success/Expected Outcome */

            /*Testing If Tile.FindNeighours actually works

            string results = "";
            foreach (Tile tile in gameManager.Board.Tiles)
            {
                results += tile.Id + ":" + tile.Neighbours.Count + "Neighbours\n";
            }
            MessageBox.Show(results);

            int errors = 0; 
            foreach(Tile tile in gameManager.Board.Tiles)
            {
                foreach( Tile neighbour in tile.Neighbours)
                {
                    if (!neighbour.Neighbours.Contains(tile))
                    {
                        errors++;
                    }
                    if (neighbour == tile)
                    {
                        errors++;
                    }
                }
            }
            MessageBox.Show("Neighbour errors" + errors); = Success / Expected Outcome*/


            maxHexes = gameManager.Board.Tiles.Count;
        }
        public void InitialiseButtons()
        {
            MenuButton = new Button();
            MenuButton.Location = new Point(10, 10);
            MenuButton.Size = new Size(75, 75);
            MenuButton.Text = "Menu";
            MenuButton.Click += MenuButton_Click;
            this.Controls.Add(MenuButton);
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            BuildingPoint? newHoveredPoint = null;
            Edge? newHoveredEdge = null;

            foreach(BuildingPoint point in gameManager.Board.BuildingPoints)
            {
                int dx = e.X-point.Position.X;
                int dy = e.Y-point.Position.Y;
                if(dx * dx + dy*dy <= 15 * 15)
                {
                    newHoveredPoint = point;
                    break;
                }
            }

            if(newHoveredPoint == null)
            {
                double closestDistance = 8;
                foreach(Edge edge in gameManager.Board.Edges)
                {
                    Point a = edge.Point1.Position;
                    Point b = edge.Point2.Position;

                    double dx = b.X - a.X;
                    double dy = b.Y - a.Y;

                    double lengthSquared = dx * dx + dy * dy;

                    if(lengthSquared == 0)
                    { 
                        continue;
                    }
                    double t = ((e.X-a.X) * dx + (e.Y - a.Y) * dy) / lengthSquared;
                    t = Math.Max(0, Math.Min(1,t));
                    double closestX = a.X + t * dx;
                    double closestY = a.Y + t * dy;
                    double distanceX = e.X - closestX;
                    double distanceY = e.Y - closestY;

                    double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                    if (distance <= closestDistance)
                    {
                        closestDistance = distance;
                        newHoveredEdge = edge;
                    }
                }
            }
            if(hoveredPoint != newHoveredPoint || hoveredEdge != newHoveredEdge)
            {
                hoveredPoint = newHoveredPoint;
                hoveredEdge = newHoveredEdge;

                this.Invalidate();
            }
        }
        
        
        private void Form1_Click(object? sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            int i = 0;
            while (i < gameManager.Board.BuildingPoints.Count)
            {
                BuildingPoint point = gameManager.Board.BuildingPoints[i];
                Point p = point.Position;
                int radius = 15;
                
                if(mouse.X >= p.X - radius && mouse.X <= p.X + radius && mouse.Y >= p.Y - radius && mouse.Y <= p.Y + radius)
                { 
                    Player currentPlayer = gameManager.Players[gameManager.CurrentPlayerIndex];
                    bool placed = false;
                    if(point.Owner == currentPlayer && point.BuildingType == "Settlement")
                    {
                        placed = gameManager.UpgradeCity(currentPlayer, point);
                    }
                    else if(point.Owner == null)
                    {
                        placed = gameManager.PlaceSettlement(currentPlayer, point);
                    }
                    if (placed == true)
                    {
                        this.Invalidate();
                    }
                    break;
                }
                i++;
            }


            bool clickedBuildingPoint = false;
            foreach(BuildingPoint point in gameManager.Board.BuildingPoints)
            {
                int dx = mouse.X - point.Position.X;
                int dy = mouse.Y - point.Position.Y;

                if(dx * dx + dy * dy <= 15 * 15)
                {
                    clickedBuildingPoint = true;
                    break;
                }
            }
            if(clickedBuildingPoint == false)
            { 
                Edge? closestEdge = null;
                double closestDistance = 8;
                foreach(Edge edge in gameManager.Board.Edges)
                {
                    Point a = edge.Point1.Position;
                    Point b = edge.Point2.Position;
                    
                    double dx = b.X - a.X;
                    double dy = b.Y - a.Y;

                    double lengthSquared = dx * dx + dy * dy;

                    if (lengthSquared == 0)
                    {
                        continue;
                    }

                    double t = ((mouse.X - a.X) * dx + (mouse.Y - a.Y) * dy) / lengthSquared;
                    t = Math.Max(0, Math.Min(1, t));

                    double closestX = a.X + t * dx;
                    double closestY = a.Y + t * dy;

                    double distanceX = mouse.X - closestX;
                    double distanceY = mouse.Y - closestY;

                    double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                    if (distance <= closestDistance)
                    {
                        closestDistance = distance;
                        closestEdge = edge;
                    }
                }

                if(closestEdge != null)
                {
                    Player currentPlayer = gameManager.Players[gameManager.CurrentPlayerIndex];
                    bool placed = gameManager.BuildRoad(currentPlayer, closestEdge);
                    if(placed == true)
                    {
                        this.Invalidate();
                    }
                }
            }
            //Menu click 
            if (mouse.X >= 10 && mouse.X <= 85 && mouse.Y >= 10 && mouse.Y <= 85)
            {
                CountSystem += 1;

                if (CountSystem == 1)
                {
                    MenuCheck = true;
                    this.Invalidate();

                }
                if (CountSystem == 2)
                {
                    MenuCheck = false;
                    this.Invalidate();
                    CountSystem = 0;
                }

            }

            //Dice click
            if (mouse.X >= 1800 && mouse.X <= 1900 && mouse.Y >= 800 && mouse.Y <= 900)
            {
                Dicecheck = true;
                if(gameManager.Dice == null)
                {
                    MessageBox.Show("ERROR : Dice object is NULL!");
                }
                else
                {
                    gameManager.Dice.roll();
                }
                    this.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 40;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (hexesToDraw < maxHexes)
            {
                hexesToDraw++;
                this.Invalidate();
            }
            else
            {
                updateTimer.Stop();
            }
        }
        // Change the form1_paint method signature to match PaintEventHandler
        private void form1_paint(object sender, PaintEventArgs e)
        {
            // Use the existing 'utils' field as the drawingUtils argument
            Graphics g = e.Graphics;
            //Background:
            Brush bushSea = new SolidBrush(Color.CadetBlue);
            Brush brushBoard = new SolidBrush(Color.BurlyWood);
            Brush brushWhite = new SolidBrush(Color.White);
            g.FillRectangle(brushWhite, 0, 0, 3000, 3000);
            g.FillRectangle(brushBoard, 400, 90, 1050, 730);
            g.FillRectangle(bushSea, 415, 105, 1020, 700);

            for (int i = 0; i < gameManager.Players.Count; i++)
            {
                int Panelx = 1500;
                int Panely = 100 + (i * 100);
                int panelWidth = 350;
                int PanelHight = 85;

                using Brush Parchment = new SolidBrush(Color.Bisque);
                using Brush PlayerBrush = new SolidBrush(gameManager.Players[i].PlayerColour);
                using Font PlayerFont = new Font("Georgia", 15, FontStyle.Bold);

                Color BorderColour = Color.SaddleBrown;
                int BorderWidth = 3;

                if (i == gameManager.CurrentPlayerIndex)
                {
                    BorderColour = Color.Goldenrod;
                    BorderWidth = 3;
                }
                
                using Pen Border = new Pen(BorderColour, BorderWidth);

                g.FillRectangle(Parchment, Panelx, Panely, panelWidth, PanelHight);
                g.DrawRectangle(Border, Panelx,Panely, panelWidth, PanelHight);

                g.FillRectangle(PlayerBrush, Panelx + 12, Panely + 12, 20, 60);

                g.DrawString(gameManager.Players[i].Username, PlayerFont, Brushes.SaddleBrown, Panelx + 45, Panely + 24);
            }


                if (gameManager.Board == null) return;

            for (int i = 0; i < hexesToDraw; i++)
            {
                gameManager.Board.Tiles[i].Paint(e,utils: utils);
            }

            foreach(Edge edge in gameManager.Board.Edges)
            {
                if(edge.RoadOwner != null)
                { 
                    using Pen roadPen = new Pen(edge.RoadOwner.PlayerColour, 7);
                    g.DrawLine( roadPen, edge.Point1.Position, edge.Point2.Position);
                }
            }
            if(hoveredEdge != null && hoveredPoint == null)
            {
                Player currentPlayer = gameManager.Players[gameManager.CurrentPlayerIndex];
                if(gameManager.CanPlaceRoad(currentPlayer, hoveredEdge) == true)
                {
                    Color playerColour = currentPlayer.PlayerColour;
                    Color ghostColour = Color.FromArgb(110,playerColour.R, playerColour.G, playerColour.B);
                    using Pen ghostPen = new Pen(ghostColour, 7);
                    g.DrawLine(ghostPen, hoveredEdge.Point1.Position, hoveredEdge.Point2.Position);
                }
            }

            
            foreach (BuildingPoint point in gameManager.Board.BuildingPoints)
            {
                if (point.Owner != null && point.BuildingType == "Settlement")
                {
                    int x = point.Position.X;
                    int y = point.Position.Y;
            
                    Color playerColour = point.Owner.PlayerColour;
            
                    using Brush settlementBrush = new SolidBrush(playerColour);
                    using Pen settlementBorder = new Pen(Color.Black, 2);
            
                    Point[] houseShape =
                    {
                        new Point(x - 9, y - 2),
                        new Point(x, y - 11),
                        new Point(x + 9, y - 2),
                        new Point(x + 9, y + 9),
                        new Point(x - 9, y + 9)
                    };
            
                    g.FillPolygon(settlementBrush, houseShape);
                    g.DrawPolygon(settlementBorder, houseShape);
                }
            }

            foreach(Buildingpoint in gameManager.Board.BuildingPoints)
            {
                if(Point.Owner != null && point.BuildingType == "City")
                {
                    int x = point.Position.X;
                    int y = point.Position.Y;

                    using Brush cityBrush = new SolidBrush(point.Owner.PlayerColour);
                    using Pen cityBorder = new Pen(Color.Black, 2);

                    g.FillRectagle(cityBrush, x-12, y-10, 24, 20);
                    g.drawRectangle(cityBorder, x-12, y-10, 24,20);

                    g.fillRectangle(cityBrush, x-6, y-17, 12, 7);
                    g.DrawRectangle(CityBorder, x-6, y-17, 12, 7);
                }
            }

            // Drawing Denied Placements across the map.

            foreach(BuildingPoint point in gameManager.Board.BuildingPoints)
            {
                if(point.Owner == null && point.BuildingType == "None")
                {
                    bool blocked = false;
                    foreach(Edge edge in point.Edges)
                    {
                        BuildingPoint neighbour = null;
                        if(edge.Point1 == point)
                        {
                            neighbour = edge.Point2;
                        }
                        if(edge.Point2 == point)
                        {
                            neighbour = edge.Point1;
                        }
                        if (neighbour != null)
                        {
                            if(neighbour.Owner != null && (neighbour.BuildingType == "Settlement" || neighbour.BuildingType == "City"))
                            {
                                blocked = true;
                                break;
                            }
                        }
                    }
                    if(blocked == true)
                    { 
                        int x = point.Position.X;
                        int y = point.Position.Y;
                        using Pen redPen = new Pen(Color.Red, 3);

                        g.DrawLine(redPen, x-7, y-7, x+7, y+7);
                        g.DrawLine(redPen, x+7, y-7, x-7, y+7);
                    }
                }
            }

            
            //Menu 
            
            if (MenuCheck == true)
            {
                Menu.DrawMenu(g);
                Menu.DrawReferenceBox(g);
                Menu.DrawIndexBox(g);
            }
                //Dice
            

            if (maxHexes == hexesToDraw)
            {
                gameManager.Dice.StartButton(sender, e);
                gameManager.Dice.DiceFace(sender, e);
                gameManager.Dice.ActualDiceResult(sender, e);
            }

            if (Dicecheck == true && MenuCheck == false)
            {
                checkrolling = true;
                gameManager.Dice.MidRoll(sender, e);
                //Dice.roll();
                gameManager.Dice.DiceFace(sender, e);
                for (int i = 0; i < 3; i++)
                {
                    gameManager.Dice.ActualDiceResult(sender, e);
                }
                Dicecheck = false;
                checkrolling = false;
                gameManager.Dice.StartButton(sender, e);
            }
        }
    }
}
