<<<<<<< HEAD
﻿using System;
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
                Application.Run(new TexasPoker());
            }
            catch (Exception e)
            {
                //TODO: figure out this one ...
            }
        }
    }
}
=======
﻿using System;
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
>>>>>>> bfe2975d034aaf565c78e1f5e9158ebee89b81ce
