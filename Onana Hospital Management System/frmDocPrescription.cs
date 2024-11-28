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
    public partial class frmDocPrescription : Form
    {
        clsSelect selectClass = new clsSelect();
        public frmDocPrescription()
        {
            InitializeComponent();
        }

        private void frmDocPrescription_Load(object sender, EventArgs e)
        {
            selectClass.selectConsultation(dataGridView1);
            patID.Text = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           patID.Text = dataGridView1.CurrentCell.Value.ToString();
           selectClass.selectConImage(patID.Text, pictureBox1);
           if (e.RowIndex >= 0)
           {
               DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
               textBox3.Text = row.Cells[4].Value.ToString();
               textBox1.Text = row.Cells[5].Value.ToString();
               textBox2.Text = row.Cells[6].Value.ToString();
           }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patID.Text = dataGridView1.CurrentCell.Value.ToString();
            selectClass.selectConImage(patID.Text, pictureBox1);

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox1.Text = row.Cells[5].Value.ToString();
                textBox2.Text = row.Cells[6].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
