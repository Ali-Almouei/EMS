using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Presentation_Layer.Adjustments;
using EMS_Presentation_Layer.Employees;
using EMS_Presentation_Layer.People;
using EMS_Presentation_Layer.Users;

namespace EMS_Presentation_Layer
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
            Application.Run(new frmLogin());
        }
    }
}
