﻿using System;
using System.Windows.Forms;

namespace CBS.Reinaldo.Reversi
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
            Application.Run(new MainMenu());
            //Application.Run(new Form1());
        }
    }
}
