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
        Dice Dice;
        MasterPaint.Menu Menu;
        Theif Theif;
        

        CatanGameManager gameManager;
        public Form1(bool isLoading)
        {
            Dice = new Dice();
            InitializeComponent();
            this.DoubleBuffered = true;

            this.Paint += form1_paint;
            this.Click += Form1_Click;
            utils = new MasterPaint.Utils();
           
            Menu = new MasterPaint.Menu();
            gameManager = new CatanGameManager();
            gameManager.Board.DrawBoard();
            

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

        private void Form1_Click(object? sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            int i = 0;
            while (i < gameManager.Board.UniquePoints.Count)
            {
                Point p = gameManager.Board.UniquePoints[i];
                int radius = 15;
                if (mouse.X >= p.X - radius && mouse.X <= p.X + radius && mouse.Y >= p.Y - radius && mouse.Y <= p.Y + radius)
                {
                    MessageBox.Show("Clicked on tile " + i);
                    break;
                }
                i++;


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
                    if(Dice == null)
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

            if (gameManager.Board == null) return;

            for (int i = 0; i < hexesToDraw; i++)
            {
                gameManager.Board.Tiles[i].Paint(e,utils: utils);
            }

            //Menu 

            if (MenuCheck == true)
            {
                if (MenuCheck == true)
                {
                    Menu.DrawMenu(g);
                    Menu.DrawReferenceBox(g);
                    Menu.DrawIndexBox(g);
                }
                if (MenuCheck == false)
                {
                    Menu.DrawMenu(g);
                    Menu.CoverUp(g);
                }
                //Dice
            }

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
                    Dice.ActualDiceResult(sender, e);
                }
                Dicecheck = false;
                checkrolling = false;
                gameManager.Dice.StartButton(sender, e);
            }
        }
    }
}
