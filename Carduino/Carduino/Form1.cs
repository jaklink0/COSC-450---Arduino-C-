using System;
using System.Windows.Forms;
using Carduino.ArduinoInterface;

namespace Carduino
{
    public partial class Form1 : Form
    {
        private ArduinoDriver arduinoDriver;
        private string correctPassword = "1234";  // The correct password
        private int attempts = 0;  // Track incorrect attempts
        private bool isLockedOut = false;  // Check if locked out
        private int lockoutTime = 5;  // Lockout time in seconds
        private bool inputCorrectPassword = false;


        public Form1()
        {
            InitializeComponent();  // Initializes UI components
            arduinoDriver = new ArduinoDriver();
        }

        // This method clears the input box when the user clicks into it
        private void UserInput_Enter(object sender, EventArgs e)
        {
                UserInput.Text = ""; // Clear the default text
                UserInput.ForeColor = Color.Black; // Set text color to black
        }

        // This method replaces the default text to enter password when the user
        // Clicks out of the text box but it also checks that the current box is not
        // The focus first or it will never take a correct password
        private void UserInput_Leave(object sender, EventArgs e)
        {
            if(!(this.ActiveControl is Button))
            {
                UserInput.Text = "Enter Password"; // Restore default text
                UserInput.ForeColor = Color.Gray; // Reset text color to gray
            }
        }


        // Method to check the password input by the user
        private void CheckPassword()
        {
            string userInput = UserInput.Text;  // Get the text from the userInput TextBox

            if (isLockedOut)
            {
                UserOutput.Text = "Still locked out! Please wait until the countdown is complete.";
                return;
            }

            if (userInput == correctPassword)
            {
                UserOutput.Text = "Access Granted";
                attempts = 0;  // Reset attempts on success
                inputCorrectPassword = true;
            }
            else
            {
                attempts++;
                UserOutput.Text = $"Incorrect password. Remaining attempts: {3 - attempts}";
                inputCorrectPassword=false;

                if (attempts >= 3)
                {
                    // Lock the user out
                    isLockedOut = true;
                    UserOutput.Text = "Too many incorrect attempts. Locked out for 5 seconds.";
                    StartLockoutCountdown();
                }
            }
        }

        // Start the lockout countdown
        private void StartLockoutCountdown()
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;  // 1 second intervals
            timer.Tick += (sender, e) =>
            {
                lockoutTime--;
                UserOutput.Text = $"Locked out for {lockoutTime} more seconds.";
                if (lockoutTime <= 0)
                {
                    timer.Stop();
                    lockoutTime = 5;  // Reset lockout time for future
                    isLockedOut = false;
                    attempts = 0;  // Reset attempts after lockout
                    UserOutput.Text = "Lockout over. You can try again.";
                }
            };
            timer.Start();
        }

        // Event handler for the Unlock button
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            CheckPassword();  // Call to check password
            if(inputCorrectPassword == true)
            {
                arduinoDriver.unlockBox(UserOutput);
            }
        }

        // Event handler for the Lock button
        private void btnLock_Click(object sender, EventArgs e)
        {
            CheckPassword();  // Call to check password
            if(inputCorrectPassword == true)
            {
                arduinoDriver.lockBox(UserOutput);
            }
        }
    }
}
