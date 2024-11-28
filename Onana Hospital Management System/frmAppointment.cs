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
    public partial class frmAppointment : Form
    {
        clsInsert varInsert = new clsInsert();
        clsSelect selectClass = new clsSelect();
        DateTimePicker sys = new DateTimePicker();
        DateTimePicker syss = new DateTimePicker();
        ErrorProvider err = new ErrorProvider();
        public frmAppointment()
        {
            InitializeComponent();
        }

        private void frmAppointment_Load(object sender, EventArgs e)
        {
            selectClass.selectEmployeesname(comboBox1);
            clearAll();
            
        }

        void clearAll()
        {
            cboCat.SelectedIndex = 0;
            txtNote.Text = "";
            txtSubj.Text = "";
            dtpStartDate.Value = sys.Value.Date;
            dtpStartTime.Value =Convert.ToDateTime(syss.Value.ToShortTimeString());
            dtpEndDate.Value = sys.Value.Date;
            dtpEndTime.Value = Convert.ToDateTime(syss.Value.ToShortTimeString());
        
        }

        //SAVE
        private void button2_Click(object sender, EventArgs e)
        { 
            validatesubj(txtSubj);

            validateNote(txtNote);
           
          if(err.GetError(txtSubj).Length !=0)
          {
              err.SetError(txtSubj, "Please enter a value");
          
          }
        else if(err.GetError(txtNote).Length !=0){

            err.SetError(txtNote, "Please enter a value");
            }
          else{
                 if (dtpEndDate.Value.Date >= dtpStartDate.Value.Date)
            {


                varInsert.insertIntoSchedule(comboBox1.SelectedItem.ToString(), txtSubj.Text, cboCat, dtpStartDate, dtpStartTime, dtpEndDate, dtpEndTime, txtNote.Text);
                clearAll();
            }
            else {

                MessageBox.Show("End date can not be less than start date", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

                }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            validateNote((Control)sender);
        }

        private void txtSubj_TextChanged(object sender, EventArgs e)
        {
            validatesubj((Control)sender);
        }

        //NOTE
        void validateNote(Control ctrl)
        {
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                err.SetError(txtNote, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                err.SetError(txtNote, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtNote, string.Empty);
            }
        
        }


        //SUBJ
        void validatesubj(Control ctrl)
        {

            if (string.IsNullOrEmpty(txtSubj.Text))
            {
                err.SetError(txtSubj, "Please enter a value");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtSubj.Text))
            {
                err.SetError(txtSubj, "Please enter a value");
                return;
            }
            else
            {
                err.SetError(txtSubj, string.Empty);
            }
        }

        private void txtSubj_Leave(object sender, EventArgs e)
        {
            validatesubj((Control)sender);
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            validateNote((Control)sender);
        }
    }
}
