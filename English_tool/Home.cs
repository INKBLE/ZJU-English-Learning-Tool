using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace English_tool
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.TopLevel = false;
            about.FormBorderStyle = FormBorderStyle.None;
            about.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(about);
            about.BringToFront();
            about.Show();
        }

        private void single_player_Click(object sender, EventArgs e)
        {
            Offline_setting offline = new Offline_setting();
            offline.TopLevel = false;
            offline.FormBorderStyle = FormBorderStyle.None;
            offline.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(offline);
            offline.BringToFront();
            offline.Show();
        }

        private void multiple_players_Click(object sender, EventArgs e)
        {
            Online_setting online = new Online_setting();
            online.TopLevel = false;
            online.FormBorderStyle = FormBorderStyle.None;
            online.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(online);
            online.BringToFront();
            online.Show();
        }
    }
}
