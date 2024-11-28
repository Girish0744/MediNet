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
    public partial class frmSupplier : Form
    {
        clsInsert varinsert = new clsInsert();
        clsSelect selectClass = new clsSelect();
        ErrorProvider err = new ErrorProvider();
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {

            clearAll();
            selectClass.callSupplierData(dataGridView1);
            label12.Text = "Total Number: " + dataGridView1.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ValidateSupName(txtSupName);
            ValidateSupContact(txtSupcontact);
            ValidateSupIncharge(txtSupPersonIncharge);
            ValidateSupPersonContact(txtSupPersonContact);
            ValidateSupAddress(txtSupAddress);

            if (err.GetError(txtSupName).Length != 0)
            {
                err.SetError(txtSupName, "Please enter a value");
            }
            else if (err.GetError(txtSupcontact).Length != 0)
            {
                err.SetError(txtSupcontact, "Please enter a numeric value of 10 digits long");
            }
            else if (err.GetError(txtSupPersonIncharge).Length != 0)
            {
                err.SetError(txtSupPersonIncharge, "Please enter a value");
           
            }

            else if (err.GetError(txtSupPersonContact).Length != 0)
            {

                err.SetError(txtSupPersonContact, "Please enter a numeric value of 10 digits long");

            }
            else if (err.GetError(txtSupAddress).Length != 0)
            {

                err.SetError(txtSupAddress, "Please enter a value");

            }

            else{
            
             varinsert.insertIntoSupplier(txtSupID.Text, txtSupName.Text, txtSupcontact.Text, cboType, txtSupPersonIncharge.Text, txtSupPersonContact.Text, cboSupCountry, txtSupEmail.Text, txtSupAddress.Text, dtpAgreementDate);
            varinsert.insertIntoGenSupplierNo(selectClass.GenSupplierNo().ToString());
            clearAll();
            ClearErrorProviderIcons();
            
            }


           
        }

        //CLEAR ALL
        void clearAll()
        {

            DateTimePicker sysDat = new DateTimePicker();
          
            txtSupID.Text = "sup-" + selectClass.GenSupplierNo().ToString();
            cboSupCountry.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            txtSupName.ResetText();
            txtSupcontact.ResetText();
            txtSupPersonIncharge.ResetText();
            txtSupPersonContact.ResetText();
            txtSupEmail.ResetText();
            txtSupAddress.ResetText();
            dtpAgreementDate.Value = sysDat.Value.Date;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectClass.callSupplierData(dataGridView1);
        }


        //TEXTBOXES VALIDATION
        void ValidateSupName(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtSupName.Text))
            {
                err.SetError(txtSupName, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSupName.Text))
            {
                err.SetError(txtSupName, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtSupName, string.Empty);
            }

        }

        void ValidateSupContact(Control ctrl)
        {
            if (txtSupcontact.Text.Trim().Length != 10)
            {
                err.SetError(txtSupcontact, "Please enter a numeric value of 10 digits long");
                return;
            }
            else 
            {
                err.SetError(txtSupcontact, string.Empty);
            }
        }

        void ValidateSupIncharge(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtSupPersonIncharge.Text))
            {
                err.SetError(txtSupPersonIncharge, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSupPersonIncharge.Text))
            {
                err.SetError(txtSupPersonIncharge, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtSupPersonIncharge, string.Empty);
            }
        
        }

        void ValidateSupPersonContact(Control ctrl)
        {
            if (txtSupPersonContact.Text.Trim().Length < 10)
            {
                err.SetError(txtSupPersonContact, "Please enter a numeric value of 10 digits long");
                return;
            }
            else
            {
                err.SetError(txtSupPersonContact, string.Empty);
            }
        }

        void ValidateSupAddress(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtSupAddress.Text))
            {
                err.SetError(txtSupAddress, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSupAddress.Text))
            {
                err.SetError(txtSupAddress, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtSupAddress, string.Empty);
            }

        }

        private void txtSupcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
         }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() != "") 
            {
          SqlConnection  con = new SqlConnection(varinsert.dbPath);
            con.Open();
                
           
            string sql =    "select* from tblSupplier where  supCode ='" + textBox1.Text.Trim() + "'";
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

        private void txtSupName_TextChanged(object sender, EventArgs e)
        {
            ValidateSupName((Control)sender);
        }

        private void txtSupName_Leave(object sender, EventArgs e)
        {
            ValidateSupName((Control)sender);
        }

        private void txtSupcontact_TextChanged(object sender, EventArgs e)
        {
            ValidateSupContact((Control)sender);
        }

        private void txtSupcontact_Leave(object sender, EventArgs e)
        {
            ValidateSupContact((Control)sender);
        }

        private void txtSupPersonIncharge_TextChanged(object sender, EventArgs e)
        {
            ValidateSupIncharge((Control)sender);
        }

        private void txtSupPersonIncharge_Leave(object sender, EventArgs e)
        {
            ValidateSupIncharge((Control)sender);
        }

        private void txtSupPersonContact_TextChanged(object sender, EventArgs e)
        {
            ValidateSupPersonContact((Control)sender);
        }

        private void txtSupPersonContact_Leave(object sender, EventArgs e)
        {
            ValidateSupPersonContact((Control)sender);
        }

        private void txtSupAddress_TextChanged(object sender, EventArgs e)
        {
            ValidateSupAddress((Control)sender);
        }

        private void txtSupAddress_Leave(object sender, EventArgs e)
        {
            ValidateSupAddress((Control)sender);
        }

        private void txtSupPersonContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber;
            e.Handled = !int.TryParse(e.KeyChar.ToString(),out isNumber);
           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        //DESTROY ERROR PROVIDER AFTER USAGE
        void ClearErrorProviderIcons()
        {
            err.SetError(txtSupName, string.Empty);
            err.SetError(txtSupcontact, string.Empty);
            err.SetError(txtSupPersonIncharge, string.Empty);
            err.SetError(txtSupPersonContact, string.Empty);
            err.SetError(txtSupAddress, string.Empty);
        
        }
            
        }
    }

