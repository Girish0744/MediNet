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
    public partial class frmviewDailyTrans : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        public frmviewDailyTrans()
        {
            InitializeComponent();
        }

        private void frmviewDailyTrans_Load(object sender, EventArgs e)
        {
          selectClass.viewDailTransact(dataGridView1);
          label2.Text ="Total Number of Transactions: " + dataGridView1.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();


                string sql = "select ReceiptNo as [Receipt Number], PatientName as [Patient Name],TransDate as [Transaction Date], TransTime as [Transaction Time],Amts as [Amount Paid],AmtBalance as [Balance], TransBy as [Transaction By] from DailyTransaction where   PatientName like '%" + textBox1.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dataGridView1.DataSource = dsd;
                dataGridView1.DataMember = sql;
               
                MessageBox.Show(dataGridView1.RowCount.ToString() + " Record(s) found", "Search Result - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            else
            {
                 MessageBox.Show(" Record(s) not found", "Search Result - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bp = new Bitmap(this.dataGridView1.Width,this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bp, 0, 0);
        }
    }
}
