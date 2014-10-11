using System;
using System.Windows.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace Client
{
    static class Program
    {
        public static MobileServiceClient TableClient = new MobileServiceClient("http://localhost:57771/");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
