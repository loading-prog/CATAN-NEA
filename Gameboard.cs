using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class Gameboard
    {
         
        //the actual tile
        


        //tiletype
        List<string> tileTypes = new List<string>
    {
        "sheep","sheep","sheep","sheep",
        "brick","brick","brick",
        "tree","tree","tree","tree",
        "rock","rock","rock",
        "wheat","wheat","wheat","wheat","wheat",
        "desert"
    };
        Random random = new Random();


        //Probabilty
        public static List<string> Probabilty = new List<string>
    {
        //19 total tiles, 18 with numbers, 1 desert
        "2",
        "3","3","3",
        "4","4",
        "5","5",
        "6","6","6",
        "8","8","8",
        "9","9",
        "10","10",
        "11","11","11",
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
        private void AdjustUniquePoints()
        {
            List<Point> adjustedPoints = new List<Point>();
            foreach (Point p in UniquePoints)
            {
                adjustedPoints.Add(AdjustPoint(p)); 
            }
            UniquePoints = adjustedPoints;
        }



        public List<Tile> Tiles { get; private set; } = new List<Tile>();
        
        
        
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



        public List<Point> UniquePoints = new List<Point>
    {
    new Point(885,489), new Point(946,546), new Point(1007,489),
    new Point(1007,432), new Point(946,375), new Point(885,432),

    new Point(765,489), new Point(826,546), new Point(887,489),
    new Point(887,432), new Point(826,375), new Point(765,432),

    new Point(827,603), new Point(888,660), new Point(949,603),
    new Point(949,546), new Point(888,489), new Point(827,546),

    new Point(947,603), new Point(1008,660), new Point(1069,603),
    new Point(1069,546), new Point(1008,489), new Point(947,546),

    new Point(1005,489), new Point(1066,546), new Point(1127,489),
    new Point(1127,432), new Point(1066,375), new Point(1005,432),

    new Point(945,375), new Point(1006,432), new Point(1067,375),
    new Point(1067,318), new Point(1006,261), new Point(945,318),

    new Point(825,375), new Point(886,432), new Point(947,318),
    new Point(886,261), new Point(825,318),

    new Point(705,375), new Point(766,432), new Point(827,318),
    new Point(766,261), new Point(705,318),

    new Point(645,489), new Point(706,546), new Point(767,489),
    new Point(767,432), new Point(706,375), new Point(645,432),

    new Point(705,603), new Point(766,660), new Point(705,546),

    new Point(765,717), new Point(826,774), new Point(887,717),
    new Point(887,660), new Point(765,660),

    new Point(885,717), new Point(946,774), new Point(1007,717),
    new Point(1007,660), new Point(885,660),

    new Point(1005,717), new Point(1066,774), new Point(1127,717),
    new Point(1127,660), new Point(1066,603), new Point(1005,660),

    new Point(1065,603), new Point(1126,660), new Point(1187,603),
    new Point(1187,546), new Point(1126,489), new Point(1065,546),

    new Point(1125,489), new Point(1186,546), new Point(1247,489),
    new Point(1247,432), new Point(1186,375), new Point(1125,432),

    new Point(1065,375), new Point(1126,432), new Point(1187,375),
    new Point(1187,318), new Point(1126,261), new Point(1065,318),

    new Point(1066,318), new Point(1127,261), new Point(1127,204),
    new Point(1066,147), new Point(1005,204),

    new Point(946,318), new Point(1007,261), new Point(1007,204),
    new Point(946,147), new Point(885,204),

    new Point(826,318), new Point(887,261), new Point(887,204),
    new Point(826,147), new Point(765,204)
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



        // Works "Logically" not Mathmatically. Looks for a tile which is - "Good enough" and then searches the offset to see if correct.
        public void FindingNeighbour()
        {
            int Vradius = 60;
            int Hradius = 65;


            var neighborOffsets = new (int dx, int dy)[]
            {
                (0, -Vradius),
                (0,  Vradius),
                (Hradius, 0),
                (-Hradius, 0),
                ( Hradius, -Vradius),
                ( Hradius,  Vradius),
                (-Hradius, -Vradius),
                (-Hradius,  Vradius)
            };


            foreach (Point center in CentreHex)
            {


                var neighborPoints = neighborOffsets.Select(o => new Point(center.X + o.dx, center.Y + o.dy)).ToList();


                var centerTile = Tiles.FirstOrDefault(t => ArePointsClose(t.Center, center, 8));
                if (centerTile == null) continue;


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
            return Math.Abs(a.X - b.X) <= tolerance && Math.Abs(a.Y - b.Y) <= tolerance;
        }



        public void DrawBoard()
        {
            Tiles.Clear();
            tileTypes = tileTypes.OrderBy(x => random.Next()).ToList();
            //Shuffle probabilty for later.
            Probabilty = Probabilty.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < 19; i++)
            {
                Point adjustedPosition = AdjustPoint(positions[i]);
                Tiles.Add(new Tile(i, tileTypes[i], adjustedPosition, Probabilty[i]));
            }

            AdjustUniquePoints();
        }
        //Console.WriteLine(Tiles);
        //Console.WriteLine(FindingNeighbour)

    }
}

