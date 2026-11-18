using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catan
{
    internal class Theif
    {
        public Tile? CurrentTile;
        public Theif(Gameboard board)
        {
            foreach(Tile tile in board.Tiles)
            {
                if( tile.Type == "desert")
                {
                    CurrentTile = tile;
                    break;
                }
            }
        }
    }
}
