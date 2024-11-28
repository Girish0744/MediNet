using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Onana_Hospital_Management_System
{
    public partial class frmViewPatientWeight : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        public frmViewPatientWeight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewPatientWeight_Load(object sender, EventArgs e)
        {
            selectClass.selectPatientname(comboBox1);
            selectClass.callPatientWeight(dataGridView1);
           
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();
                string sql = "SELECT    patID  as [ID], patName as [Patient Name], bmi as [BMI], pressure as [Pressure], temperature as [Temperature], measuredOnDate as [Date], measuredOnTime as [Time] from PatientWeight where patName='" + comboBox1.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
             
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dataGridView1.DataSource = dsd;
                dataGridView1.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectClass.callPatientWeight(dataGridView1);
           
        }
    }
}
