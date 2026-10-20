using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS_Presentation_Layer.Employees
{
    public partial class frmEmployeeIinfo : Form
    {
        int employeeID;
        public frmEmployeeIinfo(int EmployeeID)
        {
            InitializeComponent();
            employeeID = EmployeeID;
        }

        private void frmEmployeeIinfo_Load(object sender, EventArgs e)
        {
            ctrlEmployeeInfo1.LoadEmployeerInfo(employeeID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
