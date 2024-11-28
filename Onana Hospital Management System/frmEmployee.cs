using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Onana_Hospital_Management_System;
namespace Onana_Hospital_Management_System
{
    public partial class frmEmployee : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        ErrorProvider err = new ErrorProvider();
        DateTimePicker today = new DateTimePicker();
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            selectClass.ImageUpload(picImage);
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            RESETTING();
        }

        void RESETTING()
        {
            selectClass.getDepart(cboDepartment);
            cboGender.SelectedIndex = 0;
            cboNationality.SelectedIndex = 0;
            txtEmpCode.Text = "emp-" + selectClass.GenEmployeeNo().ToString();
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

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysDat = new DateTimePicker();
            sysDat.Value = System.DateTime.Now;
            txtAge.Text = (sysDat.Value.Year - dtpDOB.Value.Year).ToString();
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
            else if(err.GetError(txtRefContact).Length !=0)
            {
             err.SetError(txtRefContact, "Please enter a numeric value of 10 digits long");
            }
            //else if(err.GetError(txtEmail).Length !=0)
            //{
            //err.SetError(txtEmail, "Email must contain @ and .");
            //}
            else{
                varinsert.insertToEmployee(txtEmpCode.Text, txtLastName.Text, txtFirstName.Text, txtOname.Text, dtpDOB, cboGender.SelectedItem.ToString(), txtContact.Text, txtEmail.Text.ToLower(), cboNationality.SelectedItem.ToString(), dtpDateJoined, cboDepartment.SelectedItem.ToString(), txtDesignation.Text, txtQaulification.Text, txtResAddress.Text, txtReferenceName.Text, txtRefContact.Text, picImage);
                varinsert.insertIntoGenEmployeeNo(selectClass.GenEmployeeNo().ToString());
                RESETTING();
                ClearAllErrorProviderIcons();
            
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
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


        //NOT WORKING
        void validateEmail(Control ctrl)
        {
            if (txtEmail.Text.Trim() !="")
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
            else { 
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

        //ACCEPT NUMBERS ONLY
        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            int isNumeric = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumeric);
       }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            validateDesignation((Control)sender);
        }

        private void txtDesignation_Leave(object sender, EventArgs e)
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

        private void txtRefContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
          //  validateEmail((Control)sender);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
           // validateEmail((Control)sender);
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
        //DETROY ERROR PROVIDER ICONS
        void ClearAllErrorProviderIcons()
        {
            err.SetError(txtFirstName, string.Empty);
            err.SetError(txtLastName, string.Empty);
            err.SetError(txtContact, string.Empty);
            err.SetError(txtQaulification, string.Empty);
            err.SetError(txtDesignation, string.Empty);
            err.SetError(txtResAddress, string.Empty);
            err.SetError(txtReferenceName, string.Empty);
            err.SetError(txtRefContact, string.Empty);
        }
    }

} 
