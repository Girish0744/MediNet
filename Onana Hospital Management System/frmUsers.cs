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
    public partial class frmUsers : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        SqlDataReader reader;
        int i;

        ErrorProvider err = new ErrorProvider();

        public frmUsers()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //create a method for errorHandling
      void validatePass(Control ctrl)
        {
            if (txtPass.Text.Trim().Length > 0)
            {
                err.SetError(txtPass, string.Empty);
            }
            else
            {
                err.SetError(txtPass, "Please enter a value");
                return;
            }
        
        }


      void validateConfirmPass(Control ctrl)
      {
          if (txtConfirmPass.Text.Trim().Length > 0)
          {
              err.SetError(txtConfirmPass, string.Empty);
          }
          else
          {
              err.SetError(txtConfirmPass, "Please enter a value");
              return;
          }

      }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            clearAll();
            txtUname.Text = txtEmpName.Text.Trim();
        }

        private void cboEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            selectClass.getDetails(cboEmpID);
           
            txtEmpName.Text = selectClass.fullName;
            txtDepartment.Text = selectClass.deptart;
            txtcontact.Text = selectClass.cont;
            txtDesignation.Text = selectClass.designate;
            txtUname.Text = txtEmpName.Text.Trim();

        }

        //RESET
        void clearAll()
        {
            selectClass.getEmpCode(cboEmpID);
            cboLevel.SelectedIndex = 0;
            txtUname.ResetText();
            txtPass.ResetText();
            txtConfirmPass.ResetText();
           

        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            validatePass(txtPass);
            validateConfirmPass(txtConfirmPass);

            if (err.GetError(txtPass).Length != 0)
            {
                err.SetError(txtPass, "Please enter a value");
                return;
            }
            else if (err.GetError(txtPass).Length != 0)
            {
                err.SetError(txtConfirmPass, "Please enter a value");
                return;
            }

                //PASSWORD AND CONFIRM PASSWORD TEXT ARE FILLED
            else
            {

                if (txtPass.Text.Trim() == txtConfirmPass.Text.Trim())
                {
                    Valinput(cboEmpID);

                }
                else
                {

                    MessageBox.Show("Password mismatch !", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

           
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // insert
        public void Valinput(ComboBox cobUser)
        {
            try
            {
               
                SqlConnection con = new SqlConnection(varinsert.dbPath);

                string sql = "select empCode from Users  where empCode = @empCode";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@empCode", cobUser.SelectedItem.ToString());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1
                //meaning user already exist
                if (count == 1)
                {
                    MessageBox.Show("User Already Exist", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    varinsert.insertIntoUsers(cboEmpID, txtUname.Text, txtPass.Text, cboLevel);
                    clearAll();
                }

            }

            catch (Exception ex)
            {

            }

        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            validatePass(( Control)sender);
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            validatePass((Control)sender);
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            validateConfirmPass((Control) sender);
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            validateConfirmPass((Control)sender);
        }
    }
}
