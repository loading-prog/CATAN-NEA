using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class CatanGameManager
    {
        public Gameboard Board;
        public Dice Dice;
        public List<Player> Players;
        public int CurrentPlayerIndex = 0;
        public CatanGameManager() 
        { 
        
            Board = new Gameboard();
            Dice = new Dice();
            Players = new List<Player>();
            Players.Add(new Player(1, "dave", 0 ,0, 0, DateTime.Now)); //, Color.Red));

            Players.Add(new Player(2, "bob", 0, 0, 0, DateTime.Now)); // , Color.Green));

            Players.Add(new Player(3, "alice", 0, 0, 0, DateTime.Now)); //, Color.Blue));

            Players[0].PlayerColour = Color.Red;
            Players[1].PlayerColour = Color.Blue;
            Players[2].PlayerColour = Color.Orange;
        }


        public void NextTurn()
        {
            CurrentPlayerIndex++;
            if (CurrentPlayerIndex >= Players.Count)
            {
                CurrentPlayerIndex = 0;
            }
        }


        public void BuildRoad(Player player, Edge edgeClicked)
        {

        }
    }
}
