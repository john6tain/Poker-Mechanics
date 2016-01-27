using System;
using System.Windows.Forms;

namespace Poker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
              
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                string message = e.Message.ToString();

                MessageBox.Show(message,  "There was an error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
