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
using Onana_Hospital_Management_System;
namespace Onana_Hospital_Management_System
{
    public partial class Form1 : Form
    {
        clsInsert varInsert = new clsInsert();
        SqlDataReader reader;
        int i;
        ErrorProvider err = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            validateDepartment(txtDept);

            if (err.GetError(txtDept).Length != 0)
            {
                err.SetError(txtDept, "Please enter a value");
                return;
            }
            else {

                txtDept.Refresh();
                 Valinput(txtDept.Text);
               
            }
         }

        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            validateDepartment((Control)sender);
        }

        private void txtDept_Leave(object sender, EventArgs e)
        {
            validateDepartment((Control)sender);
        }


       

        //validate depart
        void validateDepartment(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtDept.Text))
            {
                err.SetError(txtDept, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDept.Text))
            {
                err.SetError(txtDept, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtDept, string.Empty);
            }
        }


        // insert
        public void Valinput(string dept)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(varInsert.dbPath);

                string sql = "select deptName from tblDepartment where deptName  = '" + txtDept.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue(txtDept.Text.Trim(), dept);
                
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, then department exist
                if (count == 1)
                {
                    MessageBox.Show("Department Already Exist", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    varInsert.InsertToDept(txtDept.Text);
                    txtDept.ResetText();
                }

            }

            catch (Exception ex)
            {

            }

        }
    }
}
