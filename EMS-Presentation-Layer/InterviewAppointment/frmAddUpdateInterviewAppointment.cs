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

namespace EMS_Presentation_Layer.InterviewAppointment
{
    public partial class frmAddUpdateInterviewAppointment : Form
    {
        private int _AppointmentID;
        private clsInterviewAppointmnets _Appointment;
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public frmAddUpdateInterviewAppointment(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            Mode = enMode.Update;
        }
        public frmAddUpdateInterviewAppointment()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        private void _FillComboBoxWithData()
        {
            DataTable dt = clsDepartments.GetAllDepartmets();
            foreach (DataRow dr in dt.Rows)
            {
                cbDepartments.Items.Add(dr["DepartmentName"]);
            }

            dt.Clear();
            dt=clsJobLevels.GetAllLevels();
            foreach (DataRow dr in dt.Rows)
            {
                cbJobLevels.Items.Add(dr["LevelName"]);
            }
        }

        private void _RestControls()
        {
            _FillComboBoxWithData();
            txtNotes.Text = "";
            cbDepartments.SelectedIndex = 0;
            cbJobLevels.SelectedIndex = 0;
            chkIsLocked.Checked = false;
            lblCreatedDate.Text = "[??]";
            lblID.Text = "[??]";
            ctrlPesonCardWithFilter1.ResetControls();
            if (Mode == enMode.AddNew)
            {
                _Appointment = new clsInterviewAppointmnets();
                lblCreatedDate.Text = DateTime.Now.ToString("dd/M/yyyy");
            }
        }

        public void LoadData()
        {
            _Appointment = clsInterviewAppointmnets.FindAppointment(_AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show("Not Found");
                return;
            }
            lblCreatedDate.Text = _Appointment.CreatedDate.ToString("dd/M/yyyy");
            txtNotes.Text = _Appointment.Notes;
            dtpAppointmentDate.Value = _Appointment.CreatedDate;
            cbDepartments.SelectedIndex = _Appointment.DepartmentID - 1;
            cbJobLevels.SelectedIndex=_Appointment.JobLeveleID - 1;
            chkIsLocked.Checked= _Appointment.IsLocked;
            ctrlPesonCardWithFilter1.LoadPersonInfo(_Appointment.PersonID);
            lblID.Text=_Appointment.AppointmentID.ToString();



        }

        private void frmAddUpdateInterviewAppointment_Load(object sender, EventArgs e)
        {
            _RestControls();
            if (Mode == enMode.Update)
                LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
                { return; }

            _Appointment.AppointmentDate=dtpAppointmentDate.Value;
            _Appointment.PersonID=ctrlPesonCardWithFilter1.PersonID;
            _Appointment.DepartmentID = cbDepartments.SelectedIndex + 1;
            _Appointment.JobLeveleID = cbJobLevels.SelectedIndex + 1;
            _Appointment.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Appointment.Notes=txtNotes.Text;
            _Appointment.IsLocked= chkIsLocked.Checked;
            if(_Appointment.Save())
            {
                MessageBox.Show("Data saved Succsesfuly");
                lblID.Text=_Appointment.AppointmentID.ToString() ;
            }
            else
            {
                MessageBox.Show("Erorr");

            }








        }

        private void ctrlPesonCardWithFilter1_OnPersonSelected(object sender, People.Controls.ctrlPesonCardWithFilter.onPersonSelectEventArgs e)
        {
            if(clsInterviewAppointmnets.IsPersonHasActiveAppointment(e.PersonID))
            {
                MessageBox.Show(" This Person Has An Active Appointmenr");
                
                this.Close();

            }
            if (clsEmployees.IsEmployeeExistByPersonID(e.PersonID))
            {
                MessageBox.Show(" This Person Already An Employeer ");

                this.Close();
            }
        }
    }
}