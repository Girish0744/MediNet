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
    public partial class frmViewUsers : Form
    {
        clsSelect selectClass = new clsSelect();
        public frmViewUsers()
        {
            InitializeComponent();
        }

        private void frmViewUsers_Load(object sender, EventArgs e)
        {
            selectClass.viewUsers(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
