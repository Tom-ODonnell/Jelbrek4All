using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jelbrek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists("c:/Jelbrek4All"))
            {
                if (DialogResult.OK== MessageBox.Show("Jelbrek4All was not installed correctly... please reinstall using the isntaller.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error))
                {
                    System.Environment.Exit(1);
                }
            }
        }

        public static string ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();

            process.Close();
            return output.ToString();
        }
    }
}
