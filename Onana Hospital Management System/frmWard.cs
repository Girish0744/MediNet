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
    public partial class frmWard : Form
    {
        clsSelect selectClass = new clsSelect();
        clsInsert varinsert = new clsInsert();
        // variables
       // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
        SqlDataReader reader;
        public frmWard()
        {
            InitializeComponent();
        }

        private void frmWard_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            { 
                case 0:
                    feMaleWard();
                    break;
                case 1:
                    maleWard();
                    break;

            }

        }


        //Ward name and price
        public void maleWard()
        {
            try
            {


                string sql = "select bill,NumOfPeople from tblMaleWard where maleWard = '" + comboBox1.SelectedItem.ToString() + "'";

                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                   textBox1.Text = double.Parse(reader["bill"].ToString()).ToString();
                   txtPeople.Text = double.Parse(reader["NumOfPeople"].ToString()).ToString();
                
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //=============================

        //FEMALE WARD
        public void feMaleWard()
        {
            try
            {


                string sql = "select bill,NumOfPeople from tblFemaleWard where femaleWard = '" + comboBox1.SelectedItem.ToString() + "'";

                SqlConnection con = new SqlConnection(varinsert.dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    textBox1.Text = double.Parse(reader["bill"].ToString()).ToString();
                    txtPeople.Text = double.Parse(reader["NumOfPeople"].ToString()).ToString();
                

                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            { 
                case 0:
                    updateFemale();
                    break;

                case 1:
                    updateMale();
                    break;
            
            }


           
        }

        void updateFemale()
        { 
        
            string updateBillString;
            SqlConnection con;
           // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();
                updateBillString = "update tblFemaleWard set NumOfPeople = '" + double.Parse(txtPeople.Text) + "',bill = '" + double.Parse(textBox1.Text) + "'where femaleWard = '" + comboBox1.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        void updateMale()
        {

            string updateBillString;
            SqlConnection con;
            // SqlCommand cmd;
            try
            {
                con = new SqlConnection(varinsert.dbPath);
                con.Open();
                updateBillString = "update tblMaleWard set NumOfPeople = '" + double.Parse(txtPeople.Text) + "',bill = '" + double.Parse(textBox1.Text) + "'where maleWard = '" + comboBox1.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(updateBillString, con);
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
