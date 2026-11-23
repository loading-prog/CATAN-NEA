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
        public Theif Theif;
        public DevelopmentCardDeck DevelopmentDeck;
        public bool WaitingForTheif = false;
        public List<Player> Players;
        public int CurrentPlayerIndex = 0;
        public string GameMode = "Catan";
        public string GamePhase = "Setup";
        public int SetupPlacementNumber = 0;
        public bool WaitingForRoad = false;
        public BuildingPoint? LastPlacedSettlement = null;
        public bool HasRolledDice = false;
        public CatanGameManager()
        {

            Board = new Gameboard();
            Dice = new Dice();
            DevelopmentDeck = new DevelopmentCardDeck();
            Theif = new Theif(Board);
            Players = new List<Player>();
            Players.Add(new Player(1, "dave", 0, 0, 0, 0, DateTime.Now)); //, Color.Red));

            Players.Add(new Player(2, "bob", 0, 0, 0, 0, DateTime.Now)); // , Color.Green));

            Players.Add(new Player(3, "alice", 0, 0, 0, 0, DateTime.Now)); //, Color.Blue));

            Players[0].PlayerColour = Color.Red;
            Players[1].PlayerColour = Color.Blue;
            Players[2].PlayerColour = Color.Orange;
        }

        public void AdvanceSetupTurn()
        {
            SetupPlacementNumber++;
        
            if(SetupPlacementNumber >= 6)
            {
                GamePhase = "Normal";
                CurrentPlayerIndex = 0;
                return;
            }
        
            if(SetupPlacementNumber == 0 || SetupPlacementNumber == 5)
            {
                CurrentPlayerIndex = 0;
            }
        
            if(SetupPlacementNumber == 1 || SetupPlacementNumber == 4)
            {
                CurrentPlayerIndex = 1;
            }
        
            if(SetupPlacementNumber == 2 || SetupPlacementNumber == 3)
            {
                CurrentPlayerIndex = 2;
            }
        } 
        public void NextTurn()
        {
            if(GameMode == "Catan" && GamePhase == "Setup")
            {
                   return;
            }
            if(WaitingForTheif == true)
            {
                return;
            }
            if(GameMode == "Catan" && GamePhase == "Normal" &&  HasRolledDice == false)
            {
                return;
            }
            
            CurrentPlayerIndex++;
            HasRolledDice = false;
            
            if (CurrentPlayerIndex >= Players.Count)
            {
                CurrentPlayerIndex = 0;
            }
        }
        public void FinishTheif()
        {
            WaitingForTheif = false;
        }
        public void CheckTheif()
        {
            if(Dice.total == 7)
            {
                WaitingForTheif = true;
            }
        }
        public bool CanPlaceSetupSettlement(Player player, BuildingPoint point)
        { 
            if(GameMode != "Catan" || GamePhase != "Setup")
            {
                return false;
            }
            if(WaitingForRoad == true)
            {
                return false;
            }
            if(player != Players[CurrentPlayerIndex])
            {
                return false;
            }
            return CanPlaceSettlement(point);
        }
        public bool PlaceSetupSettlement(Player player, BuildingPoint point)
        {
            if(CanPlaceSetupSettlement(player,point) == false)
            {
                return false;
            }
            if(PlaceSettlement(player,point) == false)
            {
                return false;
            }
            LastPlacedSettlement = point;
            WaitingForRoad = true;

            return true;
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
            if(GamePhase == "Normal")
            {
                bool ConnectedRoad = false;
                foreach (Edge edge in point.Edges)
                {
                    if(edge.RoadOwner == player)
                    {
                        ConnectedRoad = true;
                    }
                }
                if (ConnectedRoad == false)
                {
                    return false;
                }
            
                if(player.Brick < 1 || player.Wood < 1 || player.Sheep < 1 || player.Wheat < 1)
                {
                    return false;
                }
            
                player.Brick -= 1;
                player.Wood -= 1;
                player.Sheep -= 1;
                player.Wheat -= 1;
            }
            point.Owner = player;
            point.BuildingType = "Settlement";
            player.TotalVictoryPoints += 1;
            return true;
        } 

        public bool CanPlaceSetupRoad(Player player,Edge edgeClicked)
        {
            if(GameMode != "Catan" || GamePhase != "Setup")
            {
                return false;
            }
            if(WaitingForRoad == false)
            {
                return false;
            }
            if(player != Players[CurrentPlayerIndex])
            {
                return false;
            }
            if(LastPlacedSettlement == null)
            {
                return false;
            }
            if(edgeClicked.RoadOwner != null)
            {
                return false;
            }
            if(edgeClicked.Point1 != LastPlacedSettlement && edgeClicked.Point2 != LastPlacedSettlement)
            {
                return false;
            }
            return true;
        }
                   
        public bool PlaceSetupRoad(Player player, Edge edgeClicked)
        {
            if(CanPlaceSetupRoad(player, edgeClicked) == false)
            {
                   return false;
            }
            edgeClicked.RoadOwner = player;
            WaitingForRoad = false;
            LastPlacedSettlement = null; 
            AdvanceSetupTurn();
            return true;
        }
        
        public bool CanPlaceRoad(Player player, Edge edgeClicked)
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
            if(CanPlaceRoad(player,edgeClicked) == false)
               {
                   return false;
               }
            if(player.Brick < 1 || player.Wood < 1)
            {
                return false;
            }
            player.Brick -= 1;
            player.Wood -= 1;
            edgeClicked.RoadOwner = player;
            return true;
        }
        public bool UpgradeCity(Player player, BuildingPoint point)
        {
            if(point.Owner != player)
            {
                return false;
            }
            if(point.BuildingType != "Settlement")
            {
                return false;
            }
            if(player.Ore < 3 || player.Wheat < 2)
            {
                return false;
            }
            player.Ore -= 3;
            player.Wheat -= 2;
            
            point.BuildingType = "City";
            player.TotalVictoryPoints += 1;
            return true;
        }

        public bool BuyDevelopmentCard(Player player)
        {
            if (GamePhase != "Normal")
            {
                return false;
            }
            if (HasRolledDice == false)
            {
                return false;
            }
            if (player != Players[CurrentPlayerIndex])
            {
                return false;
            }
            if (player.Ore < 1 || player.Sheep <1 || player.Wheat < 1)
            {
                return false;
            }
            if(DevelopmentDeck.Cards.Count == 0)
            {
                return false;
            }
            DevelopmentCard? card = DevelopmentDeck.DrawCard();

            if(card == null)
            {
                return false;
            }
            player.Ore -=1;
            player.Sheep -= 1;
            player.Wheat -= 1;

            player.DevelopmentCards.Add(card);
            return true;
        }
        public bool GameOver = false;
        public bool CheckWin(Player player)
        {
            if(player.TotalVictoryPoints >= 10 && GameOver == false)
            {
                GameOver = true;
                return true;
            }
            return false;
        }
    }
}
