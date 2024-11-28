using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using SelectPdf;


namespace Server
{
    public partial class Nurse : Form
    {
        public Nurse()
        {
            InitializeComponent();
        }

        private void Nurse_Load(object sender, EventArgs e)
        {

        }

        public void empImg_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "SELECT TOP (1000) [id] ,[patID]            ,[pSname]      ,[pFname]      ,[pOname]      ,[pGender]      ,[pOccupation]      ,[pDOB]      ,[pResidenAddres]      ,[pNationality]      ,[pContact]      ,[pEmail]      ,[pDateRegistered]      ,[pTimeRegistered]      ,[pGuardianName]      ,[pGuardianPhone]      ,[pGuardianRelateAs]  FROM[dbOHMS].[dbo].[tblPatient]";

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
                string Query = "SELECT TOP (1000) [pPhoto] FROM [dbOHMS].[dbo].[tblPatient]";
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

        public void showImg_Click(object sender, EventArgs e)
        {


            try
            {
                // Connection string to SQL Server
                string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";

                // SQL query to retrieve images from the database
                string query = "SELECT TOP (1000) [pPhoto] FROM [dbOHMS].[dbo].[tblPatient] ORDER BY [id] DESC";

                string imagePath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient images";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["pPhoto"];
                        string imageName = $"Image_{reader["pPhoto"]}.jpg"; // Customize the image name as per your requirement
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

        public void btnDownload_Click(object sender, EventArgs e)
        {
            // Connection string to SQL Server
            string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";

            /// SQL query to retrieve data from SQL Server
            string query = "SELECT TOP (1000) [id], [patID], [pSname], [pFname], [pOname], [pGender], [pOccupation], [pDOB], [pResidenAddres], [pNationality], [pContact], [pEmail], [pDateRegistered], [pTimeRegistered], [pGuardianName], [pGuardianPhone], [pGuardianRelateAs] FROM [dbOHMS].[dbo].[tblPatient]";

            // Create an HTML string to hold the table structure
            string htmlContent = "<html><head><title>Patient Data</title></head><body><table border='1'><tr><th>ID</th><th>Patient ID</th><th>Last Name</th><th>First Name</th><th>Other Name</th><th>Gender</th><th>Occupation</th><th>Date of Birth</th><th>Residential Address</th><th>Nationality</th><th>Contact</th><th>Email</th><th>Date Registered</th><th>Time Registered</th><th>Guardian Name</th><th>Guardian Phone</th><th>Guardian Relationship</th></tr>";

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
            string pdfPath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient list\patientList.pdf";

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showPdf_TextChanged(object sender, EventArgs e)
        {

        }

        private void imgPath_TextChanged(object sender, EventArgs e)
        {

        }

        // Method to encapsulate the logic for fetching patient data
        public DataTable FetchPatientData()
        {
            DataTable table = new DataTable();
            string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP (1000) [id], [patID], [pSname], [pFname], [pOname], [pGender], [pOccupation], [pDOB], [pResidenAddres], [pNationality], [pContact], [pEmail], [pDateRegistered], [pTimeRegistered], [pGuardianName], [pGuardianPhone], [pGuardianRelateAs] FROM [dbOHMS].[dbo].[tblPatient]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            return table;
        }

        // Method to return the expected path of the PDF
        public string GetPatientListPdfPath()
        {
            return @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient list\patientList.pdf";
        }

        public string FetchAndSaveFirstPatientImage()
        {
            string imagePath = @"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\Final MediNet\hospital-app\Hospital app\Server\patient images";
            string connectionString = "Data Source=BHUTEJAS\\SQLEXPRESS;Initial Catalog=dbOHMS;Integrated Security=True";
            string query = "SELECT TOP (1) [pPhoto] FROM [dbOHMS].[dbo].[tblPatient] ORDER BY [id] DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    byte[] imageData = (byte[])reader["pPhoto"];
                    if (imageData != null && imageData.Length > 0)
                    {
                        // Assuming a naming convention for the image. Adjust as necessary.
                        string imageName = $"PatientImage_{DateTime.Now.Ticks}.jpg";
                        string imagePathWithName = Path.Combine(imagePath, imageName);
                        File.WriteAllBytes(imagePathWithName, imageData);
                        return imagePathWithName; // Return the path for test verification
                    }
                }
            }

            return null; // Indicate no image was saved
        }
    }
}
 

