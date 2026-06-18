using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    internal class Theif
    {

        public Theif() 
        { 
           
        }
        public void TheifValidation()
        {
            bool TFV = false;

            if (TFV == true)
            {
                //TheifMove();
            }
        }
        // this will be imbeded in validation or reliant on validation being true.
        /*public void cursortilecalculator(Point center)
        {
            foreach (Point center in Gameboard.CentreHex)
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
                foreach (var offset in neighborOffsets)
                {
                    Point neighborCenter = new Point(center.X + offset.dx, center.Y + offset.dy);
                   
                    if (*//* cursor is within bounds of neighborCenter *//* false)
                    {

                        // Handle the case where the cursor is over a neighboring tile
                        break;
                    }
                }
            }
        }*/
        public void TheifMove(Graphics g, Pen p, Brush brushBlack)
        {
            
        }
            

    }
}
