using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Server
{
    static class ServerStartup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static ServerForm frmServer;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmServer = new ServerForm();
            Application.Run(frmServer);
        }
    }
}
