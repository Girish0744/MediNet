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
    public partial class frmParent : Form
    {

        //private frmLogin login;
        clsSelect selectClass = new clsSelect();
        clsUpdate theUpdates = new clsUpdate();
        public frmParent()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
           dt = DateTime.Now;

           getDate.Text = dt.Date.ToLongDateString();
           toolStripStatusLabel4.Text = dt.ToLongTimeString();
        }

        private void frmParent_Load(object sender, EventArgs e)
        {
            clsSelect selectClass = new clsSelect();
            
            timer1.Start();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.Show();
            //Application.Exit();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            employee.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            users.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            supplier.Show();
        }

        private void productSaleInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            product.empName = this.getEmpCodes.Text;
            product.Show();
        }

        private void checkupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNurseTest Nursetest = new frmNurseTest();
            Nursetest.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments payment = new frmPayments();
            payment.cachierName = this.getEmpCodes.Text;
            payment.Show();
        }

        private void appointmentToolStripMenuItem4_Click(object sender, EventArgs e)
        {
           
        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void appointmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void appointmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAppointment appointment = new frmAppointment();
            appointment.Show();
        }

        private void appointmentToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAppointment appointment = new frmAppointment();
            appointment.Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultation consult = new frmConsultation();
            consult.txtDocName.Text = this.getEmpCodes.Text;
            consult.Show();
        }

        private void updatePasswordToolStripMenuItem4_Click(object sender, EventArgs e)
        {
           
        }

        private void updatePasswordToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmUpdatePassword uPassword = new frmUpdatePassword();
            uPassword.Show();
        }

        private void updatePasswordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUpdatePassword uPassword = new frmUpdatePassword();
            uPassword.Show();
        }

        private void updatePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdatePassword uPassword = new frmUpdatePassword();
            uPassword.Show();
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword uPassword = new frmUpdatePassword();
            uPassword.Show();
        }

        private void addAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppointment appointment = new frmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewAppointment = new frmViewAppointment();
            viewAppointment.Show();
        }

        private void addAppointmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAppointment appointment = new frmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewAppointment = new frmViewAppointment();
            viewAppointment.Show();
        }

        private void viewAppointmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewAppointment = new frmViewAppointment();
            viewAppointment.Show();
        }

        private void addAppointmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAppointment appointment = new frmAppointment();
            appointment.Show();
        }

        private void wardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * 
             * THIS FORM IS NOT YET WORKED ON
             * 
             * */


            //frmWard ward = new frmWard();
            //ward.Show();
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient patient = new frmPatient();
            patient.nurseName = this.getEmpCodes.Text;
            patient.Show();
        }

        private void viewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewPatient patientView = new frmViewPatient();
            patientView.Show();
        }

        private void viewPatientWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewPatientWeight viewWeight = new frmViewPatientWeight();
            viewWeight.Show();
        }

        private void updatePasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword uPassword = new frmUpdatePassword();
            uPassword.Show();
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewUsers userView = new frmViewUsers();
            userView.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 department = new Form1();
            department.Show();
        }

        private void viewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmviewDailyTrans viewTrans = new frmviewDailyTrans();
            viewTrans.Show();
        }

        private void viewDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewDept viewDept = new frmViewDept();
            viewDept.Show();
        }

        private void viewBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientBills bills = new frmPatientBills();
            bills.Show();
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.Show();
        }

        private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePatient patUpdate = new frmUpdatePatient();
            patUpdate.Show();
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmupdateEmployee upEmployee = new frmupdateEmployee();
            upEmployee.Show();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewEmployee viewEmp = new frmViewEmployee();
            viewEmp.Show();
        }

        private void nowToolStripMenuItem_Click(object sender, EventArgs e)
        {
          theUpdates.BackUp();
        }

        private void patientHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocPrescription prescrib = new frmDocPrescription();
            prescrib.Show();
        }

        private void viewPatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           frmViewPatient viewPatient = new frmViewPatient();
            viewPatient.Show();

        }

        private void viewPatientWeightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewPatientWeight viewWeight = new frmViewPatientWeight();
            viewWeight.Show();
        }

        private void viewAppointmentToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmViewAppointment vAppointment = new frmViewAppointment();
            vAppointment.Show();
        }

        private void viewItemBillingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewBills bills = new frmViewBills();
            bills.Show();
        }

        private void viewAppointmentToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewAppoint = new frmViewAppointment();
            viewAppoint.Show();
        }

        private void administratorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewPatientWeightToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmViewPatientWeight viewWeight = new frmViewPatientWeight();
            viewWeight.Show();
        }


       
       

 
       
    }
}
