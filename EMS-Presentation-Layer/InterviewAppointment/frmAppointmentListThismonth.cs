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
using EMS_Presentation_Layer.Interview;

namespace EMS_Presentation_Layer.InterviewAppointment
{
    public partial class frmAppointmentListThismonth : Form
    {
        public frmAppointmentListThismonth()
        {
            InitializeComponent();
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAppointmentListThismonth_Load(object sender, EventArgs e)
        {
            dgvAppointmentsThisMonth.DataSource=clsInterviewAppointmnets.GetAllApopintments(DateTime.Now);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvAppointmentsThisMonth.DataSource = clsInterviewAppointmnets.GetAllApopintments(dtpFilter.Value);  
        }

        private void btnAddApointment_Click(object sender, EventArgs e)
        {
            frmAddUpdateInterviewAppointment frmAddUpdateInterviewAppointment = new frmAddUpdateInterviewAppointment();
            frmAddUpdateInterviewAppointment.ShowDialog();
            frmAppointmentListThismonth_Load(null, null);
        }

        private void goToInterviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointmentsThisMonth.CurrentRow.Cells[0].Value;
            frmAddInterview fff= new frmAddInterview(AppointmentID);
            fff.ShowDialog();
            frmAppointmentListThismonth_Load(null,null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsLocked = (bool)dgvAppointmentsThisMonth.CurrentRow.Cells[7].Value;
            goToInterviewToolStripMenuItem.Enabled = !IsLocked;
        }
    }
}
