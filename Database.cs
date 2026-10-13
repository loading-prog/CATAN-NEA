using System;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace catan
{

    internal static class DataBaseHelper
    {
        static string connectingString = "Data Source=MemoryDb.db";

           /* public static void initializeDataBase()
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    SqliteCommand command = connection.CreateCommand();

                    command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Tiles (
                    TileID INTEGER PRIMARY KEY AUTOINCREMENT,
                    TileType TEXT NOT NULL,
                    TileNeighbour TEXT NOT NULL,
                    TileProbability INT
                );
                CREATE TABLE IF NOT EXISTS Gameboard (
                    Foreign KEY mpl
                CREATE TABLE IF NOT EXISTS Playerhand (
                    PlayerID INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlayerCards TEXT NOT NULL,
                    PlayerCardsQuantity INT,
                    PlayerVP INT
                );
                CREATE TABLE IF NOT EXISTS Storage (
                    ResourceID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ResourceType TEXT NOT NULL,
                    ResouceCount INTEGER,
                );

            ";
                    command.ExecuteNonQuery();

                    command.CommandText = @"
                INSERT INTO Teachers(FirstName, LastName) VALUES
                    ('Alice', 'Smith'),
                    ('Bob', 'Johnson');
                
                INSERT INTO Students(FirstName, LastName) VALUES
                    ('John', 'Doe'),
                    ('Jane', 'Roe'),
                    ('Sam', 'Green');
                
                INSERT INTO Courses(CourseName, Credits, TeacherID) VALUES
                    ('Maths', 5 , 1),
                    ('History', 4, 2),
                    ('Science', 3, NULL);
            ";
                    command.ExecuteNonQuery();
                }

            }
            public static DataTable GetStudents()
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT StudentID, FirstName, LastName FROM Students;";
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
            public static void AddStudent(string firstname, string lastname)
            {
                using (var connection = new SqliteConnection(connectingString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Students (firstname, lastname)
                                            VALUES ($FirstName , $LastName); ";
                    command.Parameters.AddWithValue("$FirstName", firstname);
                    command.Parameters.AddWithValue("$LastName", lastname);

                    command.ExecuteNonQuery();

                }
            }*/
    }
}
