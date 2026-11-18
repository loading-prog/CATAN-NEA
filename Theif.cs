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
                resources.Add("Brick");
            }
            for(int i  = 0; i < victim.Wood; i++)
            {
                resources.Add("Wood");
            }
            for(int i  = 0; i < victim.Sheep; i++)
            {
                resources.Add("Sheep");
            }
            for(int i  = 0; i < victim.Wheat; i++)
            {
                resources.Add("Wheat");
            }
            for(int i  = 0; i < victim.Ore; i++)
            {
                resources.Add("Ore");
            }
            if(resources.Count == 0)
            {
                return "";
            }
            Random random = new Random();
            int index = random.Next(resources.Count);
            string stolenResource = resources[index];

            victim.AddResource(stolenResource, -1);
            Theif.AddResource(stolenResource, 1);

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
            if(resource == "Brick" && player.Brick > 0)
            {
                player.AddResource("Brick", -1);
                return true;
            }
            if(resource == "Wood" && player.Wood > 0)
            {
                player.AddResource("Wood", -1);
                return true;
            }
            if(resource == "Sheep" && player.Sheep > 0)
            {
                player.AddResource("Sheep", -1);
                return true;
            }
            if(resource == "Wheat" && player.Wheat > 0)
            {
                player.AddResource("Wheat", -1);
                return true;
            }
            if(resource == "Ore" && player.Ore > 0)
            {
                player.AddResource("Ore", -1);
                return true;
            }
            return false;
        }
    }
}
