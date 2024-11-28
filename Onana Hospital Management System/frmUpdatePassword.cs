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
    public partial class frmUpdatePassword : Form
    {

        ErrorProvider err = new ErrorProvider();
        public frmUpdatePassword()
        {
            InitializeComponent();
        }

        clsInsert varinsert = new clsInsert();
        private void button1_Click(object sender, EventArgs e)
        {
            ValidateUserID(txtUserID);
            ValidateUserName(txtUserName);
            ValidateCurrentPass(txtCurrent);
            ValidateNewPass(txtNewPassword);
            ValidateRepeattPass(txtrepeatPassword);

            if(err.GetError(txtUserID).Length !=0)
            {
                err.SetError(txtUserID, "Please enter a value");
            }
            else if(err.GetError(txtUserName).Length !=0)
            {
                err.SetError(txtUserID, "Please enter a value");
            }
            else if (err.GetError(txtCurrent).Length != 0)
            {
                err.SetError(txtUserID, "Please enter a value");
            }
            else if(err.GetError(txtNewPassword).Length !=0)
            {
                err.SetError(txtUserID, "Please enter a value");
            }
            else if(err.GetError(txtrepeatPassword).Length !=0)
            {
                err.SetError(txtUserID, "Please enter a value");
            }
            else
            {
                if (txtNewPassword.Text.Trim() == txtrepeatPassword.Text.Trim())
                {
                    selectUsers();
                    ClearErrorProviderIcons();

                }
                else
                {
                    MessageBox.Show("Password mismatch", "Error Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }


            }

            
        }


        void selectUsers()
        {
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                con = new SqlConnection(varinsert.dbPath);

                string sql = "select* from Users where Uname = @Uname and Pwd = @Pwd and empCode = @empCode";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Uname", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Pwd", txtCurrent.Text.Trim());
                cmd.Parameters.AddWithValue("@empCode", txtUserID.Text.Trim());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    updateUser();
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password or ID", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {

            }
        }
        
        void updateUser()
        {

            string updateBillString;
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();
                updateBillString = "update Users set Pwd = '" + txtNewPassword.Text + "'where empCode = '" + txtUserID.Text.Trim() + "' and Uname = '" + txtUserName.Text.Trim() + "'and  Pwd = '" + txtCurrent.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            ValidateUserID((Control)sender);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ValidateUserName((Control)sender);
        }

        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {
            ValidateCurrentPass((Control)sender);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateNewPass((Control)sender);
        }

        private void txtrepeatPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateRepeattPass((Control)sender);
        }

        void ValidateUserID(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                err.SetError(txtUserID, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                err.SetError(txtUserID, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtUserID, string.Empty);
            }
        
        }

        void ValidateUserName(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                err.SetError(txtUserName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                err.SetError(txtUserName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtUserName, string.Empty);
            }

        }

        void ValidateCurrentPass(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtCurrent.Text))
            {
                err.SetError(txtCurrent, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtCurrent.Text))
            {
                err.SetError(txtCurrent, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtCurrent, string.Empty);
            }

        }

        void ValidateNewPass(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                err.SetError(txtNewPassword, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                err.SetError(txtNewPassword, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtNewPassword, string.Empty);
            }

        }

        void ValidateRepeattPass(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtrepeatPassword.Text))
            {
                err.SetError(txtrepeatPassword, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtrepeatPassword.Text))
            {
                err.SetError(txtrepeatPassword, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtrepeatPassword, string.Empty);
            }

        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            ValidateUserID((Control)sender);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            ValidateUserName((Control)sender);
        }

        private void txtCurrent_Leave(object sender, EventArgs e)
        {
            ValidateCurrentPass((Control)sender);
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            ValidateNewPass((Control)sender);
        }

        private void txtrepeatPassword_Leave(object sender, EventArgs e)
        {
            ValidateRepeattPass((Control)sender);
        }

        void clearAll()
        {

            txtUserID.ResetText();
            txtUserName.ResetText();
            txtCurrent.ResetText();
            txtNewPassword.ResetText();
            txtrepeatPassword.ResetText();
        }

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            clearAll();
        }


        //Passwords
        void ClearErrorProviderIcons()
        {
            err.SetError(txtUserID, string.Empty);
            err.SetError(txtUserName, string.Empty);
            err.SetError(txtCurrent, string.Empty);
            err.SetError(txtNewPassword, string.Empty);
            err.SetError(txtrepeatPassword, string.Empty);

        
        }

    }
}
