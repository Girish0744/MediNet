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
    public partial class frmUpdatePatient : Form
    {
        clsInsert varinsert = new clsInsert();
        clsSelect selectClass = new clsSelect();
        ErrorProvider err = new ErrorProvider();
        public frmUpdatePatient()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            validateLastName((Control)sender);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             validateLastName(txtLastName);
            validateFirstName(txtFirstName);
            validateContact(txtContact) ;
            validateOccupation(txtOccupation);
            validateResAddress(txtResAddress);
            validateGuardianFname(txtGuardFname);
           
            validateGuadianContact(txtGContact);
            validateRelateAs(txtRelates);


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

            else if(err.GetError(txtGContact).Length !=0){
                err.SetError(txtGContact, "Please enter a numeric value of 10 digits long");
            
            }

            else if (err.GetError(txtRelates).Length != 0)
            {
                err.SetError(txtRelates, "Please enter a value");
            }
            else
            {

                if (txtPatCode.Text.Length > 0)
                {
                    updatePatient(txtLastName.Text.Trim(), txtFirstName.Text.Trim(), txtOname.Text.Trim(), cboGender, txtOccupation.Text, dtpdob, txtResAddress.Text, cboNationality, txtContact.Text, txtEmail.Text, txtGuardFname.Text.Trim(), txtGContact.Text, txtRelates.Text, pictureBox1);
                    ClearErrorProvider();
                }
                else
                {
                    MessageBox.Show("Please enter enter patient id");
                }

            }
        }


         void updatePatient(string pSname, string pFname, string pOname, ComboBox pGender, string pOccupation, DateTimePicker pDOB, string pResidenAddres, ComboBox pNationality, string pContact, string pEmail,string pGuardianName, string pGuardianPhone, string pGuardianRelateAs, PictureBox pPhoto)
       
        
        {

            string updateBillString;
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();

                updateBillString = "update tblPatient set pSname =@pSname,pFname =@pFname, pOname =@pOname,pGender=@pGender ,pOccupation=@pOccupation, pDOB=@pDOB ,pResidenAddres =@pResidenAddres, pNationality=@pNationality , pContact=@pContact,pEmail = @pEmail, pGuardianName=@pGuardianName, pGuardianPhone=@pGuardianPhone ,pGuardianRelateAs =@pGuardianRelateAs, pPhoto=@pPhoto  where patID = '" + txtPatCode.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    cmd.Parameters.AddWithValue("@pSname", pSname.Trim());
                    cmd.Parameters.AddWithValue("@pFname", pFname.Trim());
                    cmd.Parameters.AddWithValue("@pOname",pOname.Trim());
                    cmd.Parameters.AddWithValue("@pGender", pGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@pOccupation", pOccupation.Trim());
                    cmd.Parameters.AddWithValue("@pDOB", pDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@pResidenAddres", pResidenAddres.Trim());
                    cmd.Parameters.AddWithValue("@pNationality", pNationality.SelectedItem);
                    cmd.Parameters.AddWithValue("@pContact", pContact.Trim());
                    cmd.Parameters.AddWithValue("@pEmail", pEmail.Trim());
                    cmd.Parameters.AddWithValue("@pGuardianName", pGuardianName.Trim());
                    cmd.Parameters.AddWithValue("@pGuardianPhone", pGuardianPhone.Trim());
                    cmd.Parameters.AddWithValue("@pGuardianRelateAs", pGuardianRelateAs.Trim());


                    MemoryStream pp = new MemoryStream();
                    pPhoto.Image.Save(pp, pPhoto.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    SqlParameter ppic = new SqlParameter("pPhoto", System.Data.SqlDbType.Image);
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

      

    //GET PATIENT NAME
        public void selectPatDetails()
        {

            try
            {

                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";


                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select pSname,pFname,pOname,pGender,pOccupation,pDOB,pResidenAddres,pNationality,pContact,pEmail,pGuardianName,pGuardianPhone,pGuardianRelateAs,pPhoto from tblPatient where patID = '" + txtPatCode.Text.Trim() + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtLastName.Text = reader["pSname"].ToString();
                    txtFirstName.Text = reader["pFname"].ToString();
                    txtOname.Text = reader["pOname"].ToString();
                    cboGender.SelectedItem = reader["pGender"].ToString();
                    txtOccupation.Text = reader["pOccupation"].ToString();
                    dtpdob.Text = reader["pDOB"].ToString();
                    txtResAddress.Text = reader["pResidenAddres"].ToString();
                    cboNationality.SelectedItem = reader["pNationality"].ToString();
                   txtContact.Text =  reader["pContact"].ToString();
                    txtEmail.Text = reader["pEmail"].ToString();
                     txtGuardFname.Text  =    reader["pGuardianName"].ToString();
                   txtGContact.Text =  reader["pGuardianPhone"].ToString();
                  txtRelates.Text =   reader["pGuardianRelateAs"].ToString();

                      MemoryStream ms = new MemoryStream((byte[])reader["pPhoto"]);
                    pictureBox1.Image = new Bitmap(ms);
                }
                else
                {
                    
                    txtLastName.Text = "";
                    txtFirstName.Text = "";
                    txtOname.Text ="";
                    cboGender.SelectedIndex = 0;
                    txtOccupation.Text ="";
                    txtResAddress.Text ="";
                    cboNationality.SelectedIndex = 0;
                    txtContact.Text = "";
                    txtEmail.Text ="";
                    txtGuardFname.Text  =  "";
                    txtGContact.Text = "";
                    txtRelates.Text =  "";
                    pictureBox1.Image = Properties.Resources.index;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        

        private void frmUpdatePatient_Load(object sender, EventArgs e)
        {
            cboGender.SelectedIndex = 0;
            cboNationality.SelectedIndex = 0;
        }

        private void txtPatCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPatCode.Text.Trim().Length > 0)
            {
                selectPatDetails();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectClass.ImageUpload(pictureBox1);
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

        private void txtGContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(),out isNumber);
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
            err.SetError(txtGContact, string.Empty);
            err.SetError(txtRelates, string.Empty);
        }
        
        }
    }

