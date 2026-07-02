using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    internal class MasterPaint
    {
        public class Utils
        {

            Pen p = new Pen(Color.Black);

            public void DrawHex(Graphics g, Pen p, Brush brushBlack, int startX, int startY)
            {
                int rootx = startX;
                int rooty = startY;

                g.DrawLine(p, rootx, rooty, rootx + 61, rooty + 58);
                rootx += 61;
                rooty += 58;

                g.DrawLine(p, rootx, rooty, rootx + 61, rooty - 58);
                rootx += 61;
                rooty -= 58;

                g.DrawLine(p, rootx, rooty, rootx, rooty - 58);
                rooty -= 58;

                g.DrawLine(p, rootx, rooty, rootx - 61, rooty - 58);
                rootx -= 61;
                rooty -= 58;

                g.DrawLine(p, rootx, rooty, rootx - 61, rooty + 58);
                rootx -= 61;
                rooty += 58;

                g.DrawLine(p, rootx, rooty, rootx, rooty + 58);
                rooty += 58;

                rootx += 122;
            }
            //public Point CalculateCornerLocation(Point center, int cornerWanted)
            //{
            //    //number them from top left, working clockwise, 1-6
            //   //witch(cornerWanted)
            //    return null;
            //}


            public void FillHex(Graphics g, Brush brush, int startX, int startY)
            {
                // Define the 6 corners of the hex based on your DrawHex offsets
                Point[] points = new Point[]
                {
            new Point(startX, startY),
            new Point(startX + 61, startY + 58),
            new Point(startX + 122, startY),
            new Point(startX + 122, startY - 58),
            new Point(startX + 61, startY - 116),
            new Point(startX, startY - 58)
                };

                g.FillPolygon(brush, points);
            }
            public void DrawToken(Graphics g, int startX, int startY, string probability)
            {
                int rootx = startX;
                int rooty = startY;

                Brush brushBlack = new SolidBrush(Color.Black);
                Brush brushBlue = new SolidBrush(Color.LightBlue);
                Brush TokenRed = new SolidBrush(Color.MediumVioletRed);
                Font font = new Font("Arial", 18, FontStyle.Bold);

                // draw token circle
                g.FillEllipse(brushBlack, rootx + 38, rooty - 60, 47, 47);
                g.FillEllipse(brushBlue, rootx + 39, rooty - 59, 44, 44);

                // draw number


                // draw probability dots
                int dotCount = GetDotCount(probability);

                int dotStartX = rootx + 45;
                int dotY = rooty - 18;

                if (dotCount == 5)
                {
                    dotCount = 4;
                    for (int i = 0; i < dotCount; i++)
                    {
                        g.FillEllipse(TokenRed, (dotStartX - 8) + (i * 14), dotY + 5, 8, 8);
                    }
                    g.DrawString(probability, font, TokenRed, rootx + 51, rooty - 52);
                }
                else
                {
                    for (int i = 0; i < dotCount; i++)
                    {
                        if (dotCount == 1)
                        {
                            g.FillEllipse(brushBlack, (dotStartX + 12) + (i * 20), dotY + 5, 8, 8);
                        }
                        if (dotCount == 2)
                        {
                            g.FillEllipse(brushBlack, (dotStartX + 2) + (i * 18), dotY + 5, 8, 8);
                        }
                        if (dotCount == 3)
                        {
                            g.FillEllipse(brushBlack, (dotStartX - 6) + (i * 16), dotY + 5, 8, 8);
                        }
                        if (dotCount == 4)
                        {
                            g.FillEllipse(brushBlack, (dotStartX - 8) + (i * 14), dotY + 5, 8, 8);
                        }
                    }
                    if (probability == "12" || probability == "11" || probability == "10")
                    {
                        g.DrawString(probability, font, brushBlack, rootx + 43, rooty - 52);
                    }
                    else
                    {
                        g.DrawString(probability, font, brushBlack, rootx + 51, rooty - 52);
                    }
                }

            }
            private int GetDotCount(string number)
            {
                if (number == "2" || number == "12") return 1;
                if (number == "3" || number == "11") return 2;
                if (number == "4" || number == "10") return 3;
                if (number == "5" || number == "9") return 4;
                if (number == "6" || number == "8") return 5;
                else return 0;
            }


            public void DrawTradePort(Graphics g)
            {
                Brush brushship = new SolidBrush(Color.SaddleBrown);
                Brush brushMast = new SolidBrush(Color.RosyBrown);
                int startx = 100;
                int starty = 100;

                g.FillRectangle(brushMast, startx, starty, 5, -30);
                g.DrawRectangle(p, startx, starty, 5, -30);
                g.FillRectangle(brushship, startx - 50, starty, 40, 20);

            }
        }

        public class Menu
        {
            Pen p = new Pen(Color.Black);
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushwhite = new SolidBrush(Color.White);
            Brush brushsheep = new SolidBrush(Color.LightGreen);
            Brush brushbrick = new SolidBrush(Color.DarkRed);
            Brush brushtree = new SolidBrush(Color.DarkOliveGreen);
            Brush brushrock = new SolidBrush(Color.Gray);
            Brush brushwheat = new SolidBrush(Color.Yellow);
            Brush brushdesert = new SolidBrush(Color.LightYellow);
            public void DrawMenu(Graphics g)
            {
                int Startx = 10;
                int Starty = 10;
                Font Refont = new Font("Arial", 18, FontStyle.Bold);

                g.FillRectangle(brushBlack, Startx, Starty, 75, 75);
                g.FillRectangle(brushwhite, Startx + 5, Starty + 5, 65, 65);
                g.DrawString("Menu", Refont, brushBlack, Startx + 2, Starty + 22);

            }
            public void CoverUp(Graphics g)
            {
                int Startx = 88;
                int Starty = 10;

                g.FillRectangle(brushwhite, Startx, Starty, 150, 150);
            }
            public void DrawReferenceBox(Graphics g)
            {
                int Startx = 90;
                int Starty = 10;
                Font Refont = new Font("Arial", 17, FontStyle.Bold);

                g.FillRectangle(brushBlack, Startx, Starty, 75, 75);
                g.FillRectangle(brushwhite, Startx + 5, Starty + 5, 65, 65);
                g.DrawString("Tiles", Refont, brushBlack, Startx + 2, Starty + 22);
            }
            public void DrawIndexBox(Graphics g)
            {
                int Startx = 170;
                int Starty = 10;
                Font Refont = new Font("Arial", 17, FontStyle.Bold);

                g.FillRectangle(brushBlack, Startx, Starty, 75, 75);
                g.FillRectangle(brushwhite, Startx + 5, Starty + 5, 65, 65);
                g.DrawString("Index", Refont, brushBlack, Startx + 2, Starty + 22);
            }
            public void DrawReference(Graphics g)
            {
                int startX = 50;
                int startY = 10;
                int spacing = 80;
                Font Refont = new Font("Arial", 12, FontStyle.Bold);

                List<string> TileTypes = new List<string>
                 {
                    "sheep", "brick", "rock", "tree", "wheat", "desert"
                 };

                for (int i = 0; i < TileTypes.Count; i++)
                {
                    string type = TileTypes[i].ToString();
                    Brush BrushToUse = brushsheep;

                    if (type == "sheep")
                    {
                        BrushToUse = brushsheep;
                    }
                    if (type == "brick")
                    {
                        BrushToUse = brushbrick;
                    }
                    if (type == "tree")
                    {
                        BrushToUse = brushtree;
                    }
                    if (type == "rock")
                    {
                        BrushToUse = brushrock;
                    }
                    if (type == "wheat")
                    {
                        BrushToUse = brushwheat;
                    }
                    if (type == "desert")
                    {
                        BrushToUse = brushdesert;
                    }
                    int yposition = startY + (i * spacing);

                    g.FillEllipse(BrushToUse, startX, yposition, 60, 60);
                    g.DrawString(type, Refont, brushBlack, startX + 65, yposition + 20);
                }
            }
            public void Index_Paint(object sender, PaintEventArgs e)
            {
                Pen p = new Pen(Color.Black);
                Brush brushBlack = new SolidBrush(Color.Black);
                Brush brushBlue = new SolidBrush(Color.LightBlue);
                Brush brushsheep = new SolidBrush(Color.LightGreen);
                Brush brushbrick = new SolidBrush(Color.DarkRed);
                Brush brushtree = new SolidBrush(Color.DarkOliveGreen);
                Brush brushrock = new SolidBrush(Color.Gray);
                Brush brushwheat = new SolidBrush(Color.Yellow);
                Brush brushdesert = new SolidBrush(Color.LightYellow);

                Graphics g = e.Graphics;
                Font Refont = new Font("Arial", 12, FontStyle.Bold);

                g.DrawRectangle(p, 1450, 0, 400, 400);
                // g.DrawString(type, Refont, brushBlack, startX + 50, yposition + 10);
                int ychord = 0;
                int xchord = 0;

                g.DrawString("Road", Refont, brushrock, 1500, 50);

                g.DrawString("settlement", Refont, brushrock, 1500, 90);

                g.DrawString("City", Refont, brushrock, 1500, 130);

                g.DrawString("Development Card", Refont, brushrock, 1500, 170);


            }
        }
        public class settlement
        {
            public void DrawSettlemnt(object sender, PaintEventArgs e)
            {
                Pen p = new Pen(Color.Black);
                Brush brushBlack = new SolidBrush(Color.Black);
                Brush brushBlue = new SolidBrush(Color.LightBlue);
                Brush brushsheep = new SolidBrush(Color.LightGreen);
                Brush brushbrick = new SolidBrush(Color.DarkRed);
                Brush brushtree = new SolidBrush(Color.DarkOliveGreen);
                Brush brushrock = new SolidBrush(Color.Gray);
                Brush brushwheat = new SolidBrush(Color.Yellow);
                Brush brushdesert = new SolidBrush(Color.LightYellow);

                Graphics g = e.Graphics;

                int startx = 20;
                int starty = 50;

                // g.DrawRectangle(p,startx-3,starty,16,20);
                g.FillRectangle(brushBlack, startx - 2, starty, 20, 12);
                g.FillRectangle(brushwheat, startx, starty, 16, 11);

                //g.FillPolygon(brushBlack, [startx + 16, starty + 12], [startx + 8, starty + 20], [startx,starty+12]);

            }
        }
    }
}
