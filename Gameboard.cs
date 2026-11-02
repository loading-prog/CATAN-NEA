using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{

    class BuildingPoint
    {
        public int ID { get; set;}
        public Point Position { get; set;}
        public List <Tile> Tiles { get; set;}
        public List <Edge> Edges { get; set;}

        public BuildingPoint(int id, Point Position)
        {
            Id = id;
            Position = position
            Tiles = new List<Tile>();
            Edges = new List<Edge>();
        }
    }

    class Edge 
    { 
        public int ID { get; set;}
        public BuildingPoint Point1 { get; set;}
        public BuildingPoint Point2 { get; set;}
        public List<Tile> Tiles { get; set;}

        public Edge(int id, BuildingPoint p1, BuildingPoint p2)
        {
            Id = id;
            Point1 = p1;
            Point2 = p2;
            Tiles = new List<Tile>();
        }
    }

    class Tile //a node
    {
        public int Id { get; set;}
        public string Type { get; set;}
        public Point Center { get; set;}
        public string Probability { get; set;}
        public List<Tile> Neighbours { get; set;}
        public List <Edge> Edges { get; set;}
        public List <BuildingPoint> Corners { get; set}

        public Tile(int id, string type, Point center, string probability)
        {
            Id = id;
            Type = type;
            Center = center;
            Neighbours = new List <Tile>();
            Edges = new List<Edge>();
            Corners = new list<BuildingPoint>();
            Probability = probability;
            // Console.WriteLine("...");
        }
         public void Paint(PaintEventArgs e, MasterPaint.Utils utils) 
        { 
            Graphics g = e.Graphics; 
 
            Pen p = new Pen(Color.Black); 
            Brush brushBlack = new SolidBrush(Color.Black); 
            Brush brushBlue = new SolidBrush(Color.LightBlue); 
            Brush brushsheep = new SolidBrush(Color.LightGreen); 
            Brush brushbrick = new SolidBrush(Color.DarkRed); 
            Brush brushtree = new SolidBrush(Color.DarkOliveGreen); 
            Brush brushrock = new SolidBrush(Color.Gray); 
            Brush brushwheat = new SolidBrush(Color.Yellow); 
            Brush brushdesert = new SolidBrush(Color.LightYellow); 

            if (Type == "sheep") 
            { 
                utils.FillHex(g, brushsheep, Center.X, Center.Y); 
                utils.DrawToken(g, Center.X, Center.Y, Probabilty); 
            } 

            if (Type == "brick") 
            { 
                utils.FillHex(g, brushbrick, Center.X, Center.Y); 
                utils.DrawToken(g, Center.X, Center.Y, Probabilty); 
            } 

            if (Type == "rock") 
            { 
                utils.FillHex(g, brushrock, Center.X, Center.Y); 
                utils.DrawToken(g, Center.X, Center.Y, Probabilty); 
            } 

            if (Type == "tree") 
            { 
                utils.FillHex(g, brushtree, Center.X, Center.Y); 
                utils.DrawToken(g, Center.X, Center.Y, Probabilty);
            } 

            if (Type == "wheat") 
            { 
                utils.FillHex(g, brushwheat, Center.X, Center.Y); 
                utils.DrawToken(g, Center.X, Center.Y, Probabilty); 
            } 

            if (Type == "desert") 
            { 
                utils.FillHex(g, brushdesert, Center.X, Center.Y); 
            } 

            utils.DrawHex(g, p, brushBlack, Center.X, Center.Y); 
        } 
    } 
        
class Gameboard 
    { 
        public Gameboard() 
        { 
        } 
        //the actual tile 
        //tiletype 
        List<string> tileTypes = new List<string> 
        { 
            "sheep","sheep","sheep","sheep", 
            "brick","brick","brick", 
            "tree","tree","tree","tree", 
            "rock","rock","rock", 
            "wheat","wheat","wheat","wheat", 
            "desert" 
        }; 
 
        Random random = new Random();  //Probabilty 
       public static List<string> Probabilty = new List<string> 
       { 
            //19 total tiles, 18 with numbers, 1 desert 
            "2", 
            "3","3", 
            "4","4", 
            "5","5", 
            "6","6", 
            "8","8", 
            "9","9", 
            "10","10", 
            "11","11", 
            "12" 
        }; 

        private Point AdjustPoint(Point p) 
        { 
            int originY = 489; 
            int NewY = originY + ((p.Y - originY) / 57) * 58; 
            return new Point(p.X, NewY); 
            //For Some Reason implimenting same code just fucks the game. 
            //int originX = 885; 
            //int NewX = originX + ((p.X - originX) / 61) * 62; 
            //return new Point(NewX, NewY); 
        } 
    
        public List<Tile> Tiles { get; private set; } = new List<Tile>();
        public List<BuildingPoint> BuildingPoints = new List<BuildingPoint>(); 
        public List<Edge> Edges = new List<Edge>(); 
        //positions 
        List<Point> positions = new List<Point> 
        { 
            //Center position 
            new Point(885, 489), 
            new Point(765, 489), 
            new Point(827, 603), 
            new Point(947, 603), 
            new Point(1005, 489), 
            new Point(945, 375), 
            new Point(825, 375), 
            new Point(705, 375), 
            new Point(645, 489), 
            new Point(705, 603), 
            new Point(765, 717), 
            new Point(885, 717), 
            new Point(1005, 717), 
            new Point(1065, 603), 
            new Point(1125, 489), 
            new Point(1065, 375), 
            new Point(1005, 261), 
            new Point(885, 261), 
            new Point(765, 261) 
        }; 

 

        public List<Point> CentreHex = new List<Point> 
        { 
            new Point(946,460), 
            new Point(826,460), 
            new Point(888,574), 
            new Point(1008,574), 
            new Point(1066,460), 
            new Point(1006,346), 
            new Point(886,346), 
            new Point(766,346), 
            new Point(706,460), 
            new Point(766,574), 
            new Point(826,688), 
            new Point(964,688), 
            new Point(1066,688), 
            new Point(1126,574), 
            new Point(1186,460), 
            new Point(1126,346), 
            new Point(1066,232), 
            new Point(946,232), 
            new Point(826,232) 
        }; 

        public void FindingBuildingPoints() 
        { 
            BuildingPoints.Clear(); 
            Edges.Clear(); 
            foreach (Tile tile in Tiles) 
            { 
                tile.Corners.Clear(); 
                tile.Edges.Clear(); 
                Point[] Corners = 
                { 
                    new Point(tile.Center.X, tile.Center.Y), 
                    new Point(tile.Center.X + 61, tile.Center.Y + 58), 
                    new Point(tile.Center.X + 122, tile.Center.Y), 
                    new Point(tile.Center.X + 122, tile.Center.Y - 58), 
                    new Point(tile.Center.X + 61, tile.Center.Y - 116), 
                    new Point(tile.Center.X, tile.Center.Y - 58) 
                }; 
                foreach (Point Corner in Corners) 
                { 
                    BuildingPoint? FoundPoint = null; 
                    foreach (BuildingPoint existing in BuildingPoints) 
                    { 
                        if (ArePointsClose(existing.Position, Corner, 5)) 
                        { 
                            FoundPoint = existing; 
                            break; 
                        } 
                    } 
                    if (FoundPoint == null) 
                    { 
                        FoundPoint = new BuildingPoint(BuildingPoints.Count, Corner); 
                        BuildingPoints.Add(FoundPoint); 
                    } 
                    tile.Corners.Add(FoundPoint); 
                    if (FoundPoint.Tiles.Contains(tile) == false) 
                    { 
                        FoundPoint.Tiles.Add(tile); 
                    } 
                } 
            } 
        } 
        public void FindingEdges() 
        { 
            Edges.Clear(); 
            foreach (BuildingPoint point in BuildingPoints) 
            { 
                point.Edges.Clear(); 
            } 
            foreach (Tile tile in Tiles) 
            { 
                tile.Edges.Clear(); 
                for (int i = 0; i < tile.Corners.Count; i++) 
                { 
                    BuildingPoint Point1 = tile.Corners[i]; 
                    BuildingPoint Point2 = tile.Corners[(i + 1) % tile.Corners.Count]; 
                    Edge? ExistingEdge = null; 
                    foreach (Edge edge in Edges) 
                    { 
                        if ((edge.Point1 == Point1 && edge.Point2 == Point2) || 
                            (edge.Point1 == Point2 && edge.Point2 == Point1)) 
                        { 
                            ExistingEdge = edge; 
                            break; 
                        } 
                    } 
                    if (ExistingEdge == null) 
                    { 
                        ExistingEdge = new Edge(Edges.Count, Point1, Point2); 
                        Edges.Add(ExistingEdge); 
                        Point1.Edges.Add(ExistingEdge); 
                        Point2.Edges.Add(ExistingEdge); 
                    } 
                    if (ExistingEdge.Tiles.Contains(tile) == false) 
                    { 
                        ExistingEdge.Tiles.Add(tile); 
                    } 
                    tile.Edges.Add(ExistingEdge); 
                } 
            } 
        } 
        // Works "Logically" not Mathmatically. 
        // Looks for a tile which is "Good enough" 
        // and then searches the offset to see if correct. 
        public void FindingNeighbour() 
        { 
            int Vradius = 116; 
            int Hradius = 60; 
            var neighborOffsets = new (int dx, int dy)[] 
            { 
                (Hradius * 2, 0), 
                (-Hradius * 2, 0), 
                ( Hradius, -Vradius), 
                ( Hradius,  Vradius), 
                (-Hradius, -Vradius), 
                (-Hradius,  Vradius) 
            }; 
            foreach (Tile centerTile in Tiles) 
            { 
                Point center = centerTile.Center;
                var neighborPoints = neighborOffsets 
                    .Select(o => new Point(center.X + o.dx, center.Y + o.dy)) 
                    .ToList(); 

#pragma warning disable CS8619 
                centerTile.Neighbours = neighborPoints 
                    .Select(np => Tiles.FirstOrDefault(t => ArePointsClose(t.Center, np, 8))) 
                    .Where(t => t != null) 
                    .ToList(); 
#pragma warning restore CS8619 
            } 
        } 
        private static bool ArePointsClose(Point a, Point b, int tolerance) 
        { 
            return Math.Abs(a.X - b.X) <= tolerance && 
                   Math.Abs(a.Y - b.Y) <= tolerance; 
        } 
    
        public int CheckBoard() 
        { 
            int errors = 0; 
            int OutsideEdges = 0; 
            int InsideEdges = 0; 
            if (Tiles.Count != 19) errors++; 
            if (BuildingPoints.Count != 54) errors++; 
            if (Edges.Count != 72) errors++; 
            foreach (Tile tile in Tiles) 
            { 
                if (tile.Corners.Count != 6) errors++; 
                if (tile.Edges.Count != 6) errors++;
                foreach (BuildingPoint point in tile.Corners) 
                { 
                    if (point.Tiles.Contains(tile) == false) 
                    { 
                        errors++; 
                    } 
                } 
                foreach (Edge edge in tile.Edges) 
                { 
                    if (edge.Tiles.Contains(tile) == false) 
                    { 
                        errors++; 
                    } 
                } 
            } 
             foreach (BuildingPoint point in BuildingPoints) 
            { 
                if (point.Edges.Count != 2 && point.Edges.Count != 3) 
                { 
                    errors++; 
                } 
            } 
            foreach (Edge edge in Edges) 
            { 
                if (edge.Point1 == edge.Point2) 
                { 
                    errors++; 
                } 
                
                if (edge.Tiles.Count == 1) 
                { 
                    OutsideEdges++; 
                } 
                
                else if (edge.Tiles.Count == 2) 
                { 
                    InsideEdges++; 
                } 
                
                else 
                { 
                    errors++; 
                } 
                
                if (edge.Point1.Edges.Contains(edge) == false) 
                { 
                    errors++; 
                } 
                
                if (edge.Point2.Edges.Contains(edge) == false) 
                { 

                    errors++; 
                } 
            } 
            if (OutsideEdges != 30) errors++; 
            if (InsideEdges != 42) errors++; 
            for (int i = 0; i < Edges.Count; i++) 
            { 
                for (int j = i + 1; j < Edges.Count; j++) 
                { 
                    Edge edge1 = Edges[i]; 
                    Edge edge2 = Edges[j]; 
                    if ((edge1.Point1 == edge2.Point1 && edge1.Point2 == edge2.Point2) || 
                        (edge1.Point1 == edge2.Point2 && edge1.Point2 == edge2.Point1)) 
                    { 
                        errors++; 
                    } 
                } 
            } 
            return errors; 
        } 
        public void DrawBoard() 
        { 
            Tiles.Clear(); 
            BuildingPoints.Clear(); 
            Edges.Clear(); 
            tileTypes = tileTypes.OrderBy(x => random.Next()).ToList(); 
            //Shuffle probabilty for later. 
            Probabilty = Probabilty.OrderBy(x => random.Next()).ToList(); 
            int TokenIndex = 0;
            for (int i = 0; i < 19; i++) 
            { 
                Point adjustedPosition = AdjustPoint(positions[i]); 
                string probability = ""; 
                if (tileTypes[i] != "desert") 
                { 
                    probability = Probabilty[TokenIndex]; 
                    TokenIndex++; 
                } 
                Tiles.Add(new Tile(i, tileTypes[i], adjustedPosition, probability)); 
            } 
        } 
        //Console.WriteLine(Tiles); 
        //Console.WriteLine(FindingNeighbour) 
    } 

} 
