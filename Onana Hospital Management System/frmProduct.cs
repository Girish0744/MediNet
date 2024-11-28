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
    public partial class frmProduct : Form
    {
        clsInsert varinsert = new clsInsert();
       clsUpdate theUpdates = new clsUpdate();
        DateTimePicker sysdate = new DateTimePicker();
        clsSelect selectClass = new clsSelect();
        DateTimePicker dt = new DateTimePicker();
        ErrorProvider err = new ErrorProvider();
        public string empName;
        public frmProduct()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            clearAll();
            selectClass.viewPatient(dataGridView2);
            selectClass.GetSuppliers(cboSuppliedBy);
            selectClass.GetSuppliers(cboUpSuppliedBy);
            selectClass.SelectDrugName(cboLoadDrug);
            textBox4.Text = "1";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            validateItemName(txtItemName);
            validateItemPrice(txtItemPrice);
            validateItemQty(txtItemQty);

            validateItemDetails(itemDetails);
            validateItemLoc(txtItemLocation);

               if(err.GetError(txtItemName).Length !=0) 
               {
                   err.SetError(txtItemName, "Please enter a value");
                   return;
                }
               else if(err.GetError(txtItemPrice).Length !=0)
               {
                   err.SetError(txtItemPrice, "Please enter price");
                   return;
               }
               else if (err.GetError(txtItemQty).Length != 0)
               {
                   err.SetError(txtItemQty, "Please enter quantity");
                   return;
               }
               else if (err.GetError(itemDetails).Length != 0)
               {
                   err.SetError(itemDetails, "Please enter a value");
                   return;
               }
               else if (err.GetError(txtItemLocation).Length != 0)
               {
                   err.SetError(txtItemLocation, "Please enter a item Loaction");
                   return;
               }
               else
               {

                   if (dtpManuDate.Value.Date > dtpExpiryDate.Value.Date)
                   {
                       MessageBox.Show("Item is Expire", "Expire Product - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   
                   }
                  // varinsert.insertIntoProduct(txtItemName.Text, cboSuppliedBy, txtItemLocation.Text, Double.Parse(txtItemPrice.Text), int.Parse(txtItemQty.Text), dtpManuDate, dtpExpiryDate, itemDetails.Text);

                   varinsert.insertIntoProduct(txtItemName.Text.Trim(),cboSuppliedBy.SelectedItem.ToString(),txtItemLocation.Text.Trim(),double.Parse(txtItemPrice.Text),int.Parse(txtItemQty.Text),dtpManuDate,dtpExpiryDate,itemDetails.Text.Trim());
                   txtItemName.ResetText();
                    itemDetails.ResetText();
                    txtItemPrice.ResetText();
                    txtItemQty.ResetText();
                    txtItemLocation.ResetText();
                    dtpExpiryDate.ResetText();
                    dtpManuDate.ResetText();
            }
        }

        void clearAll()
        {

            selectClass.callProductData(dataGridView1);
           
            txtItemName.ResetText();
            itemDetails.ResetText();
            txtItemPrice.ResetText();
            txtItemQty.ResetText();
            txtItemLocation.ResetText();
            dtpExpiryDate.ResetText();
            dtpManuDate.ResetText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUpProID.Text.Trim().Length > 0)
            {
                updateProduct();
                ClearAlluPDATE();
            }
            else
            {
                MessageBox.Show("Item Number", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
            {
                e.Handled = true;
            }
            else if (!txtItemPrice.Text.Contains("."))
            {
                txtItemPrice.Text += ".";
            
            }
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            

        }

        private void dtpUpmanDate_ValueChanged(object sender, EventArgs e)
        {
          
           
        }

        private void dtpUpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtUpMandate_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            selectClass.callProductData(dataGridView1);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtPatID.Text = (0, dataGridView2.CurrentRow.Index).Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            frmMedication md = new frmMedication();
            if (checkBox1.Checked == true)
            {
                selectClass.selectPatMedication(this.txtPatID.Text);
               md.textBox1.Text = selectClass.Treatment + Environment.NewLine + selectClass.Medication;
                md.Show();
            }
           
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if ((txtPatID.Text.Length != 0) && (textBox1.Text.Length != 0))
            {
                ProcessInput();
            }
            else
            {

                MessageBox.Show("Invalid Patient ID", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //if (textBox5.Text.Trim().Length > 0)
            //{
            //    selectClass.SelectDrug(textBox5.Text.Trim());
            //    textBox6.Text = selectClass.DrugPrice.ToString();
            
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double Price = (int.Parse(textBox4.Text) * double.Parse(textBox6.Text));
                textBox2.Text = Price.ToString();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double Price = (int.Parse(textBox4.Text) * double.Parse(textBox6.Text));
                textBox2.Text = Price.ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumbers;

            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumbers);

        }

        private void txtPatID_TextChanged(object sender, EventArgs e)
        {
            selectClass.selectname(txtPatID.Text.Trim());
            textBox1.Text = selectClass.fullName;
        }

        //UPdate Balance
        void UpdateBalance()
        {
            string updateBillString;
            SqlConnection con;

            selectClass.selectPatDetailsFromBill(txtPatID.Text);
            double PatBills = selectClass.PatBill;
            double PatCurBalance = PatBills + double.Parse(textBox2.Text);

            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();
                updateBillString = "update tblPatientBill set Amts = '" + PatCurBalance + "' where patID = '" + txtPatID.Text + "'And  patName= '" + textBox1.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Payment updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //SAVE AND UPDATE
        void ProcessInput()
        {

            int proQty = int.Parse(getQty.Text) - int.Parse(textBox4.Text);

            if (proQty < 0)
            { 
                 MessageBox.Show("Qty instock is less qty requested", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
            }

             theUpdates.UpdateProductQty(cboLoadDrug.SelectedItem.ToString(), proQty); //update product qty

             UpdateBalance();
             varinsert.ItemsBills(txtPatID.Text.Trim(), textBox1.Text.Trim(), sysdate, sysdate, cboLoadDrug.SelectedItem.ToString(), double.Parse(textBox2.Text), empName);
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        { 
            if (txtUpProID.Text.Trim().Length > 0)
            {
                
            theUpdates.deletingDrugByID(int.Parse(txtUpProID.Text.Trim()));
            txtUpProID.ResetText();
            txtUpItemNAme.ResetText();
            cboUpSuppliedBy.ResetText();
            txtUpItemPrice.ResetText();
            txtUpQty.ResetText();
            txtUpDetails.ResetText();
            dtpUpmanDate.Text = dt.Value.Date.ToString();
            txtUpLocation.ResetText();
            dtpUpExpiryDate.Text = dt.Value.Date.ToString();

            }
            else
            {
                MessageBox.Show("Item Number", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ClearAlluPDATE();


        }

        //update product
        void updateProduct()
        {

            try
            {

                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "update tblProduct  set proName=@proName, proSupplier=@proSupplier,proLocation=@proLocation, proPrice=@proPrice, proQty=@proQty , proManuDate=@proManuDate, proExpiry=@proExpiry, proDescription=@proDescription where proCode='" +int.Parse( txtUpProID.Text) + "'";
                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@proName", txtUpItemNAme.Text.Trim());
                cmd.Parameters.AddWithValue("@proSupplier", cboUpSuppliedBy.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@proLocation", txtUpLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@proPrice",double.Parse(txtUpItemPrice.Text));
                cmd.Parameters.AddWithValue("@proQty ", int.Parse(txtUpQty.Text));
                cmd.Parameters.AddWithValue("@proManuDate", dtpUpmanDate.Value.Date);
                cmd.Parameters.AddWithValue("@proExpiry", dtpUpExpiryDate.Value.Date);
                cmd.Parameters.AddWithValue("proDescription", txtUpDetails.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product updated successfully ", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cboLoadDrug_SelectedIndexChanged(object sender, EventArgs e)
        {
           // selectClass.SelectDrug(textBox5.Text.Trim());
            selectClass.SelectDrug(cboLoadDrug.SelectedItem.ToString());
            textBox6.Text = selectClass.DrugPrice.ToString();
            selectClass.selectDrugQty(cboLoadDrug.SelectedItem.ToString());
            getQty.Text = selectClass.drugQty.ToString();
        }

        private void dtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {

        }
   

        //validate

        void validateItemName(Control ctrl)
        {
            if (txtItemName.Text.Trim().Length > 0)
            {
               err.SetError(txtItemName, string.Empty);
            }
            else
            {
                err.SetError(txtItemName, "Please enter a value");
                return;
            
            }
        }

        void validateItemPrice(Control ctrl)
        {
            if (txtItemPrice.Text.Trim().Length > 0)
            {
               err.SetError(txtItemPrice, string.Empty);
            }
            else
            {
                err.SetError(txtItemPrice, "Please enter price");
                return;
            }
        }

        void validateItemQty(Control ctrl)
        {
            if (txtItemQty.Text.Trim().Length > 0)
            {
                 err.SetError(txtItemQty, string.Empty);
            }
            else
            {
                err.SetError(txtItemQty, "Please enter quantity");
                return;
            }
        }

        void validateItemDetails(Control ctrl)
        {
            if (itemDetails.Text.Trim().Length > 0)
            {
                 err.SetError(itemDetails, string.Empty);
            }
            else
            {
               
                err.SetError(itemDetails, "Please enter a value");
                return;
            }
        }

        void validateItemLoc(Control ctrl)
        {
            if (txtItemLocation.Text.Trim().Length > 0)
            {
                err.SetError(txtItemLocation, string.Empty);
               
            }
            else
            {
                
                err.SetError(txtItemLocation, "Please enter a item Loaction");
                return;
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            validateItemName((Control)sender);
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            validateItemName((Control)sender);
        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            validateItemPrice((Control)sender);
        }

        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            validateItemPrice((Control)sender);
        }

        private void txtItemQty_TextChanged(object sender, EventArgs e)
        {
            validateItemQty((Control)sender);
        }

        private void txtItemQty_Leave(object sender, EventArgs e)
        {
            validateItemQty((Control)sender);
        }

        private void itemDetails_TextChanged(object sender, EventArgs e)
        {
            validateItemDetails((Control)sender);
        }

        private void itemDetails_Leave(object sender, EventArgs e)
        {
            validateItemDetails((Control)sender);
        }

        private void txtItemLocation_TextChanged(object sender, EventArgs e)
        {
            validateItemLoc((Control)sender);
        }

        private void txtItemLocation_Leave(object sender, EventArgs e)
        {
            validateItemLoc((Control)sender);
        }

        private void txtUpProID_Leave(object sender, EventArgs e)
        {

        }

        private void txtUpProID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNum;
            e.Handled = !int.TryParse(e.KeyChar.ToString(),out isNum);
        }

        private void txtUpProID_TextChanged(object sender, EventArgs e)
        {
            if (txtUpProID.Text.Trim().Length > 0)
            {
                selectClass.getProductDetails(Convert.ToInt16(txtUpProID.Text));
                txtUpItemNAme.Text = selectClass.prosName;
                cboUpSuppliedBy.Text = selectClass.prosSuppliedBy;
                txtUpItemPrice.Text = selectClass.prosPrice;
                txtUpQty.Text = selectClass.prosQty;
                txtUpDetails.Text = selectClass.prosDetails;
                dtpUpmanDate.Text = selectClass.prosManDate;
                txtUpLocation.Text = selectClass.prosLocation;
                dtpExpiryDate.Text = selectClass.prosExpiryDate;

            }
            else
            {
                ClearAlluPDATE();
            }
        }


        //SET CONTROLS TO FORMER STATE
        void ClearAlluPDATE()
        {
            txtUpProID.Text = string.Empty;
            txtUpItemNAme.Text = string.Empty;
            cboUpSuppliedBy.SelectedIndex = 0;
            txtUpItemPrice.Text = null;
            txtUpQty.Text = null;
            txtUpDetails.Text = string.Empty;
            dtpUpmanDate.Text = sysdate.Value.Date.ToString();
            txtUpLocation.Text = null;
            dtpExpiryDate.Text = sysdate.Value.Date.ToString();
        
        
        }

      
    }
}
