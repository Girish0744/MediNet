using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onana_Hospital_Management_System
{
    public partial class frmsplashScreen : Form
    {
        public frmsplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);
            if (progressBar1.Value == progressBar1.Maximum)
            {
                frmLogin logins = new frmLogin();
                timer1.Stop();
                this.Hide();
                logins.Show();
            
            }
        }

        private void frmsplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
           // notifyIcon1.BalloonTipShown = true;
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
