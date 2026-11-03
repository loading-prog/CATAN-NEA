using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class Edge
    {
        public int ID { get; set; }
        public BuildingPoint Point1 { get; set; }
        public BuildingPoint Point2 { get; set; }
        public List<Tile> Tiles { get; set; }

        public Edge(int id, BuildingPoint p1, BuildingPoint p2)
        {
            ID = id;
            Point1 = p1;
            Point2 = p2;
            Tiles = new List<Tile>();
        }
    }


    class Tile //a node
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Point Center { get; set; }
        public string Probability { get; set; }
        public List<Tile> Neighbours { get; set; }
        public List<Edge> Edges { get; set; }
        public List<BuildingPoint> Corners { get; set; }

        public Tile(int id, string type, Point center, string probability)
        {
            Id = id;
            Type = type;
            Center = center;
            Neighbours = new List<Tile>();
            Edges = new List<Edge>();
            Corners = new List<BuildingPoint>();
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
                utils.DrawToken(g, Center.X, Center.Y, Probability);
            }

            if (Type == "brick")
            {
                utils.FillHex(g, brushbrick, Center.X, Center.Y);
                utils.DrawToken(g, Center.X, Center.Y, Probability);
            }

            if (Type == "rock")
            {
                utils.FillHex(g, brushrock, Center.X, Center.Y);
                utils.DrawToken(g, Center.X, Center.Y, Probability);
            }

            if (Type == "tree")
            {
                utils.FillHex(g, brushtree, Center.X, Center.Y);
                utils.DrawToken(g, Center.X, Center.Y, Probability);
            }

            if (Type == "wheat")
            {
                utils.FillHex(g, brushwheat, Center.X, Center.Y);
                utils.DrawToken(g, Center.X, Center.Y, Probability);
            }

            if (Type == "desert")
            {
                utils.FillHex(g, brushdesert, Center.X, Center.Y);
            }

            utils.DrawHex(g, p, brushBlack, Center.X, Center.Y);
        }
    }
}
