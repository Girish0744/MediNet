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
    public partial class frmLogin : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        public  string myName;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            clsSelect selectClass = new clsSelect();
            selectClass.myUser = txtUsername.Text;
            LogsUser = txtUsername.Text.Trim();

           Logins(txtUsername.Text, txtPassword.Text, comboBox1);
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5000, "Acknowledgement", "A product from Wisdom Agbenu", ToolTipIcon.Info);
        
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(sender, e);
        }


        //LOGIN
         void Logins(string Usernames, string Password, ComboBox comLevel)
        {
            try
            {
                 SqlConnection con = new SqlConnection( varinsert.dbPath);

                string sql = "select empCode, Uname,Pwd, Levels from Users where Uname = @Uname and Pwd = @Pwd and Levels = @Levels";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Uname", Usernames.Trim());
                cmd.Parameters.AddWithValue("@Pwd", Password.Trim());
                cmd.Parameters.AddWithValue("@Levels", comLevel.SelectedItem.ToString());

                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;

                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                   
                    frmParent fm = new frmParent();
                    this.Hide();                    
                    fm.getEmpCodes.Text = Usernames;
                   // fm.administratorsToolStripMenuItem.Enabled = false;

                    //COMBOX SELECTED IS ADMINISTRATOR
                    if (comboBox1.SelectedIndex == 0)
                    {
                        //fm.pharmacistToolStripMenuItem.Enabled = false;
                        //fm.doctorToolStripMenuItem.Enabled = false;
                        //fm.nurseYardToolStripMenuItem.Enabled = false;

                    }

                         //COMBOX SELECTED IS CASHIER
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        fm.administratorsToolStripMenuItem.Enabled = false;
                        fm.doctorToolStripMenuItem.Enabled = false;
                        fm.nurseYardToolStripMenuItem.Enabled = false;
                        fm.pharmacistToolStripMenuItem.Enabled = false;
                    }


                        //COMBOX SELECTED IS DOCTOR
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        fm.administratorsToolStripMenuItem.Enabled = false;
                        fm.cashierToolStripMenuItem.Enabled = false;
                    }

                        //COMBOX SELECTED IS NURSE
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        fm.administratorsToolStripMenuItem.Enabled = false;
                        fm.doctorToolStripMenuItem.Enabled = false;
                        fm.pharmacistToolStripMenuItem.Enabled = false;
                        fm.cashierToolStripMenuItem.Enabled = false;
                    }

                            //COMBOX SELECTED IS PHARMACIST
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        fm.administratorsToolStripMenuItem.Enabled = false;
                        fm.doctorToolStripMenuItem.Enabled = false;
                        fm.cashierToolStripMenuItem.Enabled = false;
                    }

                   

                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password or Privilege", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            catch (Exception ex)
            {

            }


            

        }

        public string LogsUser { get; set; }

           }
}
