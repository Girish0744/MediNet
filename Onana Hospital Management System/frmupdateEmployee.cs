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
using System.IO;
namespace Onana_Hospital_Management_System
{
    public partial class frmupdateEmployee : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        ErrorProvider err = new ErrorProvider();

        public frmupdateEmployee()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            selectClass.ImageUpload(picImage);
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysDat = new DateTimePicker();
            sysDat.Value = System.DateTime.Now;
            txtAge.Text = (sysDat.Value.Year - dtpDOB.Value.Year).ToString();
        }

        private void frmupdateEmployee_Load(object sender, EventArgs e)
        {
            RESETTING();
        }

        void RESETTING()
        {
            selectClass.getDepart(cboDepartment);
            cboGender.SelectedIndex = 0;
            cboNationality.SelectedIndex = 0;
            txtEmpCode.ResetText();
            txtOname.ResetText();
            txtLastName.ResetText();
            txtFirstName.ResetText();
            txtAge.ResetText();
            txtContact.ResetText();
            txtQaulification.ResetText();
            txtDesignation.ResetText();
            txtResAddress.ResetText();
            txtEmail.ResetText();
            txtReferenceName.ResetText();
            txtRefContact.ResetText();
            dtpDOB.ResetText();
            dtpDateJoined.ResetText();
            picImage.Image = Properties.Resources.index;

        }


        //GET EMPLOYEE DETAILS
        public void selectEmployeeDetails()
        {

            try
            {

                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select empSname,empFname,empOname,empDOB,empGender,empContact,empEmail,empNationality,empDateJoined,empDepartment,empDesignation,empQualification,empResidenceAddress,empReferenceName,empReferenceContact,epmPhoto from tblEmployees  where empCode = '" + txtEmpCode.Text.Trim() + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtLastName.Text = reader["empSname"].ToString();
                    txtFirstName.Text = reader["empFname"].ToString();
                    txtOname.Text = reader["empOname"].ToString();
                    dtpDOB.Text = reader["empDOB"].ToString();
                    cboGender.SelectedItem = reader["empGender"].ToString();
                    txtContact.Text = reader["empContact"].ToString();
                    txtEmail.Text = reader["empEmail"].ToString();
                    cboNationality.SelectedItem = reader["empNationality"].ToString();
                    dtpDateJoined.Text = reader["empDateJoined"].ToString();
                    cboDepartment.SelectedItem = reader["empDepartment"].ToString();
                    txtDesignation.Text = reader["empDesignation"].ToString();
                    txtQaulification.Text = reader["empQualification"].ToString();
                    txtResAddress.Text = reader["empResidenceAddress"].ToString();
                    txtReferenceName.Text = reader["empReferenceName"].ToString();
                  txtRefContact.Text =   reader["empReferenceContact"].ToString();

                    MemoryStream ms = new MemoryStream((byte[])reader["epmPhoto"]);
                   picImage .Image = new Bitmap(ms);
                }
                else
                {

                     txtLastName.Text = "";
                    txtFirstName.Text =  "";
                    txtOname.Text = "";
                    dtpDOB.Text = "";
                    cboGender.SelectedItem =  "";
                    txtContact.Text =  "";
                    txtEmail.Text = "";
                    cboNationality.SelectedItem =  "";
                    dtpDateJoined.Text =  "";
                    cboDepartment.SelectedItem =  "";
                    txtDesignation.Text =  "";
                    txtQaulification.Text = "";
                    txtResAddress.Text = "";
                    txtReferenceName.Text =  "";
                    txtRefContact.Text = "";
                    picImage.Image = Properties.Resources.index;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        void updateEmployeeDetails(string empSname, string empFname, string empOname, DateTimePicker empDOB, string empGender, string empContact, string empEmail, ComboBox empNationality, DateTimePicker empDateJoined, ComboBox empDepartment, string empDesignation, string empQualification, string empResidenceAddress, string empReferenceName, string empReferenceContact, PictureBox epmPhoto)
        {

            string updateBillString;
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();

                updateBillString = "update tblEmployees set empSname =@empSname,empFname =@empFname, empOname =@empOname,empDOB=@empDOB ,empGender=@empGender, empContact=@empContact ,empEmail =@empEmail, empNationality=@empNationality , empDateJoined=@empDateJoined,empDepartment = @empDepartment,empDesignation=@empDesignation ,empQualification=@empQualification,empResidenceAddress=@empResidenceAddress ,empReferenceName =@empReferenceName,empReferenceContact =@empReferenceContact ,epmPhoto=@epmPhoto  where empCode = '" + txtEmpCode.Text.Trim() + "'";
                
                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    
                    cmd.Parameters.AddWithValue("@empSname", empSname.Trim());
                    cmd.Parameters.AddWithValue("@empFname", empFname.Trim());
                    cmd.Parameters.AddWithValue("@empOname", empOname.Trim());
                    cmd.Parameters.AddWithValue("@empDOB", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@empGender", cboGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@empContact", empContact.Trim());
                    cmd.Parameters.AddWithValue("@empEmail", empEmail.Trim());
                    cmd.Parameters.AddWithValue("@empNationality", empNationality.SelectedItem);
                    cmd.Parameters.AddWithValue("@empDateJoined", empDateJoined.Value.Date);
                    cmd.Parameters.AddWithValue("@empDepartment", empDepartment.SelectedItem);
                    cmd.Parameters.AddWithValue("@empDesignation", empDesignation.Trim());
                    cmd.Parameters.AddWithValue("@empQualification", empQualification.Trim());
                    cmd.Parameters.AddWithValue("@empResidenceAddress", empResidenceAddress.Trim());
                    cmd.Parameters.AddWithValue("@empReferenceName", empReferenceName.Trim());
                    cmd.Parameters.AddWithValue("@empReferenceContact", empReferenceContact.Trim());

                   
                    MemoryStream pp = new MemoryStream();
                    epmPhoto.Image.Save(pp, epmPhoto.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    SqlParameter ppic = new SqlParameter("epmPhoto", System.Data.SqlDbType.Image);
                    ppic.Value = pdata;
                    cmd.Parameters.Add(ppic);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();

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


        void saving()
        {
            try
            {
                //updateEmployeeImage();
                updateEmployeeDetails(txtLastName.Text,txtFirstName.Text,txtOname.Text,dtpDOB,cboGender.SelectedItem.ToString(),txtContact.Text,txtEmail.Text,cboNationality,dtpDateJoined,cboDepartment,txtDesignation.Text,txtQaulification.Text,txtResAddress.Text,txtReferenceName.Text,txtRefContact.Text,picImage);
                RESETTING();
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }



        private void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmpCode.Text.Trim().Length > 0)
            //{
            //    selectEmployeeDetails();
            //}
            validateEmpID((Control)sender);
            selectEmployeeDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             validateLastName(txtLastName);
            validateFirstName(txtFirstName);
            validateContact(txtContact);
            validateQualification(txtQaulification);
            validateDesignation(txtDesignation);
            validateResAddress(txtResAddress);
            validateReferenceName(txtReferenceName);
            validateRefContact(txtRefContact);
            validateEmpID(txtEmpCode);
           // validateEmail(txtEmail);
           
            if(err.GetError(txtLastName).Length !=0)
            {
                err.SetError(txtLastName, "Please enter a value");
            }
            else if(err.GetError(txtFirstName).Length !=0)
            
            {
                err.SetError(txtFirstName, "Please enter a value");            
            }
            else if(err.GetError(txtContact).Length !=0)
            {
                err.SetError(txtContact, "Please enter a numeric value of 10 digits long");            
            }

            else if(err.GetError(txtQaulification).Length !=0)
            {
                err.SetError(txtQaulification, "Please enter a value");
             }
            else if(err.GetError(txtDesignation).Length !=0){
                err.SetError(txtDesignation, "Please enter a value");
            }
            else if(err.GetError(txtResAddress).Length !=0){
            err.SetError(txtResAddress, "Please enter a value");
            }

            else if (err.GetError(txtReferenceName).Length !=0)
            {
            err.SetError(txtReferenceName, "Please enter a value");
            }
            else if (err.GetError(txtRefContact).Length != 0)
            {
                err.SetError(txtRefContact, "Please enter a numeric value of 10 digits long");
            }

            else
            {
                //ID SHOULD NOT BE EMPTY BEFORE UPDATING
                if (err.GetError(txtEmpCode).Length ==0)
               
                {
                    saving();
                    RESETTING(); //INITIALISE TO FORMER STATE
                    ClearAllErrorProviderIcons();
                }
                else { 
                    
                }
                
            }
          
        }



        //VALIDATEION OF THE TEXT BOXES
        void validateLastName(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                err.SetError(txtLastName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                err.SetError(txtLastName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtLastName, string.Empty);
            }
        }

        void validateFirstName(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                err.SetError(txtFirstName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                err.SetError(txtFirstName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtFirstName, string.Empty);
            }
        }

        void validateContact(Control ctrl)
        {

            if (txtContact.Text.Trim().Length != 10)
            {
                err.SetError(txtContact, "Please enter a numeric value of 10 digits long");
                return;
            }
            else
            {
                err.SetError(txtContact, string.Empty);
            }
        }

        void validateQualification(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtQaulification.Text))
            {
                err.SetError(txtQaulification, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtQaulification.Text))
            {
                err.SetError(txtQaulification, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtQaulification, string.Empty);
            }
        }

        void validateDesignation(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtDesignation.Text))
            {
                err.SetError(txtDesignation, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDesignation.Text))
            {
                err.SetError(txtDesignation, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtDesignation, string.Empty);
            }
        }

        void validateResAddress(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtResAddress.Text))
            {
                err.SetError(txtResAddress, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtResAddress.Text))
            {
                err.SetError(txtResAddress, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtResAddress, string.Empty);
            }

        }

        void validateReferenceName(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtReferenceName.Text))
            {
                err.SetError(txtReferenceName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtReferenceName.Text))
            {
                err.SetError(txtReferenceName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtReferenceName, string.Empty);
            }
        }

        void validateRefContact(Control ctrl)
        {
            if (txtRefContact.Text.Trim().Length != 10)
            {
                err.SetError(txtRefContact, "Please enter a numeric value of 10 digits long");
                return;
            }
            else
            {
                err.SetError(txtRefContact, string.Empty);
            }
        }

        void validateEmpID(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtEmpCode.Text))
            {
                err.SetError(txtEmpCode, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtEmpCode.Text))
            {
                err.SetError(txtEmpCode, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtEmpCode, string.Empty);
            }
        }


        //NOT WORKING
        void validateEmail(Control ctrl)
        {
            if (txtEmail.Text.Trim() != "")
            {
                if ((txtEmail.Text.Contains("@") && (txtEmail.Text.Contains("."))))
                {
                    err.SetError(txtReferenceName, string.Empty);
                }

                else
                {
                    err.SetError(txtEmail, "Email must contain @ and .");
                    return;
                }
            }
            else
            {
                err.SetError(txtReferenceName, string.Empty);
            }


        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            validateLastName((Control)sender);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            validateLastName((Control)sender);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            validateFirstName((Control)sender);
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            validateFirstName((Control)sender);
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            validateContact((Control)sender);
           
        }

        private void txtQaulification_TextChanged(object sender, EventArgs e)
        {
            validateQualification((Control)sender);
        }

        private void txtQaulification_Leave(object sender, EventArgs e)
        {
             validateQualification((Control)sender);
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            validateDesignation((Control)sender);
        }

        private void txtResAddress_TextChanged(object sender, EventArgs e)
        {
            validateResAddress((Control)sender);
        }

        private void txtResAddress_Leave(object sender, EventArgs e)
        {
            validateResAddress((Control)sender);
        }

        private void txtReferenceName_TextChanged(object sender, EventArgs e)
        {
            validateReferenceName((Control)sender);
        }

        private void txtReferenceName_Leave(object sender, EventArgs e)
        {
            validateReferenceName((Control)sender);
        }

        private void txtRefContact_TextChanged(object sender, EventArgs e)
        {
            validateRefContact((Control)sender);
        }

        private void txtRefContact_Leave(object sender, EventArgs e)
        {
            validateRefContact((Control)sender);
        }

        private void txtEmpCode_Leave(object sender, EventArgs e)
        {
            validateEmpID((Control)sender);
        }

        //DETROY ERROR PROVIDER ICONS
        void ClearAllErrorProviderIcons()
        {
            err.SetError(txtEmpCode, string.Empty);
            err.SetError(txtFirstName, string.Empty);
            err.SetError(txtLastName, string.Empty);
            err.SetError(txtContact, string.Empty);
            err.SetError(txtQaulification, string.Empty);
            err.SetError(txtDesignation, string.Empty);
            err.SetError(txtResAddress, string.Empty);
            err.SetError(txtReferenceName, string.Empty);
            err.SetError(txtRefContact, string.Empty);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
