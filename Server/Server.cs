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

using System.Xml.Schema;
namespace Server
{
    public partial class Server : Form
    {
        public SimpleTcpServer server;
        public List<string> loggedInUsers;


        public Server()
        {
            InitializeComponent();
            loggedInUsers = new List<string>();
            
        }


       

        public void Server_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; // Enter key
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                string message = e.MessageString.Trim();
                
                // Check if the message indicates a user login
                if (message.Contains("has logged in as"))
                {
                    // Extract the username from the message
                    int startIndex = message.IndexOf(':') + 1;
                    string username = message.Substring(startIndex).Trim();

                    // Add the username to the list of logged-in users
                    if (!loggedInUsers.Contains(username))
                    {
                        loggedInUsers.Add(username);
                        UpdateUserList();
                    }
                }

                txtStatus.Text = message;
                e.ReplyLine($"You said: {message}");
            });



        }

        public void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Append "Server Starting ...." message
                 txtStatus.Items.Add("Server Starting ....");
               
                // Start the server
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);
                server.Start(ip, Convert.ToInt32(txtPort.Text));

                // Append "Server Started" message if the server starts successfully
            
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                MessageBox.Show("Error starting server: " + ex.Message);
            }
        }



        public void UpdateUserList()
        {
            // Clear the existing user list
            txtStatus.Items.Clear();

            // Add the updated list of logged-in users to the ListBox
            foreach (string user in loggedInUsers)
            {
                txtStatus.Items.Add(user);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void btnAdmin_Click(object sender, EventArgs e)
        {
            var newform = new Admin();
              newform.Show();
        }

        public void btnNurse_Click(object sender, EventArgs e)
        {
            var newform = new Nurse();
            newform.Show();
        }

        public void btnDoctor_Click(object sender, EventArgs e)
        {
            var newform = new Doctor();
            newform.Show(); // or newform.ShowDialog();
        }


        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}

