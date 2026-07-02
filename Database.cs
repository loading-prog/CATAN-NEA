using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace catan
{
 
        internal static class DataBaseHelper
        {
            static string connectingString = "Data Source=MemoryDb.db";

            public static void initializeDataBase()
            {
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
                    cmd.CommandText = @"
            INSERT INTO Players (Username, TotalGamesPlayed, TotalWins, TotalLosses)
            VALUES ($username, $games, $wins, $losses);";
                    cmd.Parameters.AddWithValue("$username", player.Username);
                    cmd.Parameters.AddWithValue("$games", player.TotalGamesPlayed);
                    cmd.Parameters.AddWithValue("$wins", player.TotalWins);
                    cmd.Parameters.AddWithValue("$losses", player.TotalLosses);
                    cmd.ExecuteNonQuery();
                }
            }



            /*    public static DataTable GetTile()
                {
                    using (var connection = new SqliteConnection(connectingString))
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "SELECT TileId, TileType, TileNeighbour, TileProbability, TilecenterX, TileCenterY FROM Tile;";
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);
                            return table;
                        }
                    }
                }
                public static void AddTile(string TileType, string TileNeighbour, int TileProbability, int TileCenterX, int TileCenterY)
                {
                    using (var connection = new SqliteConnection(connectingString))
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = @"INSERT INTO Tile(firstname, lastname)
                                                 VALUES ($FirstName , $LastName); ";
                        command.Parameters.AddWithValue("$FirstName", firstname);
                        command.Parameters.AddWithValue("$LastName", lastname);

                        command.ExecuteNonQuery();

                    }
                }*/
        }
    
}
