using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;

namespace EMS_Presentation_Layer.Adjustments
{
    public partial class frmListEmployeerAdjustment : Form
    {
        private int _EmployeeID ;
        public frmListEmployeerAdjustment(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
        }

        private async void frmListEmployeerAdjustment_Load(object sender, EventArgs e)
        {
            dgvEmployeerAdjustments.DataSource= await clsAdjustments.GetAllAdjustmentsForEmployeer(_EmployeeID,DateTime.Now); 
            label1.Text= "Adjustments List from Employeer ID: "+_EmployeeID.ToString();
        }
    }
}
