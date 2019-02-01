using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sotyafoglalo
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
            Application.Run(new Bevitel());
            //Application.Run(new mainLayout());
        }

    }

}
