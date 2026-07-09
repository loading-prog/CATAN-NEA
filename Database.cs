using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace catan
{

    internal static class DataBaseHelper
    {
        static string connectingString = "Data Source=MemoryDb.db";

        public static void initializeDataBase()
        {
            Console.WriteLine("Hello 1234 ");
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = @"

                 CREATE TABLE IF NOT EXISTS Players (
                     PlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                     Username TEXT NOT NULL,
                     TotalGamesPlayed INT,
                     TotalWins INT,
                     TotalLosses INT,
                     CreationDate DATETIME DEFAULT CURRENT_TIMESTAMP
                 );


                CREATE TABLE IF NOT EXISTS Game (
                    GameID INTEGER PRIMARY KEY AUTOINCREMENT,
                    TimeStarted DATETIME DEFAULT CURRENT_TIMESTAMP,
                    TimeEnded DATETIME,
                    WinnerID INTEGER,
                    CurrentLeader INTEGER,
                    VARCHAR GameState,
                    FOREIGN KEY (CurrentLeader) REFERENCES Players(PlayerID),
                    FOREIGN KEY (WinnerID) REFERENCES Players(PlayerID)     
                 ); 
                    

                CREATE TABLE IF NOT EXISTS GamePlayer (
                    GamePlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    PlayerID INTEGER NOT NULL,
                    PlayerVP INT,
                    VARCHAR PlayerColor,
                    INT PlayerOrder,
                    INT WoodinHand,
                    INT BrickinHand,    
                    INT SheepinHand,
                    INT RockinHand, 
                    Int WheatinHand,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID),
                    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)


                 CREATE TABLE IF NOT EXISTS BoardTiles (
                     TileID INTEGER PRIMARY KEY AUTOINCREMENT,
                     GameID INTEGER NOT NULL,
                     VARCHAR ResoucreType,
                     TileProbability INT,
                     TileCenterX INT,
                     TileCenterY INT,
                     TilehasRobber BOOLEAN,
                     FOREIGN KEY (GameID) REFERENCES Game(GameID)   
                 );
                

                CREATE TABLE IF NOT EXISTS Buildings (
                    BuildingID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    PlayerID INTEGER NOT NULL,
                    VARCHAR BuildingType,
                    INT BuildingLocationX,
                    INT BuildingLocationY,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID),
                    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
                 );

                CREATE TABLE IF NOT EXISTS Roads (
                    RoadID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    PlayerID INTEGER NOT NULL,
                    INT RoadStartX,
                    INT RoadStartY,
                    INT RoadEndX,
                    INT RoadEndY,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID),
                    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
                 );

                CREATE TABLE IF NOT EXISTS DevelopmentCards (
                    CardID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    VARCHAR CardType,
                    BOOLEAN IsUsed,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID)
                 );
                
                CREATE TABLE IF NOT EXISTS Turns (
                    TurnID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    PlayerID INTEGER NOT NULL,
                    INT TurnNumber,
                    DATETIME TurnStartTime,
                    DATETIME TurnEndTime,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID),
                    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
                 );

                 CREATE TABLE IF NOT EXISTS Playerhand (
                     PlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                     PlayerCards TEXT NOT NULL,
                     PlayerCardsQuantity INT,
                     PlayerVP INT
                 );
                 CREATE TABLE IF NOT EXISTS Bank (
                     ResourceID INTEGER PRIMARY KEY AUTOINCREMENT,
                     ResourceType TEXT NOT NULL,
                     ResouceCount INTEGER,
                 );

             ";
                command.ExecuteNonQuery();

                command.CommandText = @"
                    -- Insert dummy players
                    INSERT INTO Players (Username, TotalGamesPlayed, TotalWins, TotalLosses)
                    VALUES ('Player1', 0, 0, 0),
                           ('Player2', 0, 0, 0),
                           ('Player3', 0, 0, 0),
                           ('Player4', 0, 0, 0);
                ";
                command.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }

        }

        //For every table, need insert methods and retreive methods 
        public static void InsertPlayer(Player player)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO Players (Username, TotalGamesPlayed, TotalWins, TotalLosses)
                                    VALUES ($username, $games, $wins, $losses);";
                cmd.Parameters.AddWithValue("$username", player.Username);
                cmd.Parameters.AddWithValue("$games", player.TotalGamesPlayed);
                cmd.Parameters.AddWithValue("$wins", player.TotalWins);
                cmd.Parameters.AddWithValue("$losses", player.TotalLosses);
                cmd.ExecuteNonQuery();
            }
        }




        public static DataTable GetPlayer()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT PlayerID, Username, TotalGamesPlayed, TotalWins, TotalLosses, CreationDate FROM Player;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddPlayer(string Username, int TotalGamesPlayed, int TotalWins, int TotalLosses, DateOnly CreationDate)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Player(Username, TotalGamesPlayed, TotalWins, TotalLosses, CreationDate)
                                        VALUES ($Username, $TotalGamesPlayed, $TotalWins, $TotalLosses, $CreationDate); ";
                command.Parameters.AddWithValue("$Username", Username);
                command.Parameters.AddWithValue("$TotalGamesPlayed", TotalGamesPlayed);
                command.Parameters.AddWithValue("$TotalWins", TotalWins);
                command.Parameters.AddWithValue("$TotalLosses", TotalLosses);
                command.Parameters.AddWithValue("$CreationDate", CreationDate);
                command.ExecuteNonQuery();
            }
        }
        public static DataTable GetGame()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GameID, TimeStarted, TimeEnded, WinnerID, CurrentLeader, GameState FROM Player;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public static void AddGame(string TileType, DateTime TimeStarted, DateTime TimeEnded, int WinnerID, int CurrentLeader, int GameState)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Game(TimeStarted, TimeEnded, WinnerID, CurrentLeader, GameState)
                                        VALUES ($TimeStarted, $TimeEnded, $WinnerID, $CurrentLeader, $GameState); ";
                command.Parameters.AddWithValue("$TimeStarted", TimeStarted);
                command.Parameters.AddWithValue("$TimeEnded", TimeEnded);
                command.Parameters.AddWithValue("$WinnerID", WinnerID);
                command.Parameters.AddWithValue("$CurrentLeader", CurrentLeader);
                command.Parameters.AddWithValue("$GameState", GameState);
                command.ExecuteNonQuery();
            }
        }



        /*public static DataTable GetGamePlayer()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GamePlayerID, GameID, PlayerID, PlayerVP, PlayerColor, PlayerOrder, WoodinHand, BrickinHand, SheepinHand, RockinHand, WheatinHand FROM GamePlayer;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }


        public static void AddGamePlayer(int GameID, int PlayerID, int PlayerVP, string PlayerColor, int PlayerOrder, int WoodinHand, int BrickinHand, int SheepinHand, int RockinHand, int WheatinHand)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO GamePlayer(GameID, PlayerID, PlayerVP, PlayerColor, PlayerOrder, WoodinHand, BrickinHand, SheepinHand, RockinHand, WheatinHand)
                                        VALUES ($GameID, $PlayerID, $PlayerVP, $PlayerColor, $PlayerOrder, $WoodinHand, $BrickinHand, $SheepinHand, $RockinHand, $WheatinHand); ";
                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$PlayerID", PlayerID);
                command.Parameters.AddWithValue("$PlayerVP", PlayerVP);
                command.Parameters.AddWithValue("$PlayerColor", PlayerColor);
                command.Parameters.AddWithValue("$PlayerOrder", PlayerOrder);
                command.Parameters.AddWithValue("$WoodinHand", WoodinHand);
                command.Parameters.AddWithValue("$BrickinHand", BrickinHand);
                command.Parameters.AddWithValue("$SheepinHand", SheepinHand);
                command.Parameters.AddWithValue("$RockinHand", RockinHand);
                command.Parameters.AddWithValue("$WheatinHand", WheatinHand);
                command.ExecuteNonQuery();
            }
        }*/


        public static DataTable GetBoardTiles()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TileID, GameID, ResoucreType, TileProbability, TileCenterX, TileCenterY, TilehasRobber, FROM BoardTiles;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public static void AddBoardTiles(int GameID, string ResoucreType, int TileProbability, int TileCenterX, int TileCenterY, bool TilehasRobber)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO BoardTiles(GameID, ResoucreType, TileProbability, TileCenterX, TileCenterY, TilehasRobber)
                                        VALUES ($GameID, $ResoucreType, $TileProbability, $TileCenterX, $TileCenterY, $TilehasRobber); ";
                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$ResoucreType", ResoucreType);
                command.Parameters.AddWithValue("$TileProbability", TileProbability);
                command.Parameters.AddWithValue("$TileCenterX", TileCenterX);
                command.Parameters.AddWithValue("$TileCenterY", TileCenterY);
                command.Parameters.AddWithValue("$TilehasRobber", TilehasRobber);
                command.ExecuteNonQuery();
            }
        }


        public static DataTable GetBuildings()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BuildingID, GameID, PlayerID, BuildingType, BuildingLocationX, BuildingLocationY FROM Buildings;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddBuildings(int BuildingID, int GameID, int PlayerID, string BuildingType, int BuildingLocationX, int BuildingLocationY)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Buildings(GameID, PlayerID, BuildingType, BuildingLocationX, BuildingLocationY)
                                        VALUES ($GameID, $PlayerID, $BuildingType, $BuildingLocationX, $BuildingLocationY); ";
                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$PlayerID", PlayerID);
                command.Parameters.AddWithValue("$BuildingType", BuildingType);
                command.Parameters.AddWithValue("$BuildingLocationX", BuildingLocationX);
                command.Parameters.AddWithValue("$BuildingLocationY", BuildingLocationY);
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetRoads()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT RoadID, GameID, PlayerID, RoadStartX, RoadStartY, RoadEndX, RoadEndY FROM Roads;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddRoads(int GameID, int PlayerID, int RoadStartX, int RoadStartY, int RoadEndX, int RoadEndY)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Roads(GameID, PlayerID, RoadStartX, RoadStartY, RoadEndX, RoadEndY)
                                        VALUES ($GameID, $PlayerID, $RoadStartX, $RoadStartY,  $RoadEndX, $RoadEndY); ";

                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$PlayerID", PlayerID);
                command.Parameters.AddWithValue("$RoadStartX", RoadStartX);
                command.Parameters.AddWithValue("$RoadStartY", RoadStartY);
                command.Parameters.AddWithValue("$RoadEndX", RoadEndX);
                command.Parameters.AddWithValue("$RoadEndY", RoadEndY);
                command.ExecuteNonQuery();
            }
        }
        
        public static DataTable GetDevelopmentCards()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CardID, GameID, CardType, IsUsed, FROM DevelopmentCards;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddDevelopmentCards(int GameID, string CardType, bool IsUsed)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Roads(GameID, CardType, IsUsed)
                                        VALUES ($GameID, $CardType, $IsUsed); ";

                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$CardType", CardType);
                command.Parameters.AddWithValue("$IsUsed", IsUsed);
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetTurns()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TurnID, GameID, PlayerID, TurnNumber, TurnStartTime, TurnEndTime FROM Turns;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddTurns(int GameID, int PlayerID, int TurnNumber, DateTime TurnStartTime, DateTime TurnEndTime)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Turns( GameID, PlayerID, TurnNumber, TurnStartTime, TurnEndTime)
                                        VALUES ($GameID, $PlayerID, $TurnNumber, $TurnStartTime, $TurnEndTime); ";

                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$PlayerID", PlayerID);
                command.Parameters.AddWithValue("$TurnNumber", TurnNumber);
                command.Parameters.AddWithValue("$TurnStartTime", TurnStartTime);
                command.Parameters.AddWithValue("$TurnEndTime", TurnEndTime);
                command.ExecuteNonQuery();
            }
        }
        
        public static DataTable GetPlayerhand()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GameID, PlayerID, PlayerCards, PlayerCardsQuantity, PlayerVP FROM Playerhand;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddPlayerhand(int GameID, int PlayerID, string PlayerCards, int PlayerCardsQuantity, int PlayerVP)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Turns( GameID, PlayerID, PlayerCards, PlayerCardsQuantity, PlayerVP)
                                        VALUES ($GameID, $PlayerID, $PlayerCards, $PlayerCardsQuantity, $PlayerVP); ";

                //command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$PlayerID", PlayerID);
                command.Parameters.AddWithValue("$PlayerCards", PlayerCards);
                command.Parameters.AddWithValue("$PlayerCardsQuantity", PlayerCardsQuantity);
                command.Parameters.AddWithValue("$PlayerVP", PlayerVP);
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetBank()
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ResourceID, ResourceType,  ResouceCount FROM Bank;";
                using (var reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static void AddBank(int GameID, int ResourceID, string ResourceType, int ResouceCount)
        {
            using (var connection = new SqliteConnection(connectingString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Bank(ResourceID, ResourceType,  ResouceCount)
                                        VALUES ($GameID, $ResourceID, $ResourceType,$ResouceCount); ";

                command.Parameters.AddWithValue("$GameID", GameID);
                command.Parameters.AddWithValue("$ResourceID", ResourceID);
                command.Parameters.AddWithValue("$ResourceType", ResourceType);
                command.Parameters.AddWithValue("$ResouceCount", ResouceCount);
                command.ExecuteNonQuery();
            }
        }
    }
}
 