
using System;
using System.Drawing;
using System.Windows.Forms;

namespace catan
{
    internal class ResourceDiscardForm : Form
    {                
        private Player player; 
        private Theif theif;
        private int resourcesLeft;
        private Label DiscardLabel;
        
        public ResourceDiscardForm(Player currentPlayer, Theif currentTheif)
        {
            player = currentPlayer;
            theif = currentTheif;
            resourcesLeft = theif.GetDiscardedAmount(player);
            
            this.Text = "Discard Resources";
            this.Width = 450;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label playerLabel = new Label();
            playerLabel.Text = "Player: " + player.Username;
            playerLabel.Location = new Point(20, 20);
            playerLabel.AutoSize = true;
            this.Controls.Add(playerLabel);

            DiscardLabel = new Label();
            DiscardLabel.Text = "Resources Left to Discard: " + resourcesLeft;
            DiscardLabel.Location = new Point(20, 55);
            DiscardLabel.AutoSize = true;
            this.Controls.Add(DiscardLabel);

            string[] resources = { "Brick", "Wood", "Wheat", "Ore", "Sheep"};
            for (int i = 0; i < resources.Length; i++)
            {
                Button resourceButton = new Button();
                resourceButton.Text = resources[i];
                resourceButton.Width = 100;
                resourceButton.Height = 35;
                resourceButton.Location = new Point(20, 90 + (i * 45));

                resourceButton.Click += (sender, e) =>
                {
                    if (resourcesLeft > 0)
                    {
                        if (theif.DiscardRescource(player, resourceButton.Text) == true)
                        {
                            resourcesLeft--;
                            DiscardLabel.Text = "Resources Left to Discard: " + resourcesLeft;
                
                            if (resourcesLeft == 0)
                            {
                                MessageBox.Show("All required resources have been discarded!");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You do not have any " + resourceButton.Text + " to discard.");
                        }
                    }
                };
                this.Controls.Add(resourceButton);
            }
            this.FormClosing += (sender, e) =>
            {
                if (resourcesLeft > 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("You must discard all required resources before continuing.");
                }
            };
        }
    }
}
