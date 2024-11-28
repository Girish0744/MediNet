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
    public partial class frmPayments : Form
    {
        clsSelect selectClass = new clsSelect();
        double custChange;
        clsInsert varinsert = new clsInsert();
        public string cachierName;
        //SqlConnection con;
        //SqlCommand cmd;
        DateTimePicker sysDate = new DateTimePicker();
     // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

        public frmPayments()
        {
            InitializeComponent();
        }


        void ClearAll()
        {
            txtReceipt.Text = "eco-" + selectClass.GenReceiptNo().ToString();
            txtBalance.ResetText();
            txtPatID.ResetText();
            txtPatName.ResetText();
            txtPay.ResetText();
            txtAmt.ResetText();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPatID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatID.Text.Trim() != "")
            {
                if (txtPatID.Text.Length >= 4)
                {
                    selectClass.selectPatDetailsFromBill(txtPatID.Text);
                    txtPatName.Text = selectClass.fullName;
                    txtAmt.Text = selectClass.PatBill.ToString();
                
                }
            
            }
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text == "E")
            {
                MessageBox.Show("Invalid transaction");
                    return;
            }
            else
            { 
            calcPatientBill();
            
            }
            
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {

        }

        // CONTINUE TO SUBTRACT
        private void txtPay_TextChanged(object sender, EventArgs e)
        {
          double payVal;
            if (txtPay.Text != "")
            {
                if (double.TryParse(txtPay.Text, out payVal))
                {
                    txtBalance.Text = (double.Parse(txtAmt.Text) - payVal).ToString();

                }

                    //IF INPUT IS NOT A NUMBER
                else {
                    txtBalance.Text = "E";
                }
            
            }
        }


        //PROCESS PAYMENT
        void calcPatientBill()
        {

            try
            {
                if (txtPatID.Text.Trim() != "")
                {
                    if (txtAmt.Text == "0")
                    {
                        txtBalance.Text = "0";

                        MessageBox.Show("Patient owes nothing", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (double.Parse(txtBalance.Text) < 0.00)
                        {
                            custChange = double.Parse(txtPay.Text) - double.Parse(txtAmt.Text);
                            txtBalance.Text = 0.ToString();
                            if (MessageBox.Show("Do you want to continue with the transaction" + Environment.NewLine + "Change of : " + "GH₵ " + custChange, "CONFIRM TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                UpdateBalance();
                                varinsert.insertIntoDailyTransaction(txtReceipt.Text, txtPatID.Text, txtPatName.Text, sysDate, sysDate, double.Parse(txtPay.Text), double.Parse(txtBalance.Text), cachierName);

                                varinsert.insertIntoGenReceiptNo(selectClass.GenReceiptNo().ToString());

                                printDocument1.Print();
                                txtReceipt.Text = "eco-" + selectClass.GenReceiptNo().ToString();
                                ClearAll();
                            }
                        }
                        else if (double.Parse(txtBalance.Text) >= 0.00)
                        {

                            if (MessageBox.Show("Do you want to continue with the transaction", "CONFIRM TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                UpdateBalance();
                                varinsert.insertIntoDailyTransaction(txtReceipt.Text, txtPatID.Text, txtPatName.Text, sysDate, sysDate, double.Parse(txtPay.Text), double.Parse(txtBalance.Text), cachierName);
                                varinsert.insertIntoGenReceiptNo(selectClass.GenReceiptNo().ToString());

                                printDocument1.Print();
                                txtReceipt.Text = "eco-" + selectClass.GenReceiptNo().ToString();
                                ClearAll();
                            }
                        }


                    }




                }
            }
            catch(Exception ex)
            {
            }
        }

          //UPdate Balance
        void UpdateBalance()
        {
            string updateBillString;
            SqlConnection con;
           // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();
                updateBillString = "update tblPatientBill set Amts = '" + double.Parse(txtBalance.Text) + "' where patID = '" + txtPatID.Text + "'And  patName= '" + txtPatName.Text + "'";
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            
           Font pfont;
           DateTime Mydate = new DateTime();
       int StartXpos  = 0;
       int  StartYpos= 0;
        int  offset = 40;
            Mydate = DateTime.Now;
       
        pfont = new Font("Comic Sans MS", 9);
        e.Graphics.DrawString("ONANA HOSPITAL MANAGEMENT SYSTEM" + Environment.NewLine, pfont, Brushes.Black, StartXpos, StartYpos);
        e.Graphics.DrawString("P.O.BOX 1 EAST-LEGON, Tel: 030 552 2221-1" + Environment.NewLine, new Font("Comic Sans MS", 9), Brushes.Black, 0, 30);
        e.Graphics.DrawString(Mydate.ToString("F") + Environment.NewLine, new Font("Comic Sans MS", 9), Brushes.Black, 0, 50);

        e.Graphics.DrawString("Reciept No.: " + txtReceipt.Text.PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 70 + offset);

        e.Graphics.DrawString("Patient Name  : " + txtPatName.Text.PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 90 + offset);

        e.Graphics.DrawString("Patient ID : " + txtPatID.Text.PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 110 + offset);

        e.Graphics.DrawString("Amount Owed (GH₵)  : " + txtAmt.Text, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 130 + offset);

        e.Graphics.DrawString("Amount Payed (GH₵) : " + txtPay.Text.PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 150 + offset);
        e.Graphics.DrawString("Change (GH₵): " + custChange.ToString().PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 170 + offset);

        e.Graphics.DrawString("Outstanding Balance (GH₵) : " + txtBalance.Text.PadRight(30) + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 190 + offset);
       
            e.Graphics.DrawString("Thank you for your visit. Wish you good health, you were served by " + cachierName + Environment.NewLine, new Font("Comic Sans MS", 9), new SolidBrush(Color.Black), 0, 210 + offset);

        }

    }
}
