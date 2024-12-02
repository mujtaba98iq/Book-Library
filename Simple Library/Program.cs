using Simple_Library.Forms.Books;
using Simple_Library.Forms.BorrowingRecords;
using Simple_Library.Forms.Fines;
using Simple_Library.Forms.Main;
using Simple_Library.Forms.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Library
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmListFines());
        }
    }
}
