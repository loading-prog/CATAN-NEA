using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class BuildingPoint
    {
        public int ID { get; set; }
        public Point Position { get; set; }
        public List<Tile> Tiles { get; set; }
        public List<Edge> Edges { get; set; }
        public Player? Owner { get; set; }
        public string BuildingType { get; set; }
        public BuildingPoint(int id, Point Position)
        {
            ID = id;
            this.Position = Position;
            Tiles = new List<Tile>();
            Edges = new List<Edge>();
            Owner = null;
            BuildingType = "None";
        }
    }
}
