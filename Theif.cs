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
        public bool MoveTheif(Tile newTile)
        {
            if(newTile == null)
            {
                return false;
            }
            if(newTile == CurrentTile)
            {
                return false;
            }
            CurrentTile = newTile;
            return true;
        }
        public bool IsTileBlocked(Tile tile)
        {
            if(tile == CurrentTile)
            {
                return true;
            }
            return false;
        }
        public string StealResource(Player victim, Player Theif)
        {
            List<string> resources =new List<string>();
            for(int i  = 0; i < victim.Brick; i++)
            {
                Resource.Add("Brick");
            }
            for(int i  = 0; i < victim.Wood; i++)
            {
                Resource.Add("Wood");
            }
            for(int i  = 0; i < victim.Sheep; i++)
            {
                Resource.Add("Sheep");
            }
            for(int i  = 0; i < victim.Wheat; i++)
            {
                Resource.Add("Wheat");
            }
            for(int i  = 0; i < victim.Ore; i++)
            {
                Resource.Add("Ore");
            }
            if(resources.Count == 0)
            {
                return "";
            }
            Random random = new Random();
            int index = random.Next(Resources.Count);
            string stolenResource = resources[index];

            victim.AddResources(stolenResource, -1);
            Theif.AddResources(stolenResource, 1);

            return stolenResource;
        }
        public int GetDiscardedAmount(Player player)
        {
            int totalResources = player.Brick + player.Wood + player.Sheep + player.Wheat + player.Ore;
            if(totalResources > 7)
            {
                return totalResources / 2;
            }
            return 0;
        }
        public bool DiscardRescource(Player player, string resource)
        {
            if(resource == "brick" && player.Brick >0)
            {
                player.AddResource("Brick" -1);
                return true;
            }
            if(resource == "Wood" && player.Brick >0)
            {
                player.AddResource("Wood" -1);
                return true;
            }
            if(resource == "Sheep" && player.Brick >0)
            {
                player.AddResource("Sheep" -1);
                return true;
            }
            if(resource == "Wheat" && player.Brick >0)
            {
                player.AddResource("Wheat" -1);
                return true;
            }
            if(resource == "Ore" && player.Brick >0)
            {
                player.AddResource("Ore" -1);
                return true;
            }
            return false;
    }
}
