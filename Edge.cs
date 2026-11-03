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
}
