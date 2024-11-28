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
    public partial class frmViewPatient : Form
    {
        clsSelect selectClass = new clsSelect();
        public frmViewPatient()
        {
            InitializeComponent();
        }

        private void frmViewPatient_Load(object sender, EventArgs e)
        {
            selectClass.viewPatient(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //label1.Text = dataGridView1.CurrentCell.Value.ToString();
            //selectClass.selectImage(label1.Text, pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fname, sname, oname;



            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                //assigning data gride field to control 
                //using their index/ numeric position starting from zero

                label1.Text = row.Cells[0].Value.ToString();
                selectClass.selectImage(label1.Text, pictureBox1);

                fname = row.Cells[1].Value.ToString();
                sname = row.Cells[2].Value.ToString();
                oname = row.Cells[3].Value.ToString();
                txtEmpname.Text = fname + " " + sname + " " + oname;
                txtdepartment.Text = row.Cells[5].Value.ToString();
                txtresidence.Text = row.Cells[7].Value.ToString();
                txtqualification.Text = row.Cells[8].Value.ToString();
                txtEmpPhone.Text = row.Cells[9].Value.ToString();
                txtemail.Text = row.Cells[10].Value.ToString();
                txtreference.Text = row.Cells[13].Value.ToString();
                txtrefcontact.Text = row.Cells[14].Value.ToString();
            }

           
        }
    }
}
