using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;

namespace EMS_Presentation_Layer.SalaryLog
{
    public partial class frmSalaryLogList : Form
    {
        DataTable dt;
        public frmSalaryLogList()
        {
            InitializeComponent();
        }

        private async void frmSalaryLogList_Load(object sender, EventArgs e)
        {
            dt = await clsSalarylog.GetAllSalaryLog(DateTime.Now);
            dgvSalaryLogList.DataSource=dt;
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvSalaryLogList.DataSource = await clsSalarylog.GetAllSalaryLog(dateTimePicker1.Value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
