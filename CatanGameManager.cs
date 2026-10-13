using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    class CatanGameManager
    {
        public Gameboard Board;
        public Dice Dice;
        List<Player> Players;
        public CatanGameManager() { 
        
        Board = new Gameboard();
            Dice = new Dice();
            Players = new List<Player>();
            //Players.Add(new Player(1, "dave", Color.Red));

            //Players.Add(new Player(2, "bob", Color.Green));

            //Players.Add(new Player(3, "alice", Color.Blue));
        }


        public void RunTurn(Player player)
        {

        }


        public void BuildRoad(Player player, Edge edgeClicked)
        {

        }
    }
}
