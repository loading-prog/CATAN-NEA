using System;

namespace catan
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Username { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public DateTime CreationDate { get; set; }

      
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
    }
}