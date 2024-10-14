using System;
using System.IO.Ports;  // Allows communication with the serial port
using System.Linq; // Needed for COM port check
using System.Diagnostics; // for debugging can get rid of it later

namespace Carduino.ArduinoInterface
{
    public class ArduinoDriver
    {
        // will have to change this to be the correct COM port that that arduino
        // is using, can check device manager for this
        public string comPort = "COM6";

        SerialPort? serialPort = null;  // Must initialize to null because reference type

        // Method to open the port, send "0", then close the port
        public async Task lockBox(Label UserOutput)
        {
            string[] availablePorts = SerialPort.GetPortNames();
            foreach (string port in availablePorts)
            {
                Debug.WriteLine($"Available port: {port}");
            }

            if (!SerialPort.GetPortNames().Contains(comPort))
            {
                UserOutput.Text = "Error: " + comPort + " is not available.";
                return;
            }

            serialPort = new SerialPort(comPort, 9600);

            try
            {
                serialPort.Open();

                await Task.Run(() =>
                {
                    serialPort.Write("0");  // This will now run on a separate thread
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                UserOutput.Text = "Error: Access denied to the COM port.";
                Debug.WriteLine($"Access denied: {ex.Message}");
            }
            catch (IOException ex)
            {
                UserOutput.Text = "Error: I/O error occurred while communicating with the COM port.";
                Debug.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                UserOutput.Text = "Error: " + ex.Message;
                Debug.WriteLine($"General error: {ex.Message}");
            }
            finally
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
        }

        // Method to open the port, send "1", then close the port
        public async Task unlockBox(Label UserOutput)
        {
            // Check if COM port is available
            if (!SerialPort.GetPortNames().Contains(comPort))
            {
                UserOutput.Text = "Error: " + comPort + " is not available.";
                return;
            }

            // Opens the serial port and initializes to the correct baud rate of the 
            // Arduino serial port baud rate
            serialPort = new SerialPort(comPort, 9600);

            try
            {
                serialPort.Open();  // Open the serial port

                await Task.Run(() =>
                {
                    serialPort.Write("1");  // Send "1" to the Arduino
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                UserOutput.Text = "Error: Access denied to the COM port.";
                Debug.WriteLine($"Access denied: {ex.Message}");
            }
            catch (IOException ex)
            {
                UserOutput.Text = "Error: I/O error occurred while communicating with the COM port.";
                Debug.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                UserOutput.Text = "Error: " + ex.Message;
                Debug.WriteLine($"General error: {ex.Message}");
            }
            finally
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();  // Always close the port
                }
            }
        }

    }
}
