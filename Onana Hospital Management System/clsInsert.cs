using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
namespace Onana_Hospital_Management_System
{
    class clsInsert
    {
       public string dbPath = @"Data Source=BHUTEJAS\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
              

        public void InsertToDept(string name)
        {
            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into tblDepartment (deptName) VALUES (@deptName)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@deptName", name.Trim());
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Data successfully saved", "SAVE-OHMS", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //INSERT TO PATIENT
        public void insertToPatient(string patID, string pSname, string pFname, string pOname, ComboBox pGender, string pOccupation, DateTimePicker pDOB, string pResidenAddres, ComboBox pNationality, string pContact, string pEmail, DateTimePicker pDateRegistered, DateTimePicker pTimeRegistered, string pGuardianName, string pGuardianPhone, string pGuardianRelateAs, PictureBox pPhoto)
       
        {
            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into tblPatient (patID,pSname,pFname,pOname,pGender,pOccupation,pDOB,pResidenAddres,pNationality,pContact,pEmail,pDateRegistered,pTimeRegistered,pGuardianName,pGuardianPhone,pGuardianRelateAs,pPhoto) VALUES (@patID,@pSname,@pFname,@pOname,@pGender,@pOccupation,@pDOB,@pResidenAddres,@pNationality,@pContact,@pEmail,@pDateRegistered,@pTimeRegistered,@pGuardianName,@pGuardianPhone,@pGuardianRelateAs,@pPhoto)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@pSname", pSname.Trim());
                cmd.Parameters.AddWithValue("@pFname", pFname.Trim());
                cmd.Parameters.AddWithValue("@pOname", pOname.Trim());
                cmd.Parameters.AddWithValue("@pGender", pGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pOccupation", pOccupation.Trim());
                cmd.Parameters.AddWithValue("@pDOB", pDOB.Value.Date);
                cmd.Parameters.AddWithValue("@pResidenAddres", pResidenAddres.Trim());
                cmd.Parameters.AddWithValue("@pNationality", pNationality.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pContact", pContact.Trim());
                cmd.Parameters.AddWithValue("@pEmail", pEmail.Trim());
                cmd.Parameters.AddWithValue("@pDateRegistered", pDateRegistered.Value.Date);
                cmd.Parameters.AddWithValue("@pTimeRegistered", pTimeRegistered.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@pGuardianName", pGuardianName.Trim());
                cmd.Parameters.AddWithValue("@pGuardianPhone", pGuardianPhone.Trim());
                cmd.Parameters.AddWithValue("@pGuardianRelateAs", pGuardianRelateAs.Trim());

                //ADDING PHOTO AND SIGNATURE

                MemoryStream pp = new MemoryStream();
                pPhoto.Image.Save(pp, pPhoto.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@pPhoto", System.Data.SqlDbType.Image);
                ppic.Value = pdata;

                cmd.Parameters.Add(ppic);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                con.Close();

                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
       
        //INSERT TO EMPLOYEE TABLE
        public void insertToEmployee(string empCode, string empSname, string empFname, string empOname, DateTimePicker empDOB, string empGender, string empContact, string empEmail, string empNationality, DateTimePicker empDateJoined, string empDepartment, string empDesignation, string empQualification, string empResidenceAddress, string empReferenceName, string empReferenceContact, PictureBox epmPhoto)
        {

            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                string sql = "insert into tblEmployees(empCode, empSname,  empFname, empOname, empDOB,  empGender,  empContact,  empEmail,empNationality,  empDateJoined,  empDepartment,  empDesignation,  empQualification, empResidenceAddress, empReferenceName, empReferenceContact,  epmPhoto) values(@empCode, @empSname, @empFname, @empOname, @empDOB, @empGender, @empContact, @empEmail, @empNationality, @empDateJoined, @empDepartment, @empDesignation, @empQualification, @empResidenceAddress, @empReferenceName, @empReferenceContact, @epmPhoto)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empCode", empCode.Trim());
                cmd.Parameters.AddWithValue("@empSname", empSname.Trim());
                cmd.Parameters.AddWithValue("@empFname", empFname.Trim());
                cmd.Parameters.AddWithValue("@empOname", empOname.Trim());
                cmd.Parameters.AddWithValue("@empDOB", empDOB.Value.Date);
                cmd.Parameters.AddWithValue("@empGender", empGender.Trim());
                cmd.Parameters.AddWithValue("@empContact", empContact.Trim());
                cmd.Parameters.AddWithValue("@empEmail", empEmail.Trim());
                cmd.Parameters.AddWithValue("@empNationality", empNationality.Trim());
                cmd.Parameters.AddWithValue("@empDateJoined", empDateJoined.Value.Date);

                cmd.Parameters.AddWithValue("@empDepartment", empDepartment.Trim());
                cmd.Parameters.AddWithValue("@empDesignation", empDesignation.Trim());

                cmd.Parameters.AddWithValue("@empQualification", empQualification.Trim());
                cmd.Parameters.AddWithValue("@empResidenceAddress", empResidenceAddress.Trim());

                cmd.Parameters.AddWithValue("@empReferenceName", empReferenceName.Trim());
                cmd.Parameters.AddWithValue("@empReferenceContact", empReferenceContact.Trim());

                //ADDING PHOTO AND SIGNATURE

                MemoryStream pp = new MemoryStream();
                epmPhoto.Image.Save(pp, epmPhoto.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@epmPhoto", System.Data.SqlDbType.Image);
                ppic.Value = pdata;
                cmd.Parameters.Add(ppic);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        //INSERT TO GEN ID TABLE  EmployeeNo
        public void insertIntoGenEmployeeNo(string num)
        {
            try
            {

               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into GenEmployeeNo (numNo) values(@numNo)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numNo", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

        }

        //INSERT IN GEN ID  TABLE SUPPLIER
        public void insertIntoGenSupplierNo(string num)
        {
            try
            {

                string sql = "Insert into GenSupNo (genNum) values(@genNum)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@genNum", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //INSERT IN GEN ID  TABLE RECEIPT
        public void insertIntoGenReceiptNo(string num)
        {
            try
            {

                string sql = "Insert into Genreceipt (genReceiptNo) values(@genReceiptNo)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@genReceiptNo", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //INSERT TO GEN ID TABLE GenPatientNo
        public void insertIntoGenPatientNo(string num)
        {
            try
            {

               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into GenPatientNo (num) values(@num)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

        }


        //INSERT TO USER TABLE 
        public void insertIntoUsers(ComboBox empCode, string Uname, string Pwd, ComboBox Levels)
        {
            try
            {

               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into Users (empCode, Uname, Pwd, Levels) values(@empCode, @Uname, @Pwd, @Levels)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empCode", empCode.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Uname", Uname.Trim());
                cmd.Parameters.AddWithValue("@Pwd", Pwd.Trim());
                cmd.Parameters.AddWithValue("@Levels", Levels.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("User account successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //INSERT TO PRODUCT TABLE 
        public void insertIntoProduct(string proName, string proSupplier, string proLocation, double proPrice, int proQty , DateTimePicker proManuDate, DateTimePicker proExpiry, string proDescription)
        {

            try
            {

               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "Insert into tblProduct (proName, proSupplier,proLocation, proPrice, proQty , proManuDate, proExpiry, proDescription) values(@proName, @proSupplier,@proLocation, @proPrice, @proQty , @proManuDate, @proExpiry, @proDescription)";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@proName", proName.Trim());
               cmd.Parameters.AddWithValue("@proSupplier", proSupplier.Trim());
               cmd.Parameters.AddWithValue("@proLocation", proLocation.Trim());
                cmd.Parameters.AddWithValue("@proPrice", proPrice);
                cmd.Parameters.AddWithValue("@proQty ", proQty);
                cmd.Parameters.AddWithValue("@proManuDate", proManuDate.Value.Date);
                cmd.Parameters.AddWithValue("@proExpiry", proExpiry.Value.Date);
                cmd.Parameters.AddWithValue("proDescription", proDescription.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                con.Close();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString(), "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            
            }
        }
   
        //EMPLOYEE DAILY SCHEDULES
        public void insertIntoSchedule(string empCode, string subj, ComboBox categ, DateTimePicker createOndate, DateTimePicker createOnTime, DateTimePicker EndOndate, DateTimePicker EndOnTime, string appNote)
        { 
              try
            {

              //  string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "insert into tblSchedule (empCode,subj,categ,createOndate,createOnTime,EndOndate, EndOnTime,appNote) values(@empCode,@subj,@categ,@createOndate,@createOnTime,@EndOndate,@EndOnTime,@appNote)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                  cmd.Parameters.AddWithValue("@empCode", empCode.Trim());
                  cmd.Parameters.AddWithValue("@subj",subj.Trim());
                  cmd.Parameters.AddWithValue("@categ", categ.SelectedItem.ToString());
                  cmd.Parameters.AddWithValue("@createOndate", createOndate.Value.Date);
                  cmd.Parameters.AddWithValue("@createOnTime", createOnTime.Value.ToShortTimeString());
                  cmd.Parameters.AddWithValue("@EndOndate", EndOndate.Value.Date);
                  cmd.Parameters.AddWithValue("@EndOnTime", EndOnTime.Value.ToShortTimeString());
                  cmd.Parameters.AddWithValue("@appNote", appNote.Trim());
                  cmd.ExecuteNonQuery();
                  MessageBox.Show("Schedules book successfully", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  con.Close();
        }
            catch(Exception ex)
              {
                MessageBox.Show(ex.Message);
            }
        }

        //CONSULTATION
         public void insertIntoConsultation(ComboBox patID ,string DocCode, DateTimePicker consultDate, DateTimePicker consurtTime, string diagnoseDetails, string Treatment, string medication, PictureBox testImage) {
            try
            {

               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "insert into tblConsultation(patID,DocCode,consultDate,consurtTime,diagnoseDetails,Treatment,medication,testImage) values(@patID, @DocCode,@consultDate,@consurtTime,@diagnoseDetails,@Treatment,@medication,@testImage)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@DocCode", DocCode.Trim());
                cmd.Parameters.AddWithValue("@consultDate", consultDate.Value.Date);
                cmd.Parameters.AddWithValue("@consurtTime",consurtTime.Value.ToShortTimeString());
                cmd.Parameters.AddWithValue("@diagnoseDetails", diagnoseDetails.Trim());
                cmd.Parameters.AddWithValue("@Treatment",Treatment.Trim());
                cmd.Parameters.AddWithValue("@medication",medication.Trim());

                //ADDING PHOTO AND SIGNATURE

                MemoryStream pp = new MemoryStream();
                testImage.Image.Save(pp, testImage.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@testImage", System.Data.SqlDbType.Image);
                ppic.Value = pdata;

                cmd.Parameters.Add(ppic);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Consultation record successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                con.Close();

            }catch(Exception ex){
                MessageBox.Show(ex.ToString(), "Error- Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            
            }
        
        }
           
            //SUPPLIERS
         public void insertIntoSupplier(string supCode, string supName, string supContact, ComboBox supType, string supPersonInCharge, string supContactPersonInCharge, ComboBox supCountry, string supEmail, string supAddress, DateTimePicker supAgreementDate)
         {
             try
             {

                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                 string sql = "insert into tblSupplier(supCode, supName, supContact,supType,supPersonInCharge,supContactPersonInCharge,supCountry, supEmail, supAddress, supAgreementDate) values(@supCode, @supName, @supContact,@supType,@supPersonInCharge,@supContactPersonInCharge,@supCountry, @supEmail, @supAddress, @supAgreementDate)";
                 SqlConnection con = new SqlConnection(dbPath);
                 con.Open();
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.Parameters.AddWithValue("@supCode", supCode.Trim());
                 cmd.Parameters.AddWithValue("@supName", supName.Trim());
                 cmd.Parameters.AddWithValue("@supContact", supContact.Trim());
                 cmd.Parameters.AddWithValue("@supType", supType.SelectedItem.ToString());
                 cmd.Parameters.AddWithValue("@supPersonInCharge", supPersonInCharge.Trim());
                 cmd.Parameters.AddWithValue("@supContactPersonInCharge", supContactPersonInCharge.Trim());
                 cmd.Parameters.AddWithValue("@supCountry", supCountry.SelectedItem.ToString());
                 cmd.Parameters.AddWithValue("@supEmail", supEmail.Trim());
                 cmd.Parameters.AddWithValue("@supAddress", supAddress.Trim());
                 cmd.Parameters.AddWithValue("@supAgreementDate", supAgreementDate.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supplier record successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                con.Close();

             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message, "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
         
         }
    
        //PATIENT WEIGHT AND HEIGHT
         public void insertIntoPatientWeight(string patID, string patName, double bmi, string pressure, double temperature, DateTimePicker measuredOnDate, DateTimePicker measuredOnTime)
         {

             try
             {
                 string sql = "insert into PatientWeight (patID, patName,  bmi, pressure, temperature,measuredOnDate, measuredOnTime) values(@patID, @patName,  @bmi, @pressure, @temperature, @measuredOnDate,@measuredOnTime)";
                 SqlConnection con = new SqlConnection(dbPath);
                 con.Open();
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.Parameters.AddWithValue("@patID", patID.Trim());
                 cmd.Parameters.AddWithValue("@patName", patName.Trim());
                 cmd.Parameters.AddWithValue("@bmi", bmi);
                 cmd.Parameters.AddWithValue("@pressure", pressure.Trim());
                 cmd.Parameters.AddWithValue("@temperature", temperature);
                 cmd.Parameters.AddWithValue("@measuredOnDate", measuredOnDate.Value.Date);
                 cmd.Parameters.AddWithValue("@measuredOnTime", measuredOnTime.Value.ToShortTimeString());
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("record successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 con.Close();
             
             
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

             }
         
         }

        //INSERT INTO RECEIPT
         public void insertIntoPatientWeight(int genReceiptNo)
         {

             try
             {
                 string sql = "insert into PatientWeight (genReceiptNo) values(@genReceiptNo)";
                 SqlConnection con = new SqlConnection(dbPath);
                 con.Open();
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.Parameters.AddWithValue("@genReceiptNo", genReceiptNo);
                 cmd.ExecuteNonQuery();
                 con.Close();

             }
             catch (Exception ex)
             {
                
             }

         }


        //INSERT INTO DAILY TRANSACTION
         public void insertIntoDailyTransaction(string ReceiptNo, string patID, string PatientName, DateTimePicker TransDate, DateTimePicker TransTime, double Amts, double AmtBalance, string TransBy)
         {
             try
             {
                 SqlConnection con = new SqlConnection(dbPath);
                 string sql = "Insert into DailyTransaction (ReceiptNo,patID,PatientName,TransDate,TransTime,Amts,AmtBalance,TransBy) values(@ReceiptNo,@patID,@PatientName,@TransDate,@TransTime,@Amts,@AmtBalance,@TransBy)";
                 con.Open();
                 SqlCommand cmd = new SqlCommand(sql, con);
                 cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim());
                 cmd.Parameters.AddWithValue("@patID", patID.Trim());
                 cmd.Parameters.AddWithValue("@PatientName", PatientName.Trim());
                 cmd.Parameters.AddWithValue("@TransDate", TransDate.Value.Date);
                 cmd.Parameters.AddWithValue("@TransTime", TransTime.Value.ToShortTimeString());
                 cmd.Parameters.AddWithValue("@Amts", Amts);
                 cmd.Parameters.AddWithValue("@AmtBalance", AmtBalance);
                 cmd.Parameters.AddWithValue("@TransBy", TransBy.Trim());
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Daily successfully added", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 con.Close();

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error- Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

             }

         
         }

        //INSERT INTO ITEM BILL
        public void ItemsBills( string patID, string PatientName, DateTimePicker TransDate, DateTimePicker  TransTime,string Item,double Amts,string TransBy )
        {
            try { 
            SqlConnection con = new SqlConnection(dbPath);
            string sql = "insert into ItemsBills (patID,PatientName,TransDate,TransTime,Item,Amts,TransBy) values (@patID,@PatientName,@TransDate,@TransTime,@Item,@Amts,@TransBy)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@patID", patID.Trim());
            cmd.Parameters.AddWithValue("@PatientName",PatientName.Trim());
            cmd.Parameters.AddWithValue("@TransDate", TransDate.Value.Date);
            cmd.Parameters.AddWithValue("@TransTime", TransTime.Value.ToShortTimeString());
            cmd.Parameters.AddWithValue("@Item", Item);
            cmd.Parameters.AddWithValue("@Amts", Amts);
            cmd.Parameters.AddWithValue("@TransBy", TransBy.Trim());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bill successfully taken", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();

            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.ToString());
            }
        }
  
    //INSERT INTO  TBL PATIENTBILL
        public void tblpatientBill(string patID, string patName, double Amts)
        {

            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                string sql = "insert into tblPatientBill (patID,patName,Amts) values (@patID,@patName,@Amts)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@patID", patID.Trim());
                cmd.Parameters.AddWithValue("@patName", patName.Trim());
                cmd.Parameters.AddWithValue("@Amts", Amts);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill record successfully taken", "Save Data - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message) ; }
        }

        
    
    }
}
