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
    public partial class frmViewAppointment : Form
    {

        clsSelect selectClass = new clsSelect();
        public frmViewAppointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewAppointment_Load(object sender, EventArgs e)
        {
            selectClass.callSchedule(dataGridView1);
        }
    }
}
