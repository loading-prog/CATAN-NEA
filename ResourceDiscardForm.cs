
using System;
using System.Drawing;
using System.Windows.Forms;

namespace catan
{
    internal class ResourceDiscardForm : Form
    {
        public ResourceDiscardForm()
        {
            this.Text = "Discard Resources";
            this.Width = 450;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label playerLabel = new Label();    
            playerLabel.Text = "Player: ";
            playerLabel.Location = new Point(20, 20);
            playerLabel.AutoSize = true;
            this.Controls.Add(playerLabel);

            Label DiscardLabel = new Label();
            DiscardLabel.Text = "Resources Left to Discard: 0";
            DiscardLabel.Location = new Point(20, 55);
            DiscardLabel.AutoSize = true;
            this.Controls.Add(DiscardLabel);
        }
    }
}
