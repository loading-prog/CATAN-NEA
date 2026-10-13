using Microsoft.Data.Sqlite;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace catan
{
    internal class Database
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

                 CREATE TABLE IF NOT EXISTS Player (
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
                    FOREIGN KEY (CurrentLeader) REFERENCES Player(PlayerID),
                    FOREIGN KEY (WinnerID) REFERENCES Player(PlayerID)     
                 ); 
                    

                CREATE TABLE IF NOT EXISTS GamePlayer (
                    GamePlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                    GameID INTEGER NOT NULL,
                    PlayerID INTEGER NOT NULL,
                    PlayerVP INT,
                    PlayerColor VARCHAR,
                    PlayerOrder INT,
                    WoodinHand INT,
                    BrickinHand INT,    
                    SheepinHand INT,
                    RockinHand INT, 
                    WheatinHand INT,
                    FOREIGN KEY (GameID) REFERENCES Game(GameID),
                    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
                );

                 CREATE TABLE IF NOT EXISTS Tiles (
                     TileID INTEGER PRIMARY KEY AUTOINCREMENT,
                     TileType TEXT NOT NULL,
                     TileNeighbour TEXT NOT NULL,
                     TileProbability INT,
                     TileCenterX INT,
                     TileCenterY INT
                 );
              
                 CREATE TABLE IF NOT EXISTS Playerhand (
                     PlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                     PlayerCards TEXT NOT NULL,
                     PlayerCardsQuantity INT,
                     PlayerVP INT
                 );
                 CREATE TABLE IF NOT EXISTS Storage (
                     ResourceID INTEGER PRIMARY KEY AUTOINCREMENT,
                     ResourceType TEXT NOT NULL,
                     ResouceCount INTEGER
                 );

             ";
                    command.ExecuteNonQuery();

   /*                 command.CommandText = @"
                 INSERT INTO Tiles(TileID, TileType, TileNeighbour, TileProbabilty,TileCenterX, TileCenterY) VALUES
                     ('Alice', 'Smith'),
                     ('Bob', 'Johnson');

                 INSERT INTO Tiles(TileID, TileType, TileNeighbour, TileProbabilty,TileCenterX, TileCenterY) VALUES
                     ('John', 'Doe'),
                     ('Jane', 'Roe'),
                     ('Sam', 'Green');
             ";*/
                    command.ExecuteNonQuery();
                }

            }
            public static DataTable GetTile()
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
                                             VALUES ($FirstName, $LastName); 
                                             command.Parameters.AddWithValue($FirstName, $FirstName);
                                             command.Parameters.AddWithValue($LastName, $LastName);
                ";
                    command.ExecuteNonQuery();

                }
            }



            public static DataTable GetGame()
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT GameID, TimeStarted, TimeEnded, WinnerID, CurrentLeader, GameState FROM Tile;";
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
            public static void AddGame(int WinnerID, TimeOnly TimeStarted, TimeOnly TimeEnded, string CurrentLeader,  bool GameState)
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Game(WinnerID, TimeStarted, TimeEnded, CurrentLeader, GameState)
                                             VALUES ($WinnerID, $TimeStarted, $TimeEnded, $CurrentLeader, $GameState); 
                                             command.Parameters.AddWithValue($WinnerID, WinnerID.Text);
                                             command.Parameters.AddWithValue($TimeStarted, TimeStarted.Text);
                                             command.Parameters.AddWithValue($TimeEnded, TimeEnded.Text);
                                             command.Parameters.AddWithValue($CurrentLeader, CurrentLeader.Text);
                                             command.Parameters.AddWithValue($GameState, GameState.Text);
                ";
                    command.ExecuteNonQuery();
                }
            }




            public static DataTable GetGamePlayer()
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT GamePlayerID, GameID, PlayerID, PlayerVP, PlayeColor, PlayerOrder, WoodinHand, BrickinHand, SheepinHand, RockinHand, WheatinHand FROM Tile;";
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }

            public static void AddGamePlayer(int PlayerVP, string PlayerColor, int PlayerOrder, int WoodinHand, int Brickinhand, int SheepinHand, int RockinHand, int WheatinHand)
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO GamePlayer(PlayerVP, PlayerColor, PlayerOrder, WoodinHand, BrickinHand, SheepinHand, RockinHand, WheatinHand)
                                             VALUES ($PlayerVP, $PlayerColor, $PlayerOrder, $WoodinHand, $BrickinHand, $SheepinHand, $RockinHand, $WheatinHand); 
                                             command.Parameters.AddWithValue($PlayerVP, PlayerVP.int);
                                             command.Parameters.AddWithValue($PlayerColor, PlayerColor.Text);
                                             command.Parameters.AddWithValue($PlayerOrder, PlayerOrder.Text);
                                             command.Parameters.AddWithValue($WoodinHand, WoodinHand.int);
                                             command.Parameters.AddWithValue($BrickinHand, BrickinHand.int);
                                             command.Parameters.AddWithValue($BrickinHand, RockinHand.int);
                                             command.Parameters.AddWithValue($BrickinHand, WheatinHand.int);

                ";
                    command.ExecuteNonQuery();
                }
            }

            public static DataTable GetPlayer()
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT PlayerID, UserName, TotalGamesPlayed, TotalWins, TotalLosses,CreationDate";
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
            public static void AddPlayer(int PlayerID, string UserName, int TotalGamesPlayed, int TotalWins, int TotalLosses, DateTime CreationDate)
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO GamePlayer(PlayerID, UserName, TotalGamesPlayed, TotalWins, TotalLosses, CreationDate)
                                             VALUES ($PlayerID, $UserName, $TotalGamesPlayed, $TotalWins, $TotalLosses, CreationDate); 
                                             command.Parameters.AddWithValue($PlayerID, PlayerID.int);
                                             command.Parameters.AddWithValue($UserName, UserName.Text);
                                             command.Parameters.AddWithValue($TotalGamesPlayed, TotalGamesPlayed.Text);
                                             command.Parameters.AddWithValue($TotalWins, TotalWins.int);
                                             command.Parameters.AddWithValue($TotalLosses, TotalLosses.int);
                                             command.Parameters.AddWithValue($CreationDate, CreationDate.int);
                                             command.Parameters.AddWithValue($BrickinHand, WheatinHand.int);

                ";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
