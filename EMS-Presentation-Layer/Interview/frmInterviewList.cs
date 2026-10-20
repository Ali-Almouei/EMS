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
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.Interview
{
    public partial class frmInterviewList : Form
    {
        public frmInterviewList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInterviewList_Load(object sender, EventArgs e)
        {
            dgvInterviewList.DataSource=clsInterviews.GetAllInterviews(); 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PersonID = (int)dgvInterviewList.CurrentRow.Cells[1].Value;
            if(clsEmployees.IsEmployeeExistByPersonID(PersonID))
                updateToolStripMenuItem.Enabled = false;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateInterview gg = new frmUpdateInterview((int)dgvInterviewList.CurrentRow.Cells[0].Value);
            gg.ShowDialog();
            frmInterviewList_Load(null, null);
        }

        private void hirePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DepartmentID =-1,
             LevelID=-1  ;
            int PersonID = (int)dgvInterviewList.CurrentRow.Cells[1].Value;
            clsInterviewAppointmnets Appointment = clsInterviewAppointmnets.FindAppointment((int)dgvInterviewList.CurrentRow.Cells[5].Value);
            if(Appointment != null)
            {
                 DepartmentID=Appointment.DepartmentID;
                 LevelID = Appointment.JobLeveleID;
            }
            if(clsEmployees.HireEmployeer(DateTime.Now,DepartmentID,LevelID,1,PersonID,clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("Yes");
            }
        }
    }
}
