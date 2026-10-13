using catan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static catan.Database;

namespace catan
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            DataBaseHelper.initializeDataBase();
            InitializeComponent();

        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            //this.btnCreatePlayer.Enabled = true;


            // Add pop up selection choice. Input choice. 

            //PlayerCreation playerCreation = new PlayerCreation(true);
            //playerCreation.Show();
            //this.Hide();


            int PlayerID = 0;
            string Username = "";
            int TotalGamesPlayed = 0;
            int TotalWins = 0;
            int TotalLosses = 0;
            DateTime CreationDate = DateTime.Now;

            Database.DataBaseHelper.AddPlayer(PlayerID, Username, TotalGamesPlayed, TotalWins, TotalLosses, CreationDate);

            MessageBox.Show("Player Has been Created.");
            // public void SetupPlayers() //delete this later - for testing purposes 
            /*            List<Player> initialPlayers = new List<Player>
                        {
                            new Player("Alice"),
                            new Player("Bob"),
                            new Player("Charlie")

                        };
                        foreach (Player player in initialPlayers)
                        {
                            // Add the player to the game or perform any necessary setup

                            MessageBox.Show($"Player {player.Username} has been set up and added to the database.");

                            DataBaseHelper.InsertPlayer(player);
                        }*/
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(true);
            form1.Show();
            this.Hide();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
