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

namespace EMS_Presentation_Layer.InterviewAppointment.Controls
{
    public partial class ctrlAppointmentCardInfo : UserControl
    {
        private int _AppointmentID;
        private clsInterviewAppointmnets _Appointment;
        public ctrlAppointmentCardInfo()
        {
            InitializeComponent();
        }
        public int AppointmentID
        {
            get { return _AppointmentID; }
        }

        public void Resetcontrols()
        {
            lblApointmentID.Text = "[?]";
            lblAppointmentDate.Text = "[?]";
            lblCreatedDate.Text = "[?]";
            lblPersonID.Text = "[?]";
            lblDepartment.Text = "[?]";
            lblLevelName.Text = "[?]";
            lblCreatedByUser.Text = "[?]";
        }
        public void LoadData(int AppointmentID)
        {
            _AppointmentID= AppointmentID;
            _Appointment=clsInterviewAppointmnets.FindAppointment(AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show("We Can not Find Appointment with ID: " + AppointmentID.ToString());
                return;
            }
            lblApointmentID.Text= _AppointmentID.ToString();
            lblAppointmentDate.Text = _Appointment.AppointmentDate.ToString("dd/M/yyyy");
            lblCreatedDate.Text = _Appointment.CreatedDate.ToString("dd/M/yyyy");
            lblDepartment.Text=_Appointment.DepartmentInfo.DepartmentName;
            lblLevelName.Text=_Appointment.JobLevelInfo.LevelName;
            lblPersonID.Text= _Appointment.PersonID.ToString();
            lblCreatedByUser.Text=_Appointment.UserInfo.UserName;









        }




    }




}
