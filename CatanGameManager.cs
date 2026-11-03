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
            Players.Add(new Player(1, "dave", 0, 0, 0, DateTime.Now)); //, Color.Red));

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

        public bool CanPlaceSettlement(BuildingPoint point)
        {
            //check for building already there
            if (point.Owner != null || point.BuildingType != "None")
            {
                return false;
            }

            //checl each edge connected to this building if true
            foreach (Edge edge in point.Edges)
            {
                BuildingPoint neighbour = null;

                if (edge.Point1 == point)
                {
                    neighbour = edge.Point2;
                }
                if (edge.Point2 == point)
                {
                    neighbour = edge.Point1;
                }
                if (neighbour != null)
                {
                    if (neighbour.Owner != null || neighbour.BuildingType != "None")
                    {
                        return false;
                    }
                }     
            }
            return true;
        }
        public bool PlaceSettlement(Player player, BuildingPoint point)
        { 
            if (CanPlaceSettlement(point) == false)
            {
                return false;
            }
            point.Owner = player;
            point.BuildingType = "Settlement";
            return true;
        } 
        
        public void CanPlaceRoad(Player player, Edge edgeClicked)
        {
           // a road cannot be placed on an occupied edge.
            if(edgeClicked.RoadOwner != null)
            {
                return false;
            }
            BuildingPoint[] endpoints = 
            {
                edgeClicked.Point1,
                edgeClicked.Point2
            };

            foreach(BuildingPoint point in endpoints)
            {
                if(point.Owner == player)
                {
                    return true;
                }
                if(point.Owner != null)
                {
                    continue;
                }
                foreach(Edge connectedEdge in point.Edges)
                {
                    if(connectedEdge.RoadOwner == player)
                    {
                        return true;
                    }
                }
             }
             return false;
        }

        public bool BuildRoad(Player player, Edge edgeClicked)
        {
            if(CanPlaceRoad(player,edgeClicked == false)
               {
                   return false;
               }
            edgeClicked.RoadOwner = player;
            return true;
        }
    }
}
