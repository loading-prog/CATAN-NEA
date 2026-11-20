using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catan
{
    public partial class GameRules : Form
    {
        WebBrowser webBrowser;
        public GameRules()
        {
            InitializeComponent();
            webBrowser = new WebBrowser();
            this.Controls.Add(webBrowser);
            webBrowser.Location = new Point(0, 0);
            webBrowser.Navigate("http://www.catan.com/understand-catan/game-rules");
            webBrowser.Width = 1000;
            webBrowser.Height = 800;
        }

        private void GameRules_Load(object sender, EventArgs e)
        {

        }
    }
}
