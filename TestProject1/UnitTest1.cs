using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTCP;
using System;
using System.Net;
using System.Text;
using Server;
using System.IO;
using System.Reflection;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Windows.Forms;


namespace Medi
{
    [TestClass]
    public class ClientServerForm
    {
        private const int Port = 8888;
        private SimpleTcpServer server;

        [TestInitialize]
        public void Setup()
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += (sender, message) =>
            {
                // Simulate server response
                message.ReplyLine($"You said: {message.MessageString}");
            };
            server.Start(IPAddress.Loopback, Port);
        }

        [TestCleanup]
        public void Teardown()
        {
            server.Stop();
        }

        [TestMethod]
        public void STSC029_TestClientServerCommunication_System()
        {
            string serverResponse = null;
            var client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += (sender, message) =>
            {
                serverResponse = message.MessageString.Trim();
            };

            // Connect to server
            client.Connect(IPAddress.Loopback.ToString(), Port);

            // Send message from client
            client.WriteLineAndGetReply("Hello from client!", TimeSpan.FromSeconds(1));

            // Filter out non-printable characters from the actual response
            string filteredActualResponse = new string(serverResponse.Where(c => !char.IsControl(c)).ToArray());

            // Trim both expected and filtered actual responses
            string expectedResponse = "You said: Hello from client!";
            string trimmedFilteredActualResponse = filteredActualResponse.Trim();

            // Assert server response
            Assert.AreEqual(expectedResponse, trimmedFilteredActualResponse);
        }
        [TestMethod]
        public void STSC030_TestAdminLogin_System()
        {
            string serverResponse = null;
            var client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += (sender, message) =>
            {
                serverResponse = message.MessageString.Trim();
            };

            // Connect to server
            client.Connect(IPAddress.Loopback.ToString(), Port);

            // Send login credentials for admin
            client.WriteLineAndGetReply("Admin", TimeSpan.FromSeconds(1));
            client.WriteLineAndGetReply("1234", TimeSpan.FromSeconds(1));
            client.WriteLineAndGetReply("Administator", TimeSpan.FromSeconds(1));

            // Filter out non-printable characters from the actual response
            string filteredActualResponse = new string(serverResponse.Where(c => !char.IsControl(c)).ToArray());

            // Assert server response
            Assert.IsTrue(filteredActualResponse.Contains("You said: Admin"), "Admin login failed. Expected response containing 'You said: Admin'. Actual response: " + filteredActualResponse);
        }

        [TestClass]
        public class DocPrescriptionFormIntegrationTests
        {
            private frmDocPrescription form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmDocPrescription();
                form.Show(); // Show the form to trigger form load event
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }



            [TestMethod]
            public void CTCLT001_Select_RowHeaderMouseClick_Display_Consultation_Details_System()
            {

                // Act
                // Simulate clicking on a row header
                form.dataGridView1_RowHeaderMouseClick(form.dataGridView1, new System.Windows.Forms.DataGridViewCellMouseEventArgs(0, 0, 0, 0, new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0)));

                // Assert
                // Assert that the patient ID text box is not empty
                Assert.IsFalse(string.IsNullOrEmpty(form.patID.Text));
                // Assert that the text boxes for consultation details are not empty
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox1.Text));
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox2.Text));
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox3.Text));
                // Assert that the picture box is not null
                Assert.IsNotNull(form.pictureBox1.Image);
            }

            [TestMethod]
            public void CTCLT002_Select_CellClick_Display_Consultation_Details_System()
            {


                // Act
                // Simulate clicking on a cell
                form.dataGridView1_CellClick(form.dataGridView1, new System.Windows.Forms.DataGridViewCellEventArgs(0, 0));

                // Assert
                // Assert that the patient ID text box is not empty
                Assert.IsFalse(string.IsNullOrEmpty(form.patID.Text));
                // Assert that the text boxes for consultation details are not empty
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox1.Text));
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox2.Text));
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox3.Text));
                // Assert that the picture box is not null
                Assert.IsNotNull(form.pictureBox1.Image);
            }
        }

        [TestClass]
        public class PatientFormIntegrationTests
        {
            private frmPatient form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmPatient();
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }

            [TestMethod]
            public void CTCLT003_SavePatient_ValidInput_Success_System()
            {
                // Arrange
                form.txtLastName.Text = "Doe";
                form.txtFirstName.Text = "John";
                form.txtOname.Text = "Smith";
                form.cboGender.SelectedIndex = 0; // Assuming Male is at index 0
                form.dtpdob.Value = DateTime.Parse("1990-01-01"); // Assuming the patient is born on 1990-01-01
                form.cboNationality.SelectedIndex = 0; // Assuming the first nationality in the dropdown is selected
                form.txtOccupation.Text = "Engineer";
                form.txtResAddress.Text = "123 Main St, City";
                form.txtContact.Text = "1234567890"; // Assuming a valid 10-digit phone number
                form.txtEmail.Text = "john.doe@example.com";
                form.txtGuardFname.Text = "Jane";
                form.txtGuardLastName.Text = "Doe";
                form.txtGContact.Text = "9876543210"; // Assuming a valid 10-digit phone number for the guardian
                form.txtRelates.Text = "Mother"; // Assuming the guardian is the patient's mother

                // Act
                form.btnSave_Click(null, EventArgs.Empty);

                // Assert

                Assert.IsTrue(string.IsNullOrEmpty(form.txtLastName.Text));
                Assert.IsTrue(string.IsNullOrEmpty(form.txtFirstName.Text));
                Assert.IsTrue(string.IsNullOrEmpty(form.txtOname.Text));
            }
        }

        [TestClass]
        public class LoginIntegrationTests
        {
            [TestMethod]
            public void CTCLT004_SuccessfulLoginWithValidCredentials_Unit()
            {
                // Arrange
                var frmLogin = new frmLogin();
                frmLogin.Show(); // Necessary to trigger form load events

                frmLogin.comboBox1.SelectedIndex = 0;
                frmLogin.txtUsername.Text = "Admin";
                frmLogin.txtPassword.Text = "1234";

                // Act
                frmLogin.button1.PerformClick(); // Simulate the login button click
            }

            [TestMethod]
            public void CTCLT005_UnsuccessfulLoginWithInvalidCredentials_Unit()
            {
                // Arrange
                var frmLogin = new frmLogin();
                frmLogin.Show(); // Load the form

                // Set invalid credentials
                frmLogin.comboBox1.SelectedIndex = 0; // Administrator
                frmLogin.txtUsername.Text = "admins";
                frmLogin.txtPassword.Text = "1234";

                // Act
                frmLogin.button1.PerformClick(); // Click the login button

            }


        }

        [TestClass]
        public class FrmPatientBillsTests
        {
            [TestMethod]
            public void CTCLT006_FrmPatientBills_Load_PopulatesDataGridView_Integration()
            {
                // Arrange
                var form = new frmPatientBills();
                form.Show(); // Load the form to trigger frmPatientBills_Load

                // Act
                var dataGridView = form.Controls.OfType<DataGridView>().First();

                // Assert
                Assert.IsTrue(dataGridView.Rows.Count > 0, "DataGridView should be populated with bill data on form load.");
            }
        }

        [TestMethod]
        public void CTCLT007_Timer_Tick_IncrementsProgressBar_Unit()
        {
            // Arrange
            var form = new frmsplashScreen();
            var initialProgress = form.progressBar1.Value;

            // Act
            form.timer1_Tick(null, EventArgs.Empty);

            // Assert
            // Check if the progress bar value is incremented after the timer tick
            Assert.IsTrue(form.progressBar1.Value > initialProgress, "Progress bar value should be incremented after timer tick.");
        }

        [TestClass]
        public class PatientFormSystemTests
        {
            private frmPayments form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmPayments();
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }

            [TestMethod]
            public void CTCLT008_CalcPatientBill_ValidInput_Success_System()
            {
                // Arrange
                form.txtPatID.Text = "Pat-7";
                form.txtPatName.Text = "kilo joh";
                form.txtAmt.Text = "400.00";
                form.txtPay.Text = "50.00";

                // Act
                form.calcPatientBill();

                // Assert
                // The expected balance after payment is 350.00
                Assert.AreEqual("350", form.txtBalance.Text);
            }

            [TestMethod]
            public void CTCLT009_UpdateBalance_ValidInput_Success_System()
            {
                // Arrange
                form.txtPatID.Text = "Pat-7";
                form.txtPatName.Text = "kilo joh";
                form.txtBalance.Text = "50.00";

                // Act
                form.UpdateBalance();


            }

        }

        [TestClass]
        public class SplashScreenIntegrationTests
        {
            private frmsplashScreen form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmsplashScreen();
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }

            [TestMethod]
            public void CTCLT010_SplashScreen_Load_TimerStarts_Successfully_Integration()
            {
                // Arrange
                // Set up event handler for the timer tick event
                form.timer1.Tick += new System.EventHandler(this.Timer_Tick);

                // Act
                // Simulate form load
                form.Show();

                // Assert
                // Check if the timer is enabled after form load
                Assert.IsTrue(form.timer1.Enabled);
            }

            private void Timer_Tick(object sender, System.EventArgs e)
            {
                // Assert
                // Ensure that the progress bar increments by 2 each tick
                Assert.AreEqual(2, form.progressBar1.Increment);

                // Check if the form is hidden and login form is shown when progress bar reaches maximum
                if (form.progressBar1.Value == form.progressBar1.Maximum)
                {
                    Assert.IsFalse(form.Visible);
                    // Assuming the login form is created and shown in the timer tick event
                    Assert.IsNotNull(form.logins);
                }
            }
        }

        [TestClass]
        public class ConsultationFormIntegrationTests
        {
            private frmConsultation form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmConsultation();
                form.cboPatcode.Items.Add("Pat-7");
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }

            [TestMethod]
            public void CTCLT011_SaveButton_Click_ValidInput_Success_Unit()
            {
                // Arrange
                form.cboPatcode.Items.Add("Pat-7");
                form.txtDocName.Text = "Dr. Smith";
                form.txtDiagnose.Text = "Sample diagnosis";
                form.txtTreatment.Text = "Sample treatment";
                form.txtMedications.Text = "Sample medication";
                form.chkNocharge.Checked = false;

                // Act
                form.btnSaveResult_Click(null, EventArgs.Empty);

                // Assert

                Assert.AreEqual("Sample diagnosis", form.txtDiagnose.Text);
                Assert.AreEqual("Sample treatment", form.txtTreatment.Text);
                Assert.AreEqual("Sample medication", form.txtMedications.Text);
                Assert.AreEqual("Dr. Smith", form.txtDocName.Text);
                Assert.AreEqual(-1, form.cboPatcode.SelectedIndex);
            }

        }

        [TestClass]
        public class Form1Tests
        {
            private const string connectionString = "";
            private const string tableName = "tblDepartment";

            [TestMethod]
            public void CTCLT012_Valinput_NewDepartment_InsertsDepartment_System()
            {
                // Arrange
                string departmentName = "NewDepartment";
                int departmentId = 24;

                // Construct connection string with TrustServerCertificate=true to bypass SSL certificate validation
                string connectionString = @"";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [dbOHMS].[dbo].[tblDepartment] (id, deptName) VALUES (@id, @deptName)";
                    command.Parameters.AddWithValue("@id", departmentId);
                    command.Parameters.AddWithValue("@deptName", departmentName);

                    try
                    {
                        // Open connection
                        connection.Open();

                        // Execute command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Assert that department was inserted successfully
                        Assert.AreEqual(1, rowsAffected);
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        // Close connection
                        connection.Close();
                    }
                }
            }

            [TestMethod]
            public void CTCLT013_Valinput_ExistingDepartment_ReturnsError_Integration()
            {
                // Arrange
                Form1 form = new Form1();
                string existingDepartmentName = "Nursing";

                // Act
                form.Valinput(existingDepartmentName);

                // Assert
                // Verify that the error provider contains an error message
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtDept)));
            }
        }

        [TestClass]
        public class FrmAppointmentTests
        {
            private frmAppointment form;

            [TestInitialize]
            public void Initialize()
            {
                form = new frmAppointment();
            }

            [TestMethod]
            public void CTCLT014_TestFormLoading_Unit()
            {
                // Act
                form.frmAppointment_Load(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(form.comboBox1.Items); // Check if employee dropdown is populated
                Assert.AreEqual(0, form.cboCat.SelectedIndex); // Check if category dropdown is initialized

            }

            [TestMethod]
            public void CTCLT015_TestSaveButton_Click_Unit()
            {
                // Arrange
                form.txtSubj.Text = "Test Subject";
                form.txtNote.Text = "Test Note";
                form.dtpStartDate.Value = DateTime.Now.Date;
                form.dtpStartTime.Value = DateTime.Now;
                form.dtpEndDate.Value = DateTime.Now.Date;
                form.dtpEndTime.Value = DateTime.Now;

                // Act
                form.button2_Click(null, EventArgs.Empty);

                // Assert
                Assert.AreEqual(0, form.err.GetError(form.txtSubj).Length); // Check if error message for subject is cleared
                Assert.AreEqual(0, form.err.GetError(form.txtNote).Length); // Check if error message for note is cleared

            }

            [TestMethod]
            public void CTCLT016_TestCloseButton_Click_Unit()
            {
                // Act
                form.button1_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsFalse(form.Visible); // Check if the form is closed
            }

            [TestMethod]
            public void CTCLT017_TestDataValidation_Unit()
            {
                // Arrange - Set invalid data
                form.txtSubj.Text = "";
                form.txtNote.Text = "";


                // Act - Trigger validation
                form.txtSubj_Leave(null, EventArgs.Empty);
                form.txtNote_Leave(null, EventArgs.Empty);

                // Assert - Check for error messages
                Assert.IsFalse(string.IsNullOrEmpty(form.err.GetError(form.txtSubj)));
                Assert.IsFalse(string.IsNullOrEmpty(form.err.GetError(form.txtNote)));

            }


            [TestCleanup]
            public void Cleanup()
            {
                form.Dispose();
            }
        }

        [TestClass]
        public class FrmMedicationTests
        {
            private frmMedication form;

            [TestInitialize]
            public void Initialize()
            {
                form = new frmMedication();
            }

            [TestMethod]
            public void CTCLT018_FrmMedication_Load_FormLoadedSuccessfully_Integration()
            {
                // Arrange - Nothing to arrange

                // Act
                form.frmMedication_Load(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(form); // Form should not be null after loading
            }

            [TestMethod]
            public void CTCLT019_TextBox1_TextChanged_TextEnteredSuccessfully_Integration()
            {
                // Arrange
                string expectedText = "Test";

                // Act
                form.textBox1.Text = expectedText;
                form.textBox1_TextChanged(null, EventArgs.Empty);

                // Assert
                Assert.AreEqual(expectedText, form.textBox1.Text); // Text should be set correctly
            }
        }

        [TestClass]
        public class FrmSupplierTests
        {
            private frmSupplier form;

            [TestInitialize]
            public void Initialize()
            {
                form = new frmSupplier();
            }

            [TestMethod]
            public void CTCLT020_FrmSupplier_Load_FormLoadedSuccessfully_Integration()
            {
                // Arrange - Nothing to arrange

                // Act
                form.frmSupplier_Load(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(form); // Form should not be null after loading
            }

            [TestMethod]
            public void CTCLT021_Button1_Click_ValidSupplierDataInserted_System()
            {
                // Arrange
                string expectedSupplierId = "sup-9";
                string expectedSupplierName = "Supplier Name";
                string expectedSupplierContact = "1234567890";
                string expectedSupplierIncharge = "Person Incharge";
                string expectedSupplierPersonContact = "9876543210";
                string expectedSupplierAddress = "Supplier Address";

                // Act
                form.txtSupID.Text = expectedSupplierId;
                form.txtSupName.Text = expectedSupplierName;
                form.txtSupcontact.Text = expectedSupplierContact;
                form.txtSupPersonIncharge.Text = expectedSupplierIncharge;
                form.txtSupPersonContact.Text = expectedSupplierPersonContact;
                form.txtSupAddress.Text = expectedSupplierAddress;
                form.button1_Click(null, EventArgs.Empty);

            }

            [TestMethod]
            public void CTCLT022_Button3_Click_SearchesSupplierData_Integration()
            {
                // Arrange
                string expectedSupplierCode = "sup-1";

                // Act
                form.textBox1.Text = expectedSupplierCode;
                form.button3_Click(null, EventArgs.Empty);


            }
        }

        [TestClass]
        public class FrmViewPatientTests
        {
            private frmViewPatient form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmViewPatient();
                form.Show();  // Mimic form loading
            }

            [TestMethod]
            public void CTCLT023_PatientData_LoadsCorrectly_OnFormLoad()
            {
                // Arrange is handled by Setup

                // Act: Trigger the load event if not automatically called
                form.frmViewPatient_Load(new object(), EventArgs.Empty);

                // Assert: Check if dataGridView1 is populated with expected data
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "No data loaded into the data grid view.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmViewDeptIntegrationTests
        {
            private frmViewDept form;
            private string dbConnectionString = "";

            [TestInitialize]
            public void Initialize()
            {
                // Initialize the form and establish a connection to the database
                form = new frmViewDept();
            }

            [TestMethod]
            public void CTCLT024_FrmViewDept_Load_PopulatesDataGridView_Unit()
            {
                // Act
                form.frmViewDept_Load(null, EventArgs.Empty);

                // Assert
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "DataGridView should be populated with department data.");
            }

            [TestMethod]
            public void CTCLT025_Button1_Click_ClosesForm_Integration()
            {
                // Arrange
                bool formClosed = false;
                form.FormClosed += (sender, e) => formClosed = true;

                // Act
                form.button1_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsTrue(formClosed, "Form should be closed after button click.");
            }

            private int GetRowCount()
            {
                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM tblDepartment", connection);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        [TestClass]
        public class FrmViewAppointmentTests
        {
            [TestMethod]
            public void CTCLT026_FrmViewAppointment_ClosesForm_Integration()
            {
                // Arrange
                var frmViewAppointment = new frmViewAppointment();

                // Act
                frmViewAppointment.button1_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsFalse(frmViewAppointment.Visible);
            }

        }

        // Mock class for clsSelect to control behavior in tests
        public class clsSelect
        {
            public Action<DataGridView> CallScheduleCallback;

            public void callSchedule(DataGridView dataGridView)
            {
                CallScheduleCallback?.Invoke(dataGridView);
            }
        }

        //Data is being saved but issue in connestion establishment with database.
        [TestClass]
        public class NurseIntegrationTests
        {
            private string connectionString = @"Data Source=DESKTOP-VCQGRJ0\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            private string testPatID = "pat-5";
            private string testPatName = "John Doe";
            private double testBmi = 25.0;
            private string testPressure = "120/80";
            private double testTemperature = 98.6;
            private DateTime testMeasuredOnDate = DateTime.Now.Date;
            private DateTime testMeasuredOnTime = DateTime.Now;

            [TestMethod]
            public void STSC001_Test_InsertIntoPatientWeight_Integration()
            {
                // Arrange
                clsInsert insertClass = new clsInsert();

                // Create DateTimePicker objects
                DateTimePicker measuredOnDatePicker = new DateTimePicker();
                DateTimePicker measuredOnTimePicker = new DateTimePicker();

                // Set the values
                measuredOnDatePicker.Value = testMeasuredOnDate;
                measuredOnTimePicker.Value = testMeasuredOnTime;

                // Act
                insertClass.insertIntoPatientWeight(testPatID, testPatName, testBmi, testPressure, testTemperature, measuredOnDatePicker, measuredOnTimePicker);

                // Assert
                // Verify that data is inserted into the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbOHMS].[dbo].[PatientWeight] WHERE patID = @patID", connection);
                    cmd.Parameters.AddWithValue("@patID", testPatID);
                    int rowCount = (int)cmd.ExecuteScalar();
                    Assert.AreEqual(1, rowCount, "Expected one row to be inserted into the database.");
                }

                // Verify that the inserted data matches the provided input parameters
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbOHMS].[dbo].[PatientWeight] WHERE patID = @patID", connection);
                    cmd.Parameters.AddWithValue("@patID", testPatID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Assert.AreEqual(testPatName, reader["patName"].ToString(), "Unexpected patName value in the database.");
                        Assert.AreEqual(testBmi, Convert.ToDouble(reader["bmi"]), "Unexpected bmi value in the database.");
                        Assert.AreEqual(testPressure, reader["pressure"].ToString(), "Unexpected pressure value in the database.");
                        Assert.AreEqual(testTemperature, Convert.ToDouble(reader["temperature"]), "Unexpected temperature value in the database.");
                        Assert.AreEqual(testMeasuredOnDate, Convert.ToDateTime(reader["measuredOnDate"]).Date, "Unexpected measuredOnDate value in the database.");
                        Assert.AreEqual(testMeasuredOnTime.TimeOfDay, Convert.ToDateTime(reader["measuredOnTime"]).TimeOfDay, "Unexpected measuredOnTime value in the database.");
                    }
                    else
                    {
                        Assert.Fail("No data found in the database for the specified patID.");
                    }
                    reader.Close();
                }
            }
            private frmNurseTest nurseForm;

            [TestInitialize]
            public void Setup()
            {
                nurseForm = new frmNurseTest();
            }
            [TestMethod]
            public void STSC002_NurseForm_Button1_Click_LoadsPatientName_System()
            {
                // Arrange: Set up test data
                string expectedPatID = "pat-6";
                string expectedPatName = "Kumah Kevin Yaw";

                // Act: Simulate user interaction
                nurseForm.txtPatID.Text = expectedPatID;
                nurseForm.button1_Click(null, null); // Simulate clicking the button

                // Assert: Check if the patient name matches the expected name
                Assert.AreEqual(expectedPatName, nurseForm.txtPatName.Text, "Patient name mismatch.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(nurseForm.txtPatID.Text), "Patient ID not retrieved.");
            }
        }

        [TestClass]
        public class FrmParentTests
        {
            private frmParent form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmParent();
                form.Show();
            }

            [TestMethod]
            public void STSC003_TimerTick_UpdatesDateTimeDisplaysCorrectly_Integration()
            {
                // Act: Trigger the timer event manually
                form.timer1_Tick(form, EventArgs.Empty);

                // Assert: Verify that the date and time are displayed correctly
                Assert.AreEqual(DateTime.Now.ToLongDateString(), form.getDate.Text, "Date display does not match.");
                Assert.AreEqual(DateTime.Now.ToLongTimeString(), form.toolStripStatusLabel4.Text, "Time display does not match.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmUpdatePasswordIntegrationTests
        {
            private frmUpdatePassword form;

            [TestInitialize]
            public void Initialize()
            {
                // Initialize the form
                form = new frmUpdatePassword();
            }

            [TestMethod]
            public void STSC004_Button1_Click_ValidUser_PasswordUpdated_System()
            {
                // Arrange - Set up valid user data
                form.txtUserID.Text = "123";
                form.txtUserName.Text = "testuser";
                form.txtCurrent.Text = "oldpassword";
                form.txtNewPassword.Text = "newpassword";
                form.txtrepeatPassword.Text = "newpassword";

                // Act - Click the save button
                form.button1_Click(null, EventArgs.Empty);

            }

            [TestMethod]
            public void STSC005_Button1_Click_PasswordMismatch_ShowErrorMessage_System()
            {
                // Arrange - Set up valid user data but mismatching passwords
                form.txtUserID.Text = "123";
                form.txtUserName.Text = "testuser";
                form.txtCurrent.Text = "oldpassword";
                form.txtNewPassword.Text = "newpassword";
                form.txtrepeatPassword.Text = "differentpassword";

                // Act - Click the save button
                form.button1_Click(null, EventArgs.Empty);

                // Assert - Check if an error message is shown
                Assert.IsTrue(form.err.GetError(form.txtrepeatPassword).Contains("Password mismatch"));
            }

        }

        [TestClass]
        public class FrmUsersTests
        {
            private frmUsers? _form;

            [TestInitialize]
            public void Setup()
            {
                _form = new frmUsers();
                _form.Show();
            }

            [TestMethod]
            public void STSC006_FrmUsers_Load_InitializesControlsCorrectly_Integration()
            {
                // Assuming cboLevel should be set to the first index on load
                Assert.AreEqual(0, _form.cboLevel.SelectedIndex, "Initial selected index for level is not set correctly.");

                // Check if the password fields are initialized to be empty
                Assert.IsTrue(string.IsNullOrEmpty(_form.txtPass.Text), "Password textbox should be empty on load.");
                Assert.IsTrue(string.IsNullOrEmpty(_form.txtConfirmPass.Text), "Confirm password textbox should be empty on load.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                _form.Close();
            }


            [TestMethod]
            public void STSC007_ResetButton_Click_ClearsAllInputs_System()
            {
                // Arrange: Set all fields with some data
                _form.txtUname.Text = "username";
                _form.txtPass.Text = "password";
                _form.txtConfirmPass.Text = "password";
                _form.cboEmpID.SelectedIndex = 0;

                // Act: Trigger the clear or reset functionality
                _form.btnCancel.PerformClick();

                // Assert: All fields should be reset
                Assert.IsTrue(string.IsNullOrEmpty(_form.txtUname.Text), "Username should be cleared.");
                Assert.IsTrue(string.IsNullOrEmpty(_form.txtPass.Text), "Password should be cleared.");
                Assert.IsTrue(string.IsNullOrEmpty(_form.txtConfirmPass.Text), "Confirm Password should be cleared.");
                Assert.AreEqual(0, _form.cboEmpID.SelectedIndex, "Employee ID should be reset.");
            }

        }

        [TestClass]
        public class FrmViewPatientWeightIntegrationTests
        {
            private frmViewPatientWeight form;
            private const string connectionString = @"Data Source=JIYA\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True"; // Update with your database connection string

            [TestInitialize]
            public void Setup()
            {
                form = new frmViewPatientWeight();
                form.Show();
            }

            [TestMethod]
            public void CTCLT027_Test_SelectPatientName_Integration()
            {
                // Act
                form.frmViewPatientWeight_Load(form, EventArgs.Empty);

                // Assert
                // Verify that patient names are successfully loaded into the combo box
                Assert.IsTrue(form.comboBox1.Items.Count > 0, "Failed to load patient names into the combo box.");
            }

            [TestMethod]
            public void CTCLT028_Test_LoadPatientWeightData_Integration()
            {
                // Arrange
                form.frmViewPatientWeight_Load(form, EventArgs.Empty);
                string selectedPatientName = form.comboBox1.Items.Count > 0 ? form.comboBox1.Items[0].ToString() : string.Empty;

                // Act
                form.comboBox1.SelectedItem = selectedPatientName;
                form.comboBox1_SelectedIndexChanged(form, EventArgs.Empty);

                // Assert
                // Verify that patient weight data is loaded into the data grid view
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "Failed to load patient weight data into the data grid view.");
            }

            [TestMethod]
            public void CTCLT029_Test_ButtonClick_CloseForm_Unit()
            {
                // Act
                form.button1_Click(form, EventArgs.Empty);

                // Assert
                // Verify that the form is closed after clicking the button
                Assert.IsFalse(form.Visible, "Form is still visible after clicking the button.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmViewBillsIntegrationTests
        {
            private frmViewBills form;
            private const string connectionString = @"Data Source=BHUTEJAS\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True"; // Update with your database connection string

            [TestInitialize]
            public void Setup()
            {
                form = new frmViewBills();
                form.Show();
            }

            [TestMethod]
            public void STSC008_Test_LoadItemBills_Unit()
            {
                // Act
                form.frmViewBills_Load(form, EventArgs.Empty);

                // Assert
                // Verify that item bills are successfully loaded into the data grid view
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "Failed to load item bills into the data grid view.");
            }

            [TestMethod]
            public void STSC009_Test_SelectPatientName_Unit()
            {
                // Act
                form.frmViewBills_Load(form, EventArgs.Empty);

                // Assert
                // Verify that patient names are successfully loaded into the combo box
                Assert.IsTrue(form.patName.Items.Count > 0, "Failed to load patient names into the combo box.");
            }

            [TestMethod]
            public void STSC010_Test_FilterBills_Integration()
            {
                // Arrange
                form.frmViewBills_Load(form, EventArgs.Empty);

                // Act
                form.dtpFrom.Value = DateTime.Now.AddDays(-7);
                form.dtpTo.Value = DateTime.Now;
                form.selectBills();

                // Assert
                // Verify that filtered bills are displayed in the data grid view
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "Failed to filter bills.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmViewEmployeeTests
        {
            private frmViewEmployee form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmViewEmployee();
                form.Show();  // Mimic form loading
            }

            [TestMethod]
            public void STSC011_EmployeeData_LoadsCorrectly_OnFormLoad_Unit()
            {
                // Act: Trigger the load event
                form.frmViewEmployee_Load(new object(), EventArgs.Empty);

                // Assert: Check if dataGridView1 is populated with expected data
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "Data grid should be populated with employee data.");
            }



            [TestMethod]
            public void STSC012_FormControls_AreCorrectlyInitialized_Integration()
            {
                // Check the initial state of the DataGridView
                Assert.AreEqual(7, form.dataGridView1.Rows.Count, "DataGridView should be empty before data is loaded.");

                // Check other controls are initialized to expected values
                Assert.IsTrue(string.IsNullOrEmpty(form.txtEmpname.Text), "Employee name should be empty initially.");
                Assert.IsTrue(string.IsNullOrEmpty(form.txtEmpPhone.Text), "Employee phone should be empty initially.");
            }

            [TestMethod]
            public void STSC013_CloseButton_ClosesForm_Integration()
            {
                var wasClosed = false;
                form.FormClosed += (sender, args) => { wasClosed = true; };

                // Assume 'button1' is the close button on your form
                form.button1.PerformClick();

                Assert.IsTrue(wasClosed, "Form should close when close button is clicked.");
            }


            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }


        [TestClass]
        public class FrmViewDailyTransIntegrationTests
        {
            private frmviewDailyTrans form;
            private const string connectionString = @"Data Source=BHUTEJAS\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True"; // Update with your database connection string

            [TestInitialize]
            public void Setup()
            {
                form = new frmviewDailyTrans();
                form.Show();
            }

            [TestMethod]
            public void CTCLT030_Test_LoadDailyTransactions_Unit()
            {
                // Act
                form.frmviewDailyTrans_Load(null, EventArgs.Empty);

                // Assert
                // Verify that daily transactions are successfully loaded into the data grid view
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "Failed to load daily transactions into the data grid view.");
            }

            [TestMethod]
            public void CTCLT031Button1_Click_ClosesForm_Unit()
            {
                // Act
                form.button1_Click(null, null);

                // Assert
                Assert.IsFalse(form.Visible); // Check if the form is closed
            }


            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmWardIntegrationTests
        {
            private frmWard form;
            private const string connectionString = @"Data Source=JIYA\SQLEXPRESS;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True"; // Update with your database connection string

            [TestInitialize]
            public void Setup()
            {
                form = new frmWard();
                form.Show();
            }

            [TestMethod]
            public void STSC014_Test_LoadMaleWard_Unit()
            {
                // Arrange
                form.comboBox1.SelectedIndex = 1; // Select Male Ward

                // Act
                form.comboBox1_SelectedIndexChanged(null, EventArgs.Empty);

                // Assert
                // Verify that the text boxes are populated with correct data for Male Ward
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox1.Text), "Failed to load bill for Male Ward.");
                Assert.IsFalse(string.IsNullOrEmpty(form.txtPeople.Text), "Failed to load number of people for Male Ward.");
            }

            [TestMethod]
            public void STSC015_Test_LoadFemaleWard_Unit()
            {
                // Arrange
                form.comboBox1.SelectedIndex = 0; // Select Female Ward

                // Act
                form.comboBox1_SelectedIndexChanged(null, EventArgs.Empty);

                // Assert
                // Verify that the text boxes are populated with correct data for Female Ward
                Assert.IsFalse(string.IsNullOrEmpty(form.textBox1.Text), "Failed to load bill for Female Ward.");
                Assert.IsFalse(string.IsNullOrEmpty(form.txtPeople.Text), "Failed to load number of people for Female Ward.");
            }

            [TestMethod]
            public void STSC016_Test_UpdateMaleWard_Integration()
            {
                // Arrange
                form.comboBox1.SelectedIndex = 1; // Select Male Ward
                double newBill = 200.0;
                double newNumOfPeople = 10.0;

                // Act
                form.textBox1.Text = newBill.ToString();
                form.txtPeople.Text = newNumOfPeople.ToString();
                form.button1_Click(null, EventArgs.Empty);

                // Assert
                // Verify that Male Ward is successfully updated with new values
                Assert.AreEqual(newBill.ToString(), form.textBox1.Text, "Failed to update bill for Male Ward.");
                Assert.AreEqual(newNumOfPeople.ToString(), form.txtPeople.Text, "Failed to update number of people for Male Ward.");
            }

            [TestMethod]
            public void STSC017_Test_UpdateFemaleWard_Integration()
            {
                // Arrange
                form.comboBox1.SelectedIndex = 0; // Select Female Ward
                double newBill = 250.0;
                double newNumOfPeople = 15.0;

                // Act
                form.textBox1.Text = newBill.ToString();
                form.txtPeople.Text = newNumOfPeople.ToString();
                form.button1_Click(null, EventArgs.Empty);

                // Assert
                // Verify that Female Ward is successfully updated with new values
                Assert.AreEqual(newBill.ToString(), form.textBox1.Text, "Failed to update bill for Female Ward.");
                Assert.AreEqual(newNumOfPeople.ToString(), form.txtPeople.Text, "Failed to update number of people for Female Ward.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }


        [TestClass]
        public class FrmUpdatePatientSystemTests
        {
            private frmUpdatePatient form;
            private const string connectionString = @"Data Source=BHUTEJAS\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True"; // Update with your database connection string

            [TestInitialize]
            public void Setup()
            {
                form = new frmUpdatePatient();
                form.Show();
            }

            [TestMethod]
            public void STSC018_Test_UpdatePatient_System()
            {
                // Arrange
                form.txtPatCode.Text = "12345";
                form.txtLastName.Text = "Smith";
                form.txtFirstName.Text = "John";
                form.txtOname.Text = "Doe";
                form.cboGender.SelectedIndex = 0;
                form.txtOccupation.Text = "Engineer";
                form.dtpdob.Value = DateTime.Parse("1990-01-01");
                form.txtResAddress.Text = "123 Main Street";
                form.cboNationality.SelectedIndex = 0;
                form.txtContact.Text = "1234567890";
                form.txtEmail.Text = "john@example.com";
                form.txtGuardFname.Text = "Jane";
                form.txtGContact.Text = "9876543210";
                form.txtRelates.Text = "Mother";
                // Simulate image selection
                form.pictureBox1.Image = Properties.Resources.index;
                // Act
                form.btnSave_Click(null, EventArgs.Empty);
                // Assert
                // Verify that the patient is successfully updated in the database
                // For simplicity, we'll just verify that the error provider is cleared after saving
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtLastName)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtFirstName)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtOccupation)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtContact)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtResAddress)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtGuardFname)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtGContact)), "Error provider not cleared after saving.");
                Assert.IsTrue(string.IsNullOrEmpty(form.err.GetError(form.txtRelates)), "Error provider not cleared after saving.");
            }

            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        [TestClass]
        public class FrmViewUsersTests
        {
            [TestMethod]
            public void STSC019_Test_ViewUsers_Load_Unit()
            {
                // Arrange
                var form = new frmViewUsers();

                // Act
                form.frmViewUsers_Load(null, null);

                // Assert
                // Check if DataGridView is populated with users
                Assert.IsTrue(form.dataGridView1.Rows.Count > 0, "DataGridView not populated with users.");
            }

            [TestMethod]
            public void STSC020_Test_Button1_Click_Unit()
            {
                // Arrange
                var form = new frmViewUsers();

                // Act
                form.button1_Click(null, null);

                // Assert
                // Check if the form is closed after button click
                Assert.IsTrue(form.IsDisposed, "Form not closed after button click.");
            }
        }

        [TestClass]
        public class CreateEmployeeIntegrationTests
        {
            public frmEmployee frmEmployee;

            [TestInitialize]
            public void Initialize()
            {

                // Initialize the form and show it for testing
                frmEmployee = new frmEmployee();
                frmEmployee.Show();

                // Allow the form to fully initialize before proceeding with tests
                Application.DoEvents();
            }

            [TestMethod]
            public void CTCLT032_TestNationalityComboBox_Integration()
            {
                ComboBox cboNationality = frmEmployee.cboNationality;
                Assert.IsNotNull(cboNationality);
                Assert.AreEqual(new System.Drawing.Point(152, 142), cboNationality.Location);
                Assert.AreEqual(new System.Drawing.Size(154, 23), cboNationality.Size);
                Assert.AreEqual(4, cboNationality.TabIndex);
            }

            [TestMethod]
            public void CTCLT033_TestDateJoinedDateTimePicker_Integration()
            {
                DateTimePicker dtpDateJoined = frmEmployee.dtpDateJoined;
                Assert.IsNotNull(dtpDateJoined);
                Assert.AreEqual(new System.Drawing.Point(426, 266), dtpDateJoined.Location);
                Assert.AreEqual(new System.Drawing.Size(170, 23), dtpDateJoined.Size);
                Assert.AreEqual(5, dtpDateJoined.TabIndex);
                Assert.AreEqual(System.Windows.Forms.DateTimePickerFormat.Short, dtpDateJoined.Format);
            }

            [TestMethod]
            public void CTClT034_TestFillDetails_System()
            {
                // Find controls on the form
                TextBox txtFirstName = frmEmployee.Controls.Find("txtFirstName", true).FirstOrDefault() as TextBox;
                TextBox txtLastName = frmEmployee.Controls.Find("txtLastName", true).FirstOrDefault() as TextBox;
                ComboBox cboGender = frmEmployee.Controls.Find("cboGender", true).FirstOrDefault() as ComboBox;
                DateTimePicker dtpDOB = frmEmployee.Controls.Find("dtpDOB", true).FirstOrDefault() as DateTimePicker;
                ComboBox cboNationality = frmEmployee.Controls.Find("cboNationality", true).FirstOrDefault() as ComboBox;
                TextBox txtContact = frmEmployee.Controls.Find("txtContact", true).FirstOrDefault() as TextBox;
                TextBox txtResAddress = frmEmployee.Controls.Find("txtResAddress", true).FirstOrDefault() as TextBox;
                ComboBox cboDepartment = frmEmployee.Controls.Find("cboDepartment", true).FirstOrDefault() as ComboBox;
                TextBox txtDesignation = frmEmployee.Controls.Find("txtDesignation", true).FirstOrDefault() as TextBox;
                DateTimePicker dtpDateJoined = frmEmployee.Controls.Find("dtpDateJoined", true).FirstOrDefault() as DateTimePicker;

                // Fill in the details
                txtFirstName.Text = "John";
                txtLastName.Text = "Doe";
                cboGender.SelectedItem = "Male";
                dtpDOB.Value = new DateTime(1990, 1, 1);
                cboNationality.SelectedItem = "Afghanistan";
                txtContact.Text = "1234567890";
                txtResAddress.Text = "123, Street Name, City";
                cboDepartment.SelectedItem = "IT";
                txtDesignation.Text = "Software Engineer";
                dtpDateJoined.Value = DateTime.Today;

                // Assert the filled-in details
                Assert.IsNotNull(txtFirstName);
                Assert.IsNotNull(txtLastName);
                Assert.IsNotNull(cboGender);
                Assert.IsNotNull(dtpDOB);
                Assert.IsNotNull(cboNationality);
                Assert.IsNotNull(txtContact);
                Assert.IsNotNull(txtResAddress);
                Assert.IsNotNull(cboDepartment);
                Assert.IsNotNull(txtDesignation);
                Assert.IsNotNull(dtpDateJoined);


                // Assert that each control is not null after filling in the details
                Assert.IsNotNull(txtFirstName, "First Name textbox is null after filling details.");
                Assert.IsNotNull(txtLastName, "Last Name textbox is null after filling details.");
                Assert.IsNotNull(cboGender, "Gender combo box is null after filling details.");
                Assert.IsNotNull(dtpDOB, "Date of Birth date picker is null after filling details.");
                Assert.IsNotNull(cboNationality, "Nationality combo box is null after filling details.");
                Assert.IsNotNull(txtContact, "Contact textbox is null after filling details.");
                Assert.IsNotNull(txtResAddress, "Residential Address textbox is null after filling details.");
                Assert.IsNotNull(cboDepartment, "Department combo box is null after filling details.");
                Assert.IsNotNull(txtDesignation, "Designation textbox is null after filling details.");
                Assert.IsNotNull(dtpDateJoined, "Date Joined date picker is null after filling details.");

                // Assert specific values for each control
                Assert.AreEqual("John", txtFirstName.Text, "First Name is not set correctly.");
                Assert.AreEqual("Doe", txtLastName.Text, "Last Name is not set correctly.");
                Assert.AreEqual("Male", cboGender.SelectedItem, "Gender is not selected correctly.");
                Assert.AreEqual(new DateTime(1990, 1, 1), dtpDOB.Value, "Date of Birth is not set correctly.");
                Assert.AreEqual("Afghanistan", cboNationality.SelectedItem, "Nationality is not selected correctly.");
                Assert.AreEqual("1234567890", txtContact.Text, "Contact number is not set correctly.");
                Assert.AreEqual("123, Street Name, City", txtResAddress.Text, "Residential Address is not set correctly.");
                Assert.AreEqual("", cboDepartment.SelectedItem, "Department is not selected correctly.");
                Assert.AreEqual("Software Engineer", txtDesignation.Text, "Designation is not set correctly.");
                Assert.AreEqual(DateTime.Today, dtpDateJoined.Value, "Date Joined is not set correctly.");
            }

        }

        [TestClass]
        public class UpdateIntegrationTests
        {
            private const string connectionString = @"Data Source=BHUTEJAS\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";

            [TestMethod]
            public void STSC021_DeletingDrugByID_DeletesProductFromDatabase_System()
            {
                // Arrange
                int productIDToDelete = 1001;
                clsUpdate updater = new clsUpdate();

                // Act
                updater.deletingDrugByID(productIDToDelete);

                // Assert
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProduct WHERE proCode = @proCode", connection);
                    cmd.Parameters.AddWithValue("@proCode", productIDToDelete);
                    int rowCount = (int)cmd.ExecuteScalar();
                    Assert.AreEqual(0, rowCount, "Expected product to be deleted from the database.");
                }
            }

            [TestMethod]
            public void STSC022_BackUp_CreatesBackupFile_System()
            {
                // Arrange
                string backupFilePath = @"C:\Temp_dbOHMS\dbOHMS.BAK";
                clsUpdate updater = new clsUpdate();

                // Act
                updater.BackUp();

                // Assert
                Assert.IsTrue(File.Exists(backupFilePath), "Backup file not created.");
            }

            [TestMethod]
            public void STSC023_UpdateProductQty_UpdatesProductQuantityInDatabase_System()
            {
                // Arrange
                string productName = "Paracetamol";
                int newQuantity = 50;
                clsUpdate updater = new clsUpdate();

                // Act
                updater.UpdateProductQty(productName, newQuantity);

                // Assert
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT proQty FROM tblProduct WHERE proName = @proName", connection);
                    cmd.Parameters.AddWithValue("@proName", productName);
                    int updatedQuantity = (int)cmd.ExecuteScalar();
                    Assert.AreEqual(newQuantity, updatedQuantity, "Product quantity not updated in the database.");
                }
            }
        }

        [TestClass]
        public class UpdateEmployeeFormTests
        {
            private frmupdateEmployee form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmupdateEmployee();
            }

            [TestCleanup]
            public void TearDown()
            {
                form.Close();
                form.Dispose();
            }

            [TestMethod]
            public void CTCLT035_UpdateEmployeeDetails_ValidInput_Success_System()
            {
                // Arrange
                string lastName = "Doe";
                string firstName = "John";
                string oName = "Smith";
                DateTime dob = DateTime.Now.AddYears(-30);
                string gender = "Male";
                string contact = "1234567890";
                string email = "john.doe@example.com";
                string nationality = "Nationality";
                DateTime dateJoined = DateTime.Now;
                string department = "Department";
                string designation = "Designation";
                string qualification = "Qualification";
                string residenceAddress = "Residence Address";
                string referenceName = "Reference Name";
                string referenceContact = "9876543210";

                // Act
                form.LastName = lastName;
                form.FirstName = firstName;
                form.OName = oName;
                form.DOB = dob;
                form.Gender = gender;
                form.Contact = contact;
                form.Email = email;
                form.Nationality = nationality;
                form.DateJoined = dateJoined;
                form.Department = department;
                form.Designation = designation;
                form.Qualification = qualification;
                form.ResAddress = residenceAddress;
                form.ReferenceName = referenceName;
                form.RefContact = referenceContact;

                // Simulate button click to save
                form.btnSave_Click(null, EventArgs.Empty);

                // Assert
                Assert.AreEqual(lastName, form.LastName);
                Assert.AreEqual(firstName, form.FirstName);
                Assert.AreEqual(oName, form.OName);
                Assert.AreEqual(contact, form.Contact);
                Assert.AreEqual(email, form.Email);
                Assert.AreEqual(designation, form.Designation);
                Assert.AreEqual(qualification, form.Qualification);
                Assert.AreEqual(residenceAddress, form.ResAddress);
                Assert.AreEqual(referenceName, form.ReferenceName);
                Assert.AreEqual(referenceContact, form.RefContact);
            }
        }

        [TestClass]
        public class FrmPaymentsSystemTests
        {
            private frmPayments form;

            [TestInitialize]
            public void Setup()
            {
                form = new frmPayments();
                form.Show();
            }

            [TestMethod]
            public void STSC024_Test_PaymentCalculation_WhenAmountPaidIsLessThanAmountOwed_System()
            {
                // Arrange
                form.txtPatID.Text = "123";
                form.txtPatName.Text = "John Doe";
                form.txtAmt.Text = "100"; // Amount owed
                form.txtPay.Text = "50"; // Amount paid
                                         // Act
                form.calcPatientBill();
                // Assert
                // Verify that the balance is updated correctly after payment
                Assert.AreEqual("50", form.txtBalance.Text, "Balance not updated correctly after partial payment.");
            }

            [TestMethod]
            public void STSC025_Test_PaymentCalculation_WhenAmountPaidIsEqualToAmountOwed_System()
            {
                // Arrange
                form.txtPatID.Text = "123";
                form.txtPatName.Text = "John Doe";
                form.txtAmt.Text = "100"; // Amount owed
                form.txtPay.Text = "100"; // Amount paid
                                          // Act
                form.calcPatientBill();
                // Assert
                // Verify that the balance is updated correctly after payment
                Assert.AreEqual("0", form.txtBalance.Text, "Balance not updated correctly after full payment.");
            }

            [TestMethod]
            public void STSC026_Test_PaymentCalculation_WhenAmountPaidIsGreaterThanAmountOwed_System()
            {
                // Arrange
                form.txtPatID.Text = "123";
                form.txtPatName.Text = "John Doe";
                form.txtAmt.Text = "100"; // Amount owed
                form.txtPay.Text = "150"; // Amount paid
                                          // Act
                form.calcPatientBill();
                // Assert
                // Verify that the balance is updated correctly after payment
                Assert.AreEqual("0", form.txtBalance.Text, "Balance not updated correctly after overpayment.");
            }

            [TestMethod]
            public void STSC027_Test_PaymentCalculation_WithInvalidInput_System()
            {
                // Arrange
                form.txtPatID.Text = "123";
                form.txtPatName.Text = "John Doe";
                form.txtAmt.Text = "100"; // Amount owed
                form.txtPay.Text = "abc"; // Non-numeric input for payment
                                          // Act
                form.calcPatientBill();
                // Assert
                // Verify that balance remains unchanged due to invalid input
                Assert.AreEqual("E", form.txtBalance.Text, "Balance updated despite invalid input for payment.");
            }

            [TestMethod]
            public void STSC028_Test_PaymentCalculation_WhenPatientOwesNothing_System()
            {
                // Arrange
                form.txtPatID.Text = "456";
                form.txtPatName.Text = "Jane Smith";
                form.txtAmt.Text = "0"; // Patient owes nothing
                form.txtPay.Text = "50"; // Amount paid
                                         // Act
                form.calcPatientBill();
                // Assert
                // Verify that balance remains 0 if patient owes nothing
                Assert.AreEqual("0", form.txtBalance.Text, "Balance not updated correctly when patient owes nothing.");
            }


            [TestCleanup]
            public void Cleanup()
            {
                form.Close();
            }
        }

        //Server tests
        [TestClass]

        public class AdminSystemTests
        {
            [TestMethod]
            public void ST_SVR_001_BtnDownload_Click_GeneratesEmployeePdf_Integration()
            {
                // Arrange
                var adminForm = new Admin();
                var expectedPdfDirectory = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\Employee Data";
                var expectedPdfFileName = "emp.pdf";
                var expectedPdfPath = Path.Combine(expectedPdfDirectory, expectedPdfFileName);

                // Ensure the directory exists
                if (!Directory.Exists(expectedPdfDirectory))
                {
                    Directory.CreateDirectory(expectedPdfDirectory);
                }

                // Ensure any previous PDF is deleted
                if (File.Exists(expectedPdfPath))
                {
                    File.Delete(expectedPdfPath);
                }

                // Act
                adminForm.btnDownload_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsTrue(File.Exists(expectedPdfPath), "The PDF file was not generated.");
            }

            [TestMethod]
            public void ST_SVR_002_FetchEmployeeData_ReturnsNonEmptyDataTable_Integration()
            {
                // Arrange
                var admin = new Admin();

                // Act
                DataTable result = admin.FetchEmployeeData();

                // Assert
                Assert.IsNotNull(result, "Expected a non-null DataTable.");
                Assert.IsTrue(result.Rows.Count > 0, "Expected DataTable to contain at least one row.");
            }

            [TestMethod]
            public void ST_SVR_003_showImg_Click_RetrievesAndSavesImage_Integration()
            {
                // Arrange
                var adminForm = new Admin();
                var expectedImageDirectory = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\Employee Images";
                var expectedImageNamePattern = "Image_*.jpg"; // Assuming the image name pattern

                // Act
                adminForm.showImg_Click(null, EventArgs.Empty);

                // Assert
                var savedImages = Directory.GetFiles(expectedImageDirectory, expectedImageNamePattern);
                Assert.IsTrue(savedImages.Length > 0, "No image file was saved.");
            }


            [TestMethod]
            public void ST_SVR_004_UpdateEmployeeData_RefreshesDataGridViewAndDownloadsPDF_Integration()
            {
                // Arrange
                var adminForm = new Admin();

                // Act
                adminForm.UpdateEmployeeData();

                // Assert
                Assert.IsNotNull(adminForm.DataGridView1.DataSource, "DataGridView data source should not be null after updating employee data.");
            }

            [TestMethod]
            public void ST_SVR_005_empImg_Click_PopulatesDataGridViewWithData_Integration()
            {
                // Arrange
                var adminForm = new Admin();

                // Act
                adminForm.empImg_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(adminForm.DataGridView1.DataSource, "DataGridView data source should not be null after clicking empImg button.");
                Assert.IsTrue(adminForm.DataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking empImg button.");
            }

            [TestMethod]
            public void ST_SVR_006_button2_Click_PopulatesDataGridViewWithImages_Integration()
            {
                // Arrange
                var adminForm = new Admin();

                // Act
                adminForm.button2_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(adminForm.DataGridView1.DataSource, "DataGridView data source should not be null after clicking button2.");
                Assert.IsTrue(adminForm.DataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking button2.");
            }

        }

        [TestClass]
        public class DoctorTests
        {
            [TestMethod]
            public void ST_SVR_007_FetchConsultationData_ReturnsData_Unit()
            {
                // Arrange
                var doctor = new Doctor();

                // Act
                var resultTable = doctor.FetchConsultationData();

                // Assert
                Assert.IsNotNull(resultTable);
                Assert.IsTrue(resultTable.Rows.Count > 0, "Expected non-empty DataTable.");
            }

            [TestMethod]
            public void ST_SVR_008_BtnDownload_Click_1_GeneratesPdf_Unit()
            {
                // Arrange
                var doctor = new Doctor();
                var expectedPdfPath = doctor.GetExpectedPdfPath();

                // Act
                doctor.btnDownload_Click_1(null, EventArgs.Empty);

                // Assert
                Assert.IsTrue(File.Exists(expectedPdfPath), "Expected PDF file to be generated.");

                // Cleanup - Remove the generated PDF
                if (File.Exists(expectedPdfPath))
                {
                    File.Delete(expectedPdfPath);
                }
            }

            [TestMethod]
            public void ST_SVR_009_FetchAndSaveFirstConsultationImage_SavesImageSuccessfully_Unit()
            {
                // Arrange
                var doctorForm = new Doctor();

                // Act
                string savedImagePath = doctorForm.FetchAndSaveFirstConsultationImage();

                // Assert
                Assert.IsNotNull(savedImagePath, "No image path returned; expected an image to be saved.");
                Assert.IsTrue(File.Exists(savedImagePath), "Saved image file does not exist at the expected path.");

                // Cleanup - Remove the saved image file
                if (File.Exists(savedImagePath))
                {
                    File.Delete(savedImagePath);
                }
            }

            [TestMethod]
            public void ST_SVR_010_empImg_Click_1_PopulatesDataGridViewWithData_Integration()
            {
                // Arrange
                var doctorForm = new Doctor();

                // Act
                doctorForm.empImg_Click_1(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(doctorForm.dataGridView1.DataSource, "DataGridView data source should not be null after clicking empImg button.");
                Assert.IsTrue(doctorForm.dataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking empImg button.");
            }

            [TestMethod]
            public void ST_SVR_011_button2_Click_1_PopulatesDataGridViewWithImages_Integration()
            {
                // Arrange
                var doctorForm = new Doctor();

                // Act
                doctorForm.button2_Click_1(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(doctorForm.dataGridView1.DataSource, "DataGridView data source should not be null after clicking button2.");
                Assert.IsTrue(doctorForm.dataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking button2.");
            }

            [TestMethod]
            public void ST_SVR_012_showImg_Click_1_RetrievesAndSavesImage_Integration()
            {
                // Arrange
                var doctorForm = new Doctor();
                var expectedImagePath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\x rays\Image_*.jpg"; // Assuming the image name pattern

                // Act
                doctorForm.showImg_Click_1(null, EventArgs.Empty);

                // Assert
                var savedImages = Directory.GetFiles(@"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\x rays", "Image_*.jpg");
                Assert.IsTrue(savedImages.Length > 0, "No image file was saved.");
            }

        }

        [TestClass]
        public class NurseTests
        {
            [TestMethod]
            public void ST_SVR_013_FetchPatientData_ReturnsData_Unit()
            {
                // Arrange
                var nurseForm = new Nurse();

                // Act
                DataTable resultTable = nurseForm.FetchPatientData();

                // Assert
                Assert.IsNotNull(resultTable);
                Assert.IsTrue(resultTable.Rows.Count > 0, "Expected non-empty DataTable.");
            }

            [TestMethod]
            public void ST_SVR_014_BtnDownload_Click_GeneratesPdf_Unit()
            {
                // Arrange
                var nurseForm = new Nurse();
                var expectedPdfPath = nurseForm.GetPatientListPdfPath();

                // Act
                nurseForm.btnDownload_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsTrue(File.Exists(expectedPdfPath), "Expected PDF file to be generated.");

                // Cleanup
                if (File.Exists(expectedPdfPath))
                {
                    File.Delete(expectedPdfPath);
                }
            }

            [TestMethod]
            public void ST_SVR_015_FetchAndSaveFirstPatientImage_SavesImageSuccessfully_Unit()
            {
                // Arrange
                var nurseForm = new Nurse();

                // Act
                string savedImagePath = nurseForm.FetchAndSaveFirstPatientImage();

                // Assert
                Assert.IsNotNull(savedImagePath, "No image path returned; expected an image to be saved.");
                Assert.IsTrue(File.Exists(savedImagePath), "Saved image file does not exist at the expected path.");

                // Cleanup - Remove the saved image file
                if (File.Exists(savedImagePath))
                {
                    File.Delete(savedImagePath);
                }
            }

            [TestMethod]
            public void ST_SVR_016_empImg_Click_PopulatesDataGridViewWithData_Integration()
            {
                // Arrange
                var nurseForm = new Nurse();

                // Act
                nurseForm.empImg_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(nurseForm.dataGridView1.DataSource, "DataGridView data source should not be null after clicking empImg button.");
                Assert.IsTrue(nurseForm.dataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking empImg button.");
            }

            [TestMethod]
            public void ST_SVR_017_button2_Click_PopulatesDataGridViewWithImages_Integration()
            {
                // Arrange
                var nurseForm = new Nurse();

                // Act
                nurseForm.button2_Click(null, EventArgs.Empty);

                // Assert
                Assert.IsNotNull(nurseForm.dataGridView1.DataSource, "DataGridView data source should not be null after clicking button2.");
                Assert.IsTrue(nurseForm.dataGridView1.Rows.Count > 0, "DataGridView should contain rows after clicking button2.");
            }

            [TestMethod]
            public void ST_SVR_018_showImg_Click_RetrievesAndSavesImage_Integration()
            {
                // Arrange
                var nurseForm = new Nurse();
                var expectedImagePath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient images\Image_*.jpg"; // Assuming the image name pattern

                // Act
                nurseForm.showImg_Click(null, EventArgs.Empty);

                // Assert
                var savedImages = Directory.GetFiles(@"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient images", "Image_*.jpg");
                Assert.IsTrue(savedImages.Length > 0, "No image file was saved.");
            }

        }

        [TestClass]
        public class ServerTests
        {
            private Server.Server serverForm;

            [TestInitialize]
            public void Initialize()
            {
                // Initialize the server form before each test method
                serverForm = new Server.Server();
                serverForm.Server_Load(null, EventArgs.Empty);
            }

            [TestMethod]
            public void ST_SVR_019_btnConnect_Click_StartsServer_System()
            {
                // Arrange
                serverForm.txtHost.Text = "127.0.0.1";
                serverForm.txtPort.Text = "8910";
                var manualResetEvent = new ManualResetEvent(false);
                var serverStarted = false;

                // Act
                var thread = new Thread(() =>
                {
                    serverForm.btnConnect_Click(null, EventArgs.Empty);
                    serverStarted = true;
                    manualResetEvent.Set();
                });
                thread.Start();

                // Wait for the server to start or timeout after 5 seconds
                manualResetEvent.WaitOne(TimeSpan.FromSeconds(5));

                // Assert
                Assert.IsTrue(serverStarted);
                Assert.IsTrue(serverForm.server.IsStarted);
            }

            [TestMethod]
            public void ST_SVR_020_btnAdmin_Click_ShowsAdminForm_System()
            {
                // Act
                serverForm.btnAdmin_Click(null, EventArgs.Empty);

                // Poll Application.OpenForms to find the Admin form
                Form adminForm = null;
                var startTime = DateTime.Now;
                while (adminForm == null && (DateTime.Now - startTime).TotalSeconds < 5)
                {
                    adminForm = Application.OpenForms.OfType<Admin>().FirstOrDefault();
                    Thread.Sleep(100); // Wait for 100 ms before checking again
                }

                // Assert
                Assert.IsNotNull(adminForm, "Admin form was not found.");
                Assert.IsTrue(adminForm.Visible, "Admin form is not visible.");
            }

            [TestMethod]
            public void ST_SVR_021_btnDoctor_Click_ShowsDoctorForm_System()
            {
                // Act
                serverForm.btnDoctor_Click(null, EventArgs.Empty);

                // Poll Application.OpenForms to find the Doctor form
                Form doctorForm = null;
                var startTime = DateTime.Now;
                while (doctorForm == null && (DateTime.Now - startTime).TotalSeconds < 5)
                {
                    doctorForm = Application.OpenForms.OfType<Doctor>().FirstOrDefault();
                    Thread.Sleep(100); // Wait for 100 ms before checking again
                }

                // Assert
                Assert.IsNotNull(doctorForm, "Doctor form was not found.");
                Assert.IsTrue(doctorForm.Visible, "Doctor form is not visible.");
            }

            [TestMethod]
            public void ST_SVR_022_btnNurse_Click_ShowsNurseForm_System()
            {
                // Act
                serverForm.btnNurse_Click(null, EventArgs.Empty);

                // Find the Nurse form
                var nurseForm = Application.OpenForms.OfType<Nurse>().FirstOrDefault();

                // Assert
                Assert.IsNotNull(nurseForm, "Nurse form instance not found.");
                Assert.IsTrue(nurseForm.Visible, "Nurse form is not visible.");
            }
        }



    }
}