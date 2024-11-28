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
    public partial class frmViewBills : Form
    {
        clsInsert varintsert = new clsInsert();
        clsSelect selectClass = new clsSelect();
        public frmViewBills()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmViewBills_Load(object sender, EventArgs e)
        {
            selectClass.viewItemBills(dataGridView1);
            selectClass.selectPatientname(patName);
        }


        //Filter Search
        public void selectBills()
        {

            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("(from Date) can not be greater than (To Date)  ", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            
            }


            try
            {

                SqlConnection con = new SqlConnection(varintsert.dbPath);

                string sql = "select patID as [Patient ID], PatientName as [Patient Name], TransDate as [Transaction Date], TransTime as [Transaction Time], Item , Amts as [Price GH₵], TransBy[Server] from ItemsBills where PatientName = '" + patName.SelectedItem + "' and TransDate >='" + dtpFrom.Value.Date + "' and  TransDate <='" + dtpTo.Value.Date + "'";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();
               
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

        private void button1_Click(object sender, EventArgs e)
        {
            selectBills();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
