﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHairdresserSalon_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //LoginHairdresser frm = new LoginHairdresser();

            //if (frm.ShowDialog() == DialogResult.OK)

                Application.Run(new MainForm());
        }
    }
}
