using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class Dice
    {
        public int value;
        Random rand = new Random();
        public int Dice1Value;
        public int Dice2value;
        public int total;
        public int rootx = 1600;
        public int rooty = 600;
        public void roll()
        {
            Dice1Value = rand.Next(1, 7);
            Dice2value = rand.Next(1, 7);
            total = Dice1Value + Dice2value;
        }
        public void StartEndButton()
        {

        }
        public void DiceFace(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen p = new Pen(Color.Black);
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);


            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    g.FillRectangle(brushBlack, rootx, rooty, 150, 150);
                    g.FillRectangle(brushWhite, rootx + 5, rooty + 5, 140, 140);
                }
                if (i == 1)
                {
                    g.FillRectangle(brushBlack, rootx + 140, rooty, 150, 150);
                    g.FillRectangle(brushWhite, rootx + 145, rooty + 5, 140, 140);
                }
            }
        }
        public void ActualDiceResult(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen p = new Pen(Color.Black);
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);

            Font font = new Font("Arial", 12, FontStyle.Bold);


            g.FillRectangle(brushWhite, rootx - 60, rooty, 40, 40);
            Dice1Value = rand.Next(1, 7);
            Dice2value = rand.Next(1, 7);
            g.DrawString(Dice1Value.ToString(), font, brushBlack, rootx - 50, rooty);
            g.DrawString(Dice2value.ToString(), font, brushBlack, rootx - 50, rooty + 20);


            g.FillRectangle(brushBlack, rootx, rooty, 150, 150);
            g.FillRectangle(brushWhite, rootx + 5, rooty + 5, 140, 140);
            g.FillRectangle(brushBlack, rootx + 140, rooty, 150, 150);
            g.FillRectangle(brushWhite, rootx + 145, rooty + 5, 140, 140);

            if (Dice1Value == 1 || Dice1Value == 3 || Dice1Value == 5)
            {
                g.FillEllipse(brushBlack, rootx + 60, rooty + 67, 21, 21);
            }

            if (Dice1Value == 3 || Dice1Value == 5)
            {
                g.FillEllipse(brushBlack, rootx + 25, rooty + 97, 21, 21);
                g.FillEllipse(brushBlack, rootx + 95, rooty + 37, 21, 21);
            }

            if (Dice1Value == 5)
            {
                g.FillEllipse(brushBlack, rootx + 25, rooty + 37, 21, 21);
                g.FillEllipse(brushBlack, rootx + 95, rooty + 97, 21, 21);
            }

            if (Dice2value == 1 || Dice2value == 3 || Dice2value == 5)
            {
                g.FillEllipse(brushBlack, rootx + 145 + 60, rooty + 67, 21, 21);
            }

            if (Dice2value == 3 || Dice2value == 5)
            {
                g.FillEllipse(brushBlack, rootx + +145 + 25, rooty + 97, 21, 21);
                g.FillEllipse(brushBlack, rootx + 145 + 95, rooty + 37, 21, 21);
            }

            if (Dice2value == 5)
            {
                g.FillEllipse(brushBlack, rootx + 145 + 25, rooty + 37, 21, 21);
                g.FillEllipse(brushBlack, rootx + 145 + 95, rooty + 97, 21, 21);
            }

            if (Dice1Value == 2 || Dice1Value == 4 || Dice1Value == 6)
            {
                g.FillEllipse(brushBlack, rootx + 25, rooty + 37, 21, 21);
                g.FillEllipse(brushBlack, rootx + 95, rooty + 97, 21, 21);
            }
            if (Dice1Value == 4 || Dice1Value == 6)
            {
                g.FillEllipse(brushBlack, rootx + 25, rooty + 97, 21, 21);
                g.FillEllipse(brushBlack, rootx + 95, rooty + 37, 21, 21);
            }
            if (Dice1Value == 6)
            {
                g.FillEllipse(brushBlack, rootx + 25, rooty + 67, 21, 21);
                g.FillEllipse(brushBlack, rootx + 95, rooty + 67, 21, 21);
            }

            if (Dice2value == 2 || Dice2value == 4 || Dice2value == 6)
            {
                g.FillEllipse(brushBlack, rootx + 145 + 25, rooty + 37, 21, 21);
                g.FillEllipse(brushBlack, rootx + 145 + 95, rooty + 97, 21, 21);
            }

            if (Dice2value == 4 || Dice2value == 6)
            {
                g.FillEllipse(brushBlack, rootx + +145 + 25, rooty + 97, 21, 21);
                g.FillEllipse(brushBlack, rootx + 145 + 95, rooty + 37, 21, 21);
            }

            if (Dice2value == 6)
            {
                g.FillEllipse(brushBlack, rootx + 145 + 25, rooty + 67, 21, 21);
                g.FillEllipse(brushBlack, rootx + 145 + 95, rooty + 67, 21, 21);
            }
        }

        public void StartButton(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);
            Font font = new Font("Arial", 18, FontStyle.Bold);
            g.FillRectangle(brushBlack, rootx + 200, rooty + 200, 100, 100);
            g.FillRectangle(brushWhite, rootx + 205, rooty + 205, 90, 90);
            g.DrawString("Start", font, brushBlack, rootx + 218, rooty + 238);
        }
        public void MidRoll(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black);
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushWhite = new SolidBrush(Color.White);
            Brush brushRolling = new SolidBrush(Color.LightCoral);
            Font font = new Font("Arial", 18, FontStyle.Bold);

            g.FillRectangle(brushWhite, rootx + 190, rooty + 190, 120, 120);

            g.FillEllipse(brushRolling, rootx + 60, rooty + 67, 21, 21);
            g.DrawString("Rolling", font, brushBlack, rootx + 205, rooty + 238);


        }

        public void DiceResult()
        {
            int result = Dice1Value += Dice2value;
            int count = 0;
            if (result == 0)
            {
                result = rand.Next(1, 12);
            }

            else
            {
                for (int i = 0; i < 18; i++)
                {
                    if (Gameboard.Probabilty[i] == result.ToString())
                    {
                        count += 1;
                    }

                }

            }
            for (int i = 0; i < count; i++)
            {
                MessageBox.Show("Clicked on tile {}");
            }
        }

    }
}
