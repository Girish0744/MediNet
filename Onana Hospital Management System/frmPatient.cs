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
    public partial class frmPatient : Form
    {
        clsSelect selectCalss =  new clsSelect();
        clsInsert varinsert = new clsInsert();
        DateTimePicker sysDate = new DateTimePicker();
        const double folderBill = 15.00;
        ErrorProvider err = new ErrorProvider();
        public string nurseName;
      
        public frmPatient()
        {
            InitializeComponent();
        }

        //clear
        void clearAll()
        {
            txtPatCode.Text = "Pat-" + selectCalss.callGenPatientNo();
            cboGender.SelectedIndex = 0;
            cboNationality.SelectedIndex = 0;
            txtLastName.ResetText();
            txtOname.ResetText();
            txtFirstName.ResetText();
            txtAge.ResetText();
            dtpdob.ResetText();
            txtOccupation.ResetText();
            txtContact.ResetText();
            txtResAddress.ResetText();
            txtEmail.ResetText();
            txtGuardFname.ResetText();
            txtGuardLastName.ResetText();
            txtGContact.ResetText();
            txtRelates.ResetText();
            dtpSysDate.ResetText();
            pictureBox1.Image = Properties.Resources.index;
        
        }


        private void frmPatient_Load(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectCalss.ImageUpload(pictureBox1);
        }

        private void txtPatCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)

        {

            validateLastName(txtLastName);
            validateFirstName(txtFirstName);
            validateContact(txtContact) ;
            validateOccupation(txtOccupation);
            validateResAddress(txtResAddress);
            validateGuardianFname(txtGuardFname);
            validateGuardianLname(txtGuardLastName);
            validateGuadianContact(txtGContact);
            validateRelateAs(txtRelates);


            string guardFullName = txtGuardFname.Text.Trim() + " " + txtGuardLastName.Text.Trim();

            if (err.GetError(txtLastName).Length !=0)  {
                err.SetError(txtLastName, "Please enter a value");
               }
            else if (err.GetError(txtFirstName).Length !=0) {
                err.SetError(txtLastName, "Please enter a value");
             }
            else if (err.GetError(txtContact).Length !=0) {
                err.SetError(txtContact, "Please enter a numeric value of 10 digits long");
                 }
            else if (err.GetError(txtOccupation).Length !=0) {
                err.SetError(txtOccupation, "Please enter a value");
                  }
          else if(err.GetError(txtResAddress).Length !=0) 
                 {

                err.SetError(txtResAddress, "Please enter a value");
              }

            else if(err.GetError(txtGuardFname).Length !=0){

                err.SetError(txtGuardFname, "Please enter a value");  
            }

            else if (err.GetError(txtGuardLastName).Length !=0){
                err.SetError(txtGuardLastName, "Please enter a value");
            
            }
            else if(err.GetError(txtGContact).Length !=0){
                err.SetError(txtGContact, "Please enter a numeric value of 10 digits long");
            
            }

            else if(err.GetError(txtRelates).Length !=0)
            {
                err.SetError(txtRelates, "Please enter a value");
            }
            else{
                string fullName = txtLastName.Text + " " + txtFirstName.Text + " " + txtOname.Text;
                varinsert.ItemsBills(txtPatCode.Text, fullName, sysDate, sysDate, "Folder Bill", folderBill, nurseName);
                varinsert.tblpatientBill(txtPatCode.Text, fullName, folderBill);
                varinsert.insertToPatient(txtPatCode.Text, txtLastName.Text, txtFirstName.Text, txtOname.Text, cboGender, txtOccupation.Text, dtpdob, txtResAddress.Text, cboNationality, txtContact.Text, txtEmail.Text, dtpSysDate, dtpSysDate, guardFullName, txtGContact.Text, txtRelates.Text, pictureBox1);
                varinsert.insertIntoGenPatientNo(selectCalss.callGenPatientNo().ToString());
                clearAll();
                ClearErrorProvider();
            }

        }

        private void txtGContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);

        }

        private void dtpdob_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker sysDat = new DateTimePicker();
            sysDat.Value = System.DateTime.Now;
            txtAge.Text = (sysDat.Value.Year - dtpdob.Value.Year).ToString();
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

        void validateOccupation(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtOccupation.Text))
            {
                err.SetError(txtOccupation, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtOccupation.Text))
            {
                err.SetError(txtOccupation, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtOccupation, string.Empty);
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

        void validateGuardianFname(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtGuardFname.Text))
            {
                err.SetError(txtGuardFname, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtGuardFname.Text))
            {
                err.SetError(txtGuardFname, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtGuardFname, string.Empty);
            }
        }


        void validateGuardianLname(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtGuardLastName.Text))
            {
                err.SetError(txtGuardLastName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtGuardLastName.Text))
            {
                err.SetError(txtGuardLastName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtGuardLastName, string.Empty);
            }
        }

        void validateGuadianContact(Control ctrl)
        {
            if (txtGContact.Text.Trim().Length != 10)
            {
                err.SetError(txtGContact, "Please enter a numeric value of 10 digits long");
                return;
            }
            else
            {
                err.SetError(txtGContact, string.Empty);
            }
        }

        void validateRelateAs(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtRelates.Text))
            {
                err.SetError(txtRelates, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtRelates.Text))
            {
                err.SetError(txtRelates, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtRelates, string.Empty);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            validateFirstName((Control)sender);
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            validateFirstName((Control)sender);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            validateLastName((Control)sender);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            validateLastName((Control)sender);
        }

        private void txtOccupation_TextChanged(object sender, EventArgs e)
        {
            validateOccupation((Control)sender);
        }

        private void txtOccupation_Leave(object sender, EventArgs e)
        {
            validateOccupation((Control)sender);
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            validateContact((Control)sender);
        }

        private void txtResAddress_TextChanged(object sender, EventArgs e)
        {
            validateResAddress((Control)sender);
        }

        private void txtResAddress_Leave(object sender, EventArgs e)
        {
            validateResAddress((Control)sender);
        }

        private void txtGuardFname_TextChanged(object sender, EventArgs e)
        {
            validateGuardianFname((Control)sender);
        }

        private void txtGuardFname_Leave(object sender, EventArgs e)
        {
            validateGuardianFname((Control)sender);
        }

        private void txtGuardLastName_TextChanged(object sender, EventArgs e)
        {
            validateGuardianLname((Control)sender);
        }

        private void txtGuardLastName_Leave(object sender, EventArgs e)
        {
            validateGuardianLname((Control)sender);
        }

        private void txtGContact_TextChanged(object sender, EventArgs e)
        {
            validateGuadianContact((Control)sender);
        }

        private void txtGContact_Leave(object sender, EventArgs e)
        {
            validateGuadianContact((Control)sender);
        }

        private void txtRelates_TextChanged(object sender, EventArgs e)
        {
            validateRelateAs((Control)sender);
        }

        private void txtRelates_Leave(object sender, EventArgs e)
        {
            validateRelateAs((Control)sender);
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }


        //DESTROY ERROR PROVIDER ICONS AFTER SAVING
        void ClearErrorProvider()
        {
            err.SetError(txtFirstName, string.Empty);
            err.SetError(txtLastName, string.Empty);
            err.SetError(txtOccupation, string.Empty);
            err.SetError(txtContact, string.Empty);
            err.SetError(txtResAddress, string.Empty);
            err.SetError(txtGuardFname, string.Empty);
            err.SetError(txtGuardLastName, string.Empty);
            err.SetError(txtGContact, string.Empty);
            err.SetError(txtRelates, string.Empty);
        }

    }
}
