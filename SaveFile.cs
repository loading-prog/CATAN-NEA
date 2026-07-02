using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static catan.PseudoWriting;

namespace catan
{
    internal class PseudoWriting
    {
        public class SaveData
        {
            public int Version { get; set; } = 1;
            public int dice1 { get; set; }
            public int dice2 { get; set; }
            public int CurrentTurn { get; set; }

            public SaveData(int version, int Dice1, int Dice2, int Currentturn)
            {
                Version = version;
                dice1 = Dice1;
                dice2 = Dice2;
                CurrentTurn = Currentturn;
            }
        }

        public class SaveTile
        {
            public int Id { get; set; }
            public string Type { get; set; } = "";
            public int CenterX { get; set; }
            public int CenterY { get; set; }
            public string Probability { get; set; } = "";

            public SaveTile(int id, string type, int centerX, int centerY, string probability) 
            {
                Id = id;
                Type = type;
                CenterX = centerX;
                CenterY = centerY;
                Probability = probability;
            }
        }
        public class Saveplayer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int VictoryPoint { get; set; }
            public int Resources { get; set; }

            public Saveplayer(int id, string name, int victorypoint, int resources)
            {
                Id = id;
                Name = name;
                VictoryPoint = victorypoint;
                Resources = resources;
            }
        }
        
    }
}
