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
    public partial class frmPatientBills : Form
    {
        clsSelect selectClass = new clsSelect();
        public frmPatientBills()
        {
            InitializeComponent();
        }

        private void frmPatientBills_Load(object sender, EventArgs e)
        {
            selectClass.viewBills(dataGridView1);
            selectClass.calcBilling(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
