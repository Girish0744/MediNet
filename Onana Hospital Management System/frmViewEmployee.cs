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
    public partial class frmViewEmployee : Form
    {
        clsSelect selectClass = new clsSelect();
        public frmViewEmployee()
        {
            InitializeComponent();
        }

        private void frmViewEmployee_Load(object sender, EventArgs e)
        {
            selectClass.viewEmployee(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // label1.Text = dataGridView1.CurrentCell.Value.ToString();
           //// label2.Text = dataGridView1.CurrentCell.
           // selectClass.selectImageFromEmployee(label1.Text, pictureBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
            
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fname,sname,oname;



           

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];


                //using id to pull picture
                label1.Text = row.Cells[0].Value.ToString();
                selectClass.selectImageFromEmployee(label1.Text, pictureBox1);

               
               fname = row.Cells[1].Value.ToString();
               sname = row.Cells[2].Value.ToString();
               oname = row.Cells[3].Value.ToString();
               txtEmpname.Text = fname + " " + sname + " " + oname;
               txtEmpPhone.Text = row.Cells[6].Value.ToString();
               txtemail.Text = row.Cells[7].Value.ToString();
               txtdepartment.Text = row.Cells[10].Value.ToString();
               txtqualification.Text = row.Cells[12].Value.ToString();
               txtresidence.Text = row.Cells[13].Value.ToString();
               txtreference.Text = row.Cells[14].Value.ToString();
               txtrefcontact.Text = row.Cells[15].Value.ToString();
            }
        }


    }
}
