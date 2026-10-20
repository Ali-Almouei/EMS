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
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.Interview
{
    public partial class frmAddInterview : Form
    {
        private int _AppointmentID;
        
       private clsInterviews _Interview;
        public frmAddInterview(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
        }
       
        private void _ResetControls()
        {
            txtNotes.Text = "";
            rbFail.Checked = false;
            rbPass.Checked = false;
            lblInterviewID.Text = "[?]";
            ctrlAppointmentCardInfo1.LoadData(_AppointmentID);
                _Interview = new clsInterviews();
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateInterview_Load(object sender, EventArgs e)
        {
            _ResetControls();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
            if(rbPass.Checked)
                _Interview.Result = true;
            else
                _Interview.Result = false;
            
            _Interview.Notes = txtNotes.Text;
            
            _Interview.AppointmentID=_AppointmentID;
            _Interview.CreatedBytUserID=clsGlobal.CurrentUser.UserID;
            if(_Interview.Save())
            {
                MessageBox.Show("Yes");
                lblInterviewID.Text = _Interview.IntreviewID.ToString();
            }
            else
            {
                MessageBox.Show("false");

            }

        }
    }
}
