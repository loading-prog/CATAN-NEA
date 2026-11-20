using system;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace catan
{
    internal class RobberSelectionForm : Form
    {
      public Player SelectedVictim = null;

      public RobberSelectionForm(List <Player> players)
      {
        this.Text = "Choose a player to steal from";
        this.Width = 460;
        this.Height = 150 + (players.Count * 55);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label titleLabel = new Label();
        titleLabel.Text = "Username       Colour       Cards in Hand";
        titleLabel.Location = new Point(20, 20);
        titleLabel.AutoSize = true;
        this.Controls.Add(titleLabel);

        for (int i = 0; i < players.Count; i++)
            {
                Player victim = players[i];

                Button playerButton = new Button();
                playerButton.Width = 390;
                playerButton.Height = 40;
                playerButton.Location = new Point(20, 50 + (i * 55));

                playerButton.Text = victim.Username
                    + "       " + victim.PlayerColour.Name
                    + "       " + victim.GetTotalResources() + " cards";

                playerButton.BackColor = victim.PlayerColour;
                playerButton.ForeColor = Color.Black;

                playerButton.Click += (sender, e) =>
                {
                    SelectedVictim = victim;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                this.Controls.Add(playerButton);
            }

            this.FormClosing += (sender, e) =>
            {
                if (SelectedVictim == null)
                {
                    e.Cancel = true;
                    MessageBox.Show("You must choose a player to steal from.");
                }
            };
        }
    }
}
