using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.ComponentModel;
namespace Onana_Hospital_Management_System
{
    class clsSelect:clsInsert
    {
       

        double BMI;

        int getNum;
        int getEmpNum;
        int getSuppNUm;
        int getReceiptNum;
        SqlDataReader reader;

       
        public int drugQty;
        public double PatBill;
        public string myUser;
        public string fullName;
        public string deptart;
        public string cont;
        public string designate;
        public double patientBills;
        public string Medication;
        public string Treatment;
       // public  string DrugName;
        public double DrugPrice;
       public  double myBillTotal;

        //==================================
        //   PRODUCT                        |
        //                                  |
        //=================================
        public string prosName;
        public string prosSuppliedBy;
        public string prosPrice;
        public string prosQty;
        public string prosDetails;
        public string prosManDate;
        public string prosLocation;
        public string prosExpiryDate;

        //=========================

        // CALL GEN Receipt NO
        public int GenReceiptNo()
        {


            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select genReceiptNo from GenReceipt where genReceiptNo = (select max(genReceiptNo) from GenReceipt)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getReceiptNum = Int16.Parse(reader["genReceiptNo"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getReceiptNum + 1;

        }



        //UPLOADING PICTURE
        public void ImageUpload(PictureBox pic)
        {
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Choose Pic...";
                ofd.InitialDirectory = @"C:\Picture";
                if (ofd.ShowDialog() != DialogResult.Cancel)
                {
                    pic.Image = System.Drawing.Image.FromFile(ofd.FileName);
                }
            }
            catch
            { 
            
            
            }

        }

        // CALL GENPatID
        public int callGenPatientNo()
        {



            try
            {
                
                string sql = "select num from GenPatientNo where num = (select max(num) from GenPatientNo)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getNum = Int16.Parse(reader["num"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getNum + 1;

        }

        // CALL GEN EMPLOYEE ID
        public int GenEmployeeNo()
        {


            try
            {
              //  string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select numNo from GenEmployeeNo where numNo = (select max(numNo) from GenEmployeeNo)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getEmpNum = Int16.Parse(reader["numNo"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getEmpNum + 1;

        }


        //GEN SUPPLIER ID
        public int GenSupplierNo()
        {

            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select genNum from GenSupNo where genNum = (select max(genNum) from GenSupNo)";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getSuppNUm = Int16.Parse(reader["genNum"].ToString());
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return getSuppNUm + 1;

        }

        //CALL DEPARTMENT
        public void getDepart(ComboBox comDept)
        {
            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select deptName from tblDepartment";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    comDept.Items.Add(reader["deptName"]);

                }
                comDept.SelectedIndex = 0;
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        //CALL EMPLOYEE CODE
        public void getEmpCode(ComboBox comEmpcode)
        {
            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                string sql = "select empCode from tblEmployees";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    comEmpcode.Items.Add(reader["empCode"]);

                }
                comEmpcode.SelectedIndex = 0;
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //CALL EMPLOYEE Details

        public void getDetails(ComboBox comEmpcode)
        {
            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select empSname + ' ' + empFname + ' ' + empOname as fullname, empContact, empDepartment,empDesignation from tblEmployees where empCode = '" + comEmpcode.Text + "'";


                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    fullName = reader[0].ToString();
                    cont = reader[1].ToString();
                    deptart = reader[2].ToString();
                    designate = reader[3].ToString();

                }
                else
                {
                    fullName = "";
                    cont = "";
                    deptart = "";
                    designate = "";
                    MessageBox.Show("Employee not found", "Search Result - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }

                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }





        }


        //SELECT PRODUCT BY ID
        public void getProductDetails(int id)
        {



            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proName, proSupplier, proLocation, proPrice, proQty, proManuDate, proExpiry, proDescription from tblProduct where proCode = '" + id + "'";

                SqlCommand cmd = new SqlCommand(sql, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    prosName = reader[0].ToString();
                    prosSuppliedBy = reader[1].ToString();
                    prosLocation = reader[2].ToString();
                    prosPrice = reader[3].ToString();
                    prosQty = reader[4].ToString();
                    prosManDate = reader[5].ToString();
                    prosExpiryDate = reader[6].ToString();
                    prosDetails = reader[7].ToString();


                }
                else
                {
                    prosName = "";
                    prosSuppliedBy = "";
                    prosPrice = "";
                    prosQty = "";
                    prosDetails = "";
                    prosManDate = "";
                    prosLocation = "";
                    prosExpiryDate = "";


                }
                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        public void viewDrugs()
        {
           // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbPath);
            con.Open();

            //SqlCommand cmd= new SqlCommand(sql, con);
            // dataAdapter  da = SqlDataAdapter(cmd);

        }

        public void selectImage(string id, PictureBox pics)
        {

            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select pPhoto from tblPatient where patID = '" + id + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    MemoryStream ms = new MemoryStream((byte[])reader["pPhoto"]);
                    pics.Image = new Bitmap(ms);
                }
                else
                {
                    pics.Image = Properties.Resources.index;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        //GET PATIENT NAME
        public void selectname(string id)
        {

            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
               
                
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select pSname + ' ' + pFname + ' ' +  pOname as fullname from tblPatient where patID = '" + id + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fullName = reader["fullname"].ToString();

                }
                else
                {
                    fullName = "";

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        //GET PATIENT NAME
        public void selectIdForname(ComboBox id)
        {

            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select patID from tblPatient", con);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    id.Items.Add(reader["patID"].ToString());
                }

                //if (reader.Read())
                //{
                //    fullName = reader["fullname"].ToString();
                //      }
                //else
                //{
                //    fullName = "";

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        //CALCULATE BMI
        public double calBMI(double heightInMeters, double weightInPounds)
        {
            //height in meter
            BMI = ((weightInPounds * 703) / (System.Math.Pow(heightInMeters, 2)));

            return BMI;
        }

        //VIEW PRODUCT
        public void callProductData(DataGridView dgv)
        {

            try
            {
              //  string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select proCode as [Product No], proName as [Product Name], proSupplier as [Supplier], proLocation as [Product Location], proPrice as [Price], proQty as [Quantity], proManuDate as [Manufacturing Date], proExpiry as [Expiry Date], proDescription as [Description] from tblProduct";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //VIEW PATIENT
        public void callPatientData(DataGridView dgv)
        {

            try
            {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select* from tblPatient";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //VIEW SUPPLIER
        public void callSupplierData(DataGridView dgv)
        {

            try
            {
              //  string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "select supCode as [Supplier ID], supName as [Name], supContact as [Contact], suptype as [Items], supPersonInCharge as [Sales Person], supContactPersonInCharge as [Phone Sale Person], supCountry as [Country], supEmail as [supplier Email], supAddress as [Location], supAgreementDate as [Contract On] from tblSupplier";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //SELECT LEVELS
        public void GetLevels(ComboBox comLevels)
        {
            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select Levels from Users";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comLevels.Items.Add(reader["Levels"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
 #region This login not valid
	
	    //LOGIN
        //public void Logins(string Usernames, string Password, ComboBox comLevel)
        //{
        //    try
        //    {
        //        //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
        //        SqlConnection con = new SqlConnection(dbPath);

        //        string sql = "select empCode, Uname,Pwd, Levels from Users where Uname = @Uname and Pwd = @Pwd and Levels = @Levels";
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        con.Open();
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        //        cmd.Parameters.AddWithValue("@Uname", Usernames.Trim());
        //        cmd.Parameters.AddWithValue("@Pwd", Password.Trim());
        //        cmd.Parameters.AddWithValue("@Levels", comLevel.SelectedItem.ToString());
               
        //        adapt.Fill(ds);
        //        con.Close();
        //        int count = ds.Tables[0].Rows.Count;
                
        //        //If count is equal to 1, than show frmMain form
        //        if (count == 1)
        //        {
        //            myUser = Usernames;
        //            frmParent fm = new frmParent();
        //            frmLogin log = new frmLogin();
        //            log.Hide();
                    
        //            fm.getEmpCodes.Text = Usernames;
        //            fm.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid Username or Password or Privilege", "Error - Onana HMS", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //    }

        //}


        //GET PATIENT NAME

	#endregion


        public void selectPatDetailsFromBill(string id)
        {

            try
            {
                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";


                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select patName,Amts from tblPatientBill where patID = '" + id + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fullName = reader["patName"].ToString();
                    PatBill = double.Parse(reader["Amts"].ToString());
                }
                else
                {
                    fullName = "";
                    PatBill = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        //VIEW APPOINTMENT OR SCHEDULE
        public void callSchedule(DataGridView dgv)
        {

            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
               
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = " select empCode as [Employee], subj as [Subject],categ as [Category],createOndate as [Date Created On] , createOnTime as [ Time Created On],EndOndate as [Date End On], EndOnTime as [Time End On],appNote as [Description] from tblSchedule";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //VIEW PATIENT WEIGHT
        public void callPatientWeight(DataGridView dgv)
        {

            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                string sql = "SELECT    patID  as [ID], patName as [Patient Name], bmi as [BMI], pressure as [Pressure], temperature as [Temperature], measuredOnDate as [Date], measuredOnTime as [Time] from PatientWeight";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //GET PATIENT BILL AND UPDATE
        public void selectname(ComboBox id)
        {

            try
            {
                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";


                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select Amts from tblPatientBill where patID = '" + id.SelectedItem.ToString() + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patientBills = double.Parse(reader["Amts"].ToString());

                }
                else
                {
                    patientBills = 0;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        //SELECT LEVELS
        public void GetSuppliers(ComboBox comLevels)
        {
            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select supName from tblSupplier";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comLevels.Items.Add(reader["supName"]);
                }
                comLevels.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //GET PATIENT NAME
        public void selectEmployeesname(ComboBox EmpFullname)
        {

            try
            {
                

                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select empSname + ' '  + empFname +' ' + empOname as [fullname] from tblEmployees ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmpFullname.Items.Add(reader["fullname"].ToString());

                }
                EmpFullname.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        //GET PATIENT NAME

      //  public void selectPatMedication(string id, DateTimePicker dt)


        //get employee image by id
        public void selectImageFromEmployee(string id, PictureBox pics)
        {

            try
            {
                // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                SqlCommand cmd = new SqlCommand("select epmPhoto from tblEmployees where empCode = '" + id + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    MemoryStream ms = new MemoryStream((byte[])reader["epmPhoto"]);
                    pics.Image = new Bitmap(ms);
                }
                else
                {
                    pics.Image = null;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        public void selectPatMedication(string id)
        {

            try
            {
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Treatment,medication from tblConsultation where patID = '" + id + "' and id = (select max(id) from tblConsultation)", con);
                

               // SqlCommand cmd = new SqlCommand("select Treatment,medication from tblConsultation where patID = '" + id + "'and consultDate = '" + dt.Value.Date +"'", con);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Treatment = reader["Treatment"].ToString();
                    Medication = reader["medication"].ToString();
                }
                else
                {
                    Treatment = "";
                    Medication = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        //Views Tables
        public void viewUsers(DataGridView dgv)
        {
            try
            {
               
                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select empCode as [Employee ID], Uname as [Username], Levels as [Levels] from Users";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {

            }

        }

        public void viewPatient(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select  patID as [Patient ID], pSname as [Lastname], pFname as [Firstname], pOname as [Othername], pGender as [Gender], pOccupation as [Occupation], pDOB  as [Date-Of-Birth], pResidenAddres as [Residence Address], pNationality as [Country],pContact as [Phone],pEmail as [Email],pDateRegistered as [Registered Date], pTimeRegistered as [Registered Time], pGuardianName as [Reference Name], pGuardianPhone as [Reference Phone],pGuardianRelateAs as [Relate As] from tblPatient";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {

            }

        }

        public void viewDailTransact(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select ReceiptNo as [Receipt Number], PatientName as [Patient Name],TransDate as [Transaction Date], TransTime as [Transaction Time],Amts as [Amount Paid],AmtBalance as [Balance], TransBy as [Transaction By] from DailyTransaction";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void viewDepartments(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select id as [No], deptName as [Department] from tblDepartment";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;
               

            }

            catch (Exception ex)
            {

            }

        }

        public void viewBills(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select patID as [Patience ID],patName as [Patient Name],Amts as [Balance GH₵] from tblPatientBill";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;


            }

            catch (Exception ex)
            {

            }

        }

        public void viewEmployee(DataGridView dgv)
        {
            try
            {

                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select  empCode as [Employee ID], empSname as [Lastname], empFname as [Firstname], empOname as [Othername], empDOB as [Date-ofBirth], empGender as [Gender], empContact  as [Phone], empEmail as [Email], empNationality as [Country],empDateJoined as [Employed On],empDepartment as [Department],empDesignation as [Designation], empQualification as [Qualification], empResidenceAddress as [Residence], empReferenceName as [Reference Name],empReferenceContact as [Reference Contact] from tblEmployees";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet dsd = new DataSet();
                DataTable data = new DataTable();
                // SqlDataReader reader = cmd.ExecuteReader();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dsd, sql);
                dgv.DataSource = dsd;
                dgv.DataMember = sql;

            }

            catch (Exception ex)
            {

            }

        }

        //GET PATIENT BILL AND UPDATE
        public void selectDocName(ComboBox Levels)
        {


            try
            {
                //string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbPath);

                string sql = "select Uname from Users where Levels ='" + "Doctor" + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
               
                 while (reader.Read())
                {

                    Levels.Items.Add(reader["Uname"].ToString());
                }
                 Levels.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       public void SelectDrug(string Drug)
        {
            try 
            {
                
            
                SqlConnection con = new SqlConnection(dbPath);
                con.Open();

                string sql = "select proPrice from tblProduct where proName ='" + Drug.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                 //SqlDataReader reader = cmd.ExecuteReader();

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                   // DrugName = reader["proName"].ToString();
                    DrugPrice =double.Parse( reader["proPrice"].ToString());
                }
                else
                        {
                   // DrugName = "";
                    DrugPrice = 0;
                     }
                con.Close();
            }
                catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            }

       public void SelectDrugName(ComboBox Drug)
       {
           try
           {


               SqlConnection con = new SqlConnection(dbPath);
               con.Open();

               string sql = "select proName from tblProduct";
               SqlCommand cmd = new SqlCommand(sql, con);

               reader = cmd.ExecuteReader();

              while (reader.Read())
               {
                   
                   Drug.Items.Add(reader["proName"].ToString());
               }
               Drug.SelectedIndex = 0;
               con.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       public void selectConsultation(DataGridView dgv)
       {

           try
           {

               SqlConnection con = new SqlConnection(dbPath);

               string sql = "select patID as [Patient ID], DocCode as [Doctor], consultDate as [Date], consurtTime as [Time], diagnoseDetails  as [Diagnose],  Treatment as [Treatment], medication as [Medication] from tblConsultation";
               SqlCommand cmd = new SqlCommand(sql, con);
               DataSet dsd = new DataSet();
               DataTable data = new DataTable();
               // SqlDataReader reader = cmd.ExecuteReader();

               SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
               adapter.Fill(dsd, sql);
               dgv.DataSource = dsd;
               dgv.DataMember = sql;


           }

           catch (Exception ex)
           {
             //  MessageBox.Show(ex.Message);
           }
       }

       public void selectConImage(string id, PictureBox pics)
       {

           try
           {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";
               SqlConnection con = new SqlConnection(dbPath);
               con.Open();

               SqlCommand cmd = new SqlCommand("select testImage from tblConsultation where patID = '" + id + "'", con);

               SqlDataAdapter da = new SqlDataAdapter(cmd);

               DataSet ds = new DataSet();
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {

                   MemoryStream ms = new MemoryStream((byte[])reader["testImage"]);
                   pics.Image = new Bitmap(ms);
               }
               else
               {
                   pics.Image = null;

               }


           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }

       }


       public void viewItemBills(DataGridView dgv)
       {
           try
           {

               SqlConnection con = new SqlConnection(dbPath);

               string sql = "select patID as [Patient ID], PatientName as [Patient Name], TransDate as [Transaction Date], TransTime as [Transaction Time], Item , Amts as [Price GH₵], TransBy[Server] from ItemsBills";
               SqlCommand cmd = new SqlCommand(sql, con);
               DataSet dsd = new DataSet();
               DataTable data = new DataTable();
               // SqlDataReader reader = cmd.ExecuteReader();

               SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
               adapter.Fill(dsd, sql);
               dgv.DataSource = dsd;
               dgv.DataMember = sql;

           }

           catch (Exception ex)
           {

           }

       }

       //GET PATIENT NAME
       public void selectPatientname(ComboBox names)
       {

           try
           {
               SqlConnection con = new SqlConnection(dbPath);
               con.Open();

               SqlCommand cmd = new SqlCommand("select pSname + ' ' + pFname + ' ' +  pOname as [fullname] from tblPatient", con);
               SqlDataReader reader = cmd.ExecuteReader();
              while (reader.Read())
               {
                  names.Items.Add( reader["fullname"].ToString());

               }
              names.SelectedIndex = 0;

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }

       }


        //Select Product Qty
       public void selectDrugQty(string proName)
       {

           try
           {
               // string dbPath = @"Data Source=SONY\MSSQLSERVER00V1;Initial Catalog=dbOHMS;Integrated Security=True";


               SqlConnection con = new SqlConnection(dbPath);
               con.Open();

               SqlCommand cmd = new SqlCommand("select proQty from tblProduct where proName = '" + proName + "'", con);
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {

                   drugQty = int.Parse(reader["proQty"].ToString());
               }
               else
               {
                   drugQty = 0;
               }


           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }

       }


        //SUM UP TOTAL BILL
       public void calcBilling(Label lab)
       {

           try
           {
               SqlConnection con = new SqlConnection(dbPath);
               con.Open();

               SqlCommand cmd = new SqlCommand("select SUM(Amts) as total from tblPatientBill", con);
               SqlDataReader reader = cmd.ExecuteReader();
              while (reader.Read())
               {
                   myBillTotal = double.Parse(reader["total"].ToString());

               }


              lab.Text = "Total Amount : GH₵ " + myBillTotal.ToString();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }

       }


        }


    }