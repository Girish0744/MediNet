using System;
using System.Text;
using System.Drawing;

using System.Windows.Forms;
using SimpleTCP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using SelectPdf;

namespace Server
{
    public partial class Admin : Form
    {

        public Admin()
        {
            InitializeComponent();
        }

        public DataGridView DataGridView1 => dataGridView1;

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        public void empImg_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "SELECT TOP (1000) [id], [empCode], [empSname], [empFname], [empOname], [empDOB], [empGender], [empContact], [empEmail], [empNationality], [empDateJoined], [empDepartment], [empDesignation], [empQualification], [empResidenceAddress], [empReferenceName], [empReferenceContact] FROM [dbOHMS].[dbo].[tblEmployees]";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string Query = "SELECT TOP (1000) [epmPhoto] FROM [dbOHMS].[dbo].[tblEmployees]";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        public void btnDownload_Click(object sender, EventArgs e)
        {
            // Connection string to SQL Server
            string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";

            // SQL query to retrieve data from SQL Server
            string query = "SELECT TOP (1000) [id], [empCode], [empSname], [empFname], [empOname], [empDOB], [empGender], [empContact], [empEmail], [empNationality], [empDateJoined], [empDepartment], [empDesignation], [empQualification], [empResidenceAddress], [empReferenceName], [empReferenceContact] FROM [dbOHMS].[dbo].[tblEmployees]";

            // Create an HTML string to hold the table structure
            string htmlContent = "<html><head><title>Employee Data</title></head><body><table border='1'><tr><th>ID</th><th>Employee Code</th><th>Last Name</th><th>First Name</th><th>Other Name</th><th>Date of Birth</th><th>Gender</th><th>Contact</th><th>Email</th><th>Nationality</th><th>Date Joined</th><th>Department</th><th>Designation</th><th>Qualification</th><th>Residence Address</th><th>Reference Name</th><th>Reference Contact</th></tr>";

            // Retrieve data from SQL Server and append it to the HTML content
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    htmlContent += "<tr>";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        htmlContent += "<td>" + reader[i].ToString() + "</td>";
                    }
                    htmlContent += "</tr>";
                }
            }

            // Close the table tag and the HTML document
            htmlContent += "</table></body></html>";

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument pdfDocument = converter.ConvertHtmlString(htmlContent);

            // Path to save the PDF file
            string pdfPath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\Employee Data\emp.pdf";

            // Save the PDF to the specified path
            pdfDocument.Save(pdfPath);

            // Close the PDF document
            pdfDocument.Close();

            // Display a message in the text box
            Console.WriteLine("PDF file generated successfully.");
            Console.WriteLine($"PDF saved at: {pdfPath}");
            // Assuming there is a TextBox called "showPdf" in your UI
            showPdf.Text = $"PDF saved at Employee Data";
        }

        public void showImg_Click(object sender, EventArgs e)
        {


            try
            {
                // Connection string to SQL Server
                string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";

                // SQL query to retrieve images from the database
                string query = "SELECT TOP (1000) [epmPhoto] FROM [dbOHMS].[dbo].[tblEmployees] ORDER BY [id] DESC";

                string imagePath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\Employee Images";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["epmPhoto"];
                        string imageName = $"Image_{Guid.NewGuid()}.jpg";  // Customize the image name as per your requirement
                        string imagePathWithName = Path.Combine(imagePath, imageName);
                        File.WriteAllBytes(imagePathWithName, imageData);
                        imgPath.Text = "Image sent successfully";
                    }
                    else
                    {
                        Console.WriteLine("No image found in the database.");
                    }
                }


            }
            catch (Exception ex)
            {
                // Handle any exceptions and display the error message
                imgPath.Text = $"Error saving images: {ex.Message}";
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = listBox1.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Employee":
                    // Update DataGridView with employee data
                    UpdateEmployeeData();
                    break;
                case "Appointment":
                    // Update DataGridView with appointment data
                    UpdateAppointmentData();
                    break;
                case "Bills":
                    // Update DataGridView with bills data
                    UpdateBillsData();
                    break;
                default:
                    // Handle default case or do nothing
                    break;
            }
        }

        public void UpdateBillsData()
        {
            throw new NotImplementedException();
        }

        private void UpdateAppointmentData()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployeeData()
        {
            try
            {
                // Refresh employee data in the DataGridView
                empImg_Click(null, EventArgs.Empty);

                // Download updated employee data as a PDF
                btnDownload_Click(null, EventArgs.Empty);
              
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"Error updating employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public DataTable FetchEmployeeData()
        {
            DataTable table = new DataTable();
            string ConnectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string Query = "SELECT TOP (1000) [id], [empCode], [empSname], [empFname], [empOname], [empDOB], [empGender], [empContact], [empEmail], [empNationality], [empDateJoined], [empDepartment], [empDesignation], [empQualification], [empResidenceAddress], [empReferenceName], [empReferenceContact] FROM [dbOHMS].[dbo].[tblEmployees]";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    var reader = cmd.ExecuteReader();
                    table.Load(reader);
                }
            }
            return table;
        }

    }
}
