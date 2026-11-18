using System;

namespace catan
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public Color PlayerColour { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public DateTime CreationDate { get; set; }

        // Player Resources
        public int Brick = 0;
        public int Wood = 0;
        public int Sheep = 0;
        public int Wheat = 0;
        public int Ore = 0;

      
        public Player(string username)
        {
            Username = username;
            TotalGamesPlayed = 0;
            TotalWins = 0;
            TotalLosses = 0;
            CreationDate = DateTime.Now;
        }
        public Player(int playerId, string username, int totalGames, int totalWins, int totalLosses, DateTime creationDate)
        {
            PlayerID = playerId;
            Username = username;
            TotalGamesPlayed = totalGames;
            TotalWins = totalWins;
            TotalLosses = totalLosses;
            CreationDate = creationDate;
        }
        public void AddResource(string resource, int amount)
        {
            if(resource == "Brick")
            {
                Brick += amount;
            }
            if(resource == "Ore")
            {
                Ore += amount;
            }
            if(resource == "Wheat")
            {
                Wheat += amount;
            }
            if(resource == "Sheep")
            {
                Sheep += amount;
            }
            if(resource == "Wood")
            {
                Wood += amount;
            }
        }
    }
}
