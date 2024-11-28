using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onana_Hospital_Management_System
{
    public partial class frmNurseTest : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        DateTimePicker sysdate = new DateTimePicker();

        public frmNurseTest()
        {
            InitializeComponent();
        }

        private void txtPatID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           selectClass.selectImage(txtPatID.Text.Trim(), pictImage);
           selectClass.selectname(txtPatID.Text.Trim());
            txtPatName.Text = selectClass.fullName;
        }

        private void frmDiagnose_Load(object sender, EventArgs e)
        {
            relay();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPatName_TextChanged(object sender, EventArgs e)
        {
            relay();
        }

        private void txtpatBMI_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double Height, Weight;
         
            if (checkBox1.Checked)
            {
                if (double.TryParse(txtPatHeight.Text, out Height) == true && double.TryParse(txtPatWeight.Text, out Weight) == true)
                {
                    txtpatBMI.Text = string.Format("{0:n2}", selectClass.calBMI(Convert.ToDouble(txtPatHeight.Text), Convert.ToDouble(txtPatWeight.Text)).ToString());

                }
                else
                {
                    checkBox1.CheckState = 0;
                    MessageBox.Show("Either Height or Weight value is not numeric" + Environment.NewLine + "Please check the values", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }


                    
            }
            else if(!checkBox1.Checked){
                txtpatBMI.Text = "";

            }
            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatID.Text.Trim() == string.Empty || txtPatName.Text.Trim() == string.Empty || txtPatHeight.Text.Trim() == string.Empty || txtPatWeight.Text.Trim() == string.Empty || txtpatPressure.Text.Trim() == string.Empty || txtPatTemperature.Text.Trim() == string.Empty || checkBox1.Checked == false)
            {
                MessageBox.Show("Please fill all fields and make sure Compute BMI is checked", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
                 }

            varinsert.insertIntoPatientWeight(txtPatID.Text, txtPatName.Text, double.Parse(txtpatBMI.Text), txtpatPressure.Text, double.Parse(txtPatTemperature.Text), sysdate, sysdate);
            relay();
            txtPatName.Text = "";
            txtpatBMI.Text = "";
            checkBox1.Checked = false;
            txtPatID.Text = "";
            pictImage.Image = Properties.Resources.index;
        }

        //INITIATE
        void relay()
        {
            txtPatHeight.Text = "";
            txtPatWeight.Text = "";
            txtpatPressure.Text = "";
            txtPatTemperature.Text = "";

            if (txtPatName.Text.Length > 0)
            {
                txtPatHeight.ReadOnly = false;
                txtPatWeight.ReadOnly = false;
                txtpatPressure.ReadOnly = false;
                txtPatTemperature.ReadOnly = false;
            }
            else
            {
                txtPatHeight.ReadOnly = true;
                txtPatWeight.ReadOnly = true;
                txtpatPressure.ReadOnly = true;
                txtPatTemperature.ReadOnly = true;

            }
        
        }

        private void txtPatTemperature_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPatHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isnumber;
            //e.Handled = !int.TryParse(e.KeyChar.ToString(), out isnumber);
        }

        private void txtPatWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isnumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isnumber);
        }

        private void txtpatPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPatTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
