
using System;
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
            playerLabel.text = "Player: ";
            playerLabel.Location = new point(20,20)
            playerLabel.AutoSize = true;
            this.Controls.Add(playerLabel);

            Label DiscardLabel = new Label();
            DiscardLabel.text = "Resources Left to Discard: 0";
            DiscardLabel.Location = new point(20,55)
            DiscardLabel.AutoSize = true;
            this.Controls.Add(DiscardLabel);
        }
    }
}
