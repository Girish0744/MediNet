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
    public partial class frmConsultation : Form
    {

        //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

        clsSelect selectClass = new clsSelect();
        clsInsert varInsert = new clsInsert();
        DateTimePicker sysdate = new DateTimePicker();
        double consultBills = 40; //consultation bill
        double AddBill = 0;
        ErrorProvider err = new ErrorProvider();
        public string docName;

        public frmConsultation()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            validateMedication((Control)sender);
        }

        private void frmConsultation_Load(object sender, EventArgs e)
        {
           
           // selectClass.selectDocName(comboBox1);
          
            clearAll();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectClass.ImageUpload(pictureBox1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
           

        }


        //CLEAR ALL
        void clearAll()
        {
            selectClass.selectIdForname(cboPatcode);
            cboFor.SelectedIndex = 0;
            cboPatcode.SelectedIndex = 0;
            txtDiagnose.ResetText();
            txtTreatment.ResetText();
            txtMedications.ResetText();
            pictureBox1.Image = Properties.Resources.labs;
        
        }


        //===================
        // SAVE BUTTON
        //==================
        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            validateDiagnosis(txtDiagnose);
            validateTreatment(txtTreatment);
            validateMedication(txtMedications);

            if (err.GetError(txtDiagnose).Length != 0)
            {
                err.SetError(txtDiagnose, "Please field can not be empty");
            }
            else if (err.GetError(txtTreatment).Length != 0)
            {
                err.SetError(txtTreatment, "Please field can not be empty");
            
            }
            else if (err.GetError(txtMedications).Length != 0)
            {

                err.SetError(txtMedications, "Please field can not be empty");
            }
            else
            {
                try
                {
                    UpdateBalance();
                    varInsert.insertIntoConsultation(cboPatcode, txtDocName.Text.ToString(), sysdate, sysdate, txtDiagnose.Text, txtTreatment.Text, txtMedications.Text + ", " + cboFor.SelectedItem.ToString(), pictureBox1);
                    varInsert.ItemsBills(cboPatcode.SelectedItem.ToString(),txtPatName.Text,sysdate,sysdate,"Consultation",consultBills,txtDocName.Text);
                    cboPatcode.SelectedIndex = 0;
                    selectClass.selectIdForname(cboPatcode);
                    cboFor.SelectedIndex = 0;

                    txtDiagnose.ResetText();
                    txtTreatment.ResetText();
                    txtMedications.ResetText();
                    pictureBox1.Image = Properties.Resources.labs;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void cboPatcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClass.selectname(cboPatcode.SelectedItem.ToString());
            txtPatName.Text = selectClass.fullName;
        }

        //UPdate Balance
        void UpdateBalance()
        {
            string updateBillString;
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
               
                con = new SqlConnection(varInsert.dbPath);
              

                // ADD CONSULTATION FEE WHEN IGNORE CONSULTATION FEE IS UNCHECKED

               
                if (chkNocharge.Checked == false)
                {
                   
                    try
                    {
                        selectClass.selectname(cboPatcode);
                        AddBill = consultBills + selectClass.patientBills;
                        updateBillString = "update tblPatientBill set Amts = '" + AddBill.ToString() + "' where patID = '" + cboPatcode.SelectedItem.ToString() + "'And  patName= '" + txtPatName.Text + "'";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(updateBillString, con);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("bill updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    con.Close();
                   
                }


                    //IF CHECKED
                else
                {
                    try
                    {
                    selectClass.selectname(cboPatcode);
                    AddBill = selectClass.patientBills;
                    updateBillString = "update tblPatientBill set Amts = '" + AddBill + "' where patID = '" + cboPatcode + "'And  patName= '" + txtPatName.Text + "'";
                    con.Open();
                        SqlCommand cmd = new SqlCommand(updateBillString, con);
                    
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("bill updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    con.Close();
                    
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chkNocharge_CheckedChanged(object sender, EventArgs e)
        {
           
        }


        //diagnose
        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {
            validateDiagnosis((Control)sender);
        }

        private void txtDiagnose_Leave(object sender, EventArgs e)
        {
            validateDiagnosis((Control)sender);
        }


        //TREATMENT
        private void txtTreatment_TextChanged(object sender, EventArgs e)
        {
            validateTreatment((Control)sender);
        }

        private void txtTreatment_Leave(object sender, EventArgs e)
        {
            validateTreatment((Control)sender);
        }




        //VALIDATIONS
        //DIAGNOSE
        void validateDiagnosis(Control ctrl)
        {
            if (txtDiagnose.Text.Trim() == string.Empty)
            {
                err.SetError(txtDiagnose, "Please field can not be empty");
                return;

            }
            else {

                err.SetError(txtDiagnose, string.Empty);
            }
        
        }


        //TREAT
        void validateTreatment(Control ctrl)
        {
            if (txtTreatment.Text.Trim() == string.Empty)
            {
                err.SetError(txtTreatment, "Please field can not be empty");
                return;

            }
            else
            {

                err.SetError(txtTreatment, string.Empty);
            }

        }


        //medication
         void validateMedication(Control ctrl)
        {
            if (txtMedications.Text.Trim() == string.Empty)
            {
                err.SetError(txtMedications, "Please field can not be empty");
                return;

            }
            else
            {

                err.SetError(txtMedications, string.Empty);
            }

        }

         private void txtMedications_Leave(object sender, EventArgs e)
         {
             validateMedication((Control)sender);
         }


    }
}
