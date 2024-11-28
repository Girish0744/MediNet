using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LoginFormTest
{
    [TestClass]
    public class LoginFormTests
    {
        [TestMethod]
        public void TestLoginForm()
        {
            // Start the application
            ApplicationUnderTest app = ApplicationUnderTest.Launch(@"C:\Users\giris\OneDrive - Conestoga College\BCS Sem 4\Project 4 Mobiled and Networked Systems\MediNet+\hospital-app\Hospital app\Onana Hospital Management System");

            // Find the Login form
            var loginForm = new WinWindow();
            loginForm.SearchProperties.Add(WinWindow.PropertyNames.Name, "Login - MediNet+");
            loginForm.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "#32770");
            loginForm.WindowTitles.Add("Login - MediNet+");

            // Find the username text box
            var usernameTextBox = new WinEdit(loginForm);
            usernameTextBox.SearchProperties.Add(WinEdit.PropertyNames.Name, "txtUsername");

            // Find the password text box
            var passwordTextBox = new WinEdit(loginForm);
            passwordTextBox.SearchProperties.Add(WinEdit.PropertyNames.Name, "txtPassword");

            // Find the login button
            var loginButton = new WinButton(loginForm);
            loginButton.SearchProperties.Add(WinButton.PropertyNames.Name, "button1");

            // Find the cancel button
            var cancelButton = new WinButton(loginForm);
            cancelButton.SearchProperties.Add(WinButton.PropertyNames.Name, "button2");

            // Find the combo box
            var comboBox = new WinComboBox(loginForm);
            comboBox.SearchProperties.Add(WinComboBox.PropertyNames.Name, "comboBox1");

            // Enter a username and password
            usernameTextBox.Text = "testuser";
            passwordTextBox.Text = "testpassword";

            // Select an item from the combo box
            comboBox.Select("Administrator");

            // Click the login button
            loginButton.Click();

            // Verify that the main form is displayed
            var mainForm = new WinWindow();
            mainForm.SearchProperties.Add(WinWindow.PropertyNames.Name, "MediNet+");
            mainForm.WaitForControlExist();

            // Close the application
            app.Close();
        }
    }
}