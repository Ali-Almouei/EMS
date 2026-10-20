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
    public partial class frmUpdateInterview : Form
    {
        private int _InterviewID;
        private clsInterviews _Interview;
        public frmUpdateInterview(int InterviewID)
        {
            InitializeComponent();
            _InterviewID = InterviewID;
        }
        private void _ResetValues()
        {
            txtNotes.Text = "";
            rbFail.Checked = false;
            rbPass.Checked = false;
            ctrlAppointmentCardInfo1.Resetcontrols();
            lblInterviewID.Text = "[??]";

        }
        private void _LoadData()
        {
            _Interview=clsInterviews.FindInterview(_InterviewID);
            if(_Interview==null)
            {
                MessageBox.Show("This Intreview Not Found");
                return;
            }
            lblInterviewID.Text=_InterviewID.ToString();
            txtNotes.Text=_Interview.Notes; 
            if(_Interview.Result)
            rbPass.Checked = true;
            else
                rbFail.Checked = true;

            ctrlAppointmentCardInfo1.LoadData(_Interview.AppointmentID);
        }


        private void frmUpdateInterview_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            _Interview.Notes=txtNotes.Text;
            if(rbPass.Checked)
                _Interview.Result=true;
            else
                _Interview.Result=false;    

            _Interview.AppointmentID=ctrlAppointmentCardInfo1.AppointmentID;
            _Interview.CreatedBytUserID = clsGlobal.CurrentUser.UserID;
            if(_Interview.Save())
            {
                MessageBox.Show("Data Updated Succsfuly(:-");
                return;
            }
            else
            {
                MessageBox.Show("Error Was Happend ):-");

            }


        }
    }
}
