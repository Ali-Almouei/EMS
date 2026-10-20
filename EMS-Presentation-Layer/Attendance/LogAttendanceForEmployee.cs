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

namespace EMS_Presentation_Layer.Attendance
{
    public partial class LogAttendanceForEmployee : Form
    {
        private int _AttendanceID;
        private clsAttendance Attendance;
        private DateTime _AttendanceDate;
        enum enMode {AddNew=0,Update=1}
        enMode Mode = enMode.AddNew;
        public LogAttendanceForEmployee(int AttendanceID,DateTime AttendanceDate)
        {
            InitializeComponent();
            _AttendanceID = AttendanceID;
           _AttendanceDate = AttendanceDate;
            Mode = enMode.Update;
        }
        public LogAttendanceForEmployee()
        { 
            InitializeComponent();
            Mode = enMode.AddNew;
        }


        private void _ResetControls()
        {
            ctrlEmployeeCardWithFilter1.ResetControls();
            dtpCheackIn.Value = DateTime.Today.AddHours(7);
            dtpCheackOut.Value = DateTime.Today.AddHours(14);
            dtpCheackIn.MinDate = DateTime.Today.AddHours(7);    // 08:00 صباحاً
            dtpCheackIn.MaxDate = DateTime.Today.AddHours(14);
            dtpCheackOut.MinDate = DateTime.Today.AddHours(7);    // 08:00 صباحاً
            dtpCheackOut.MaxDate = DateTime.Today.AddHours(14);
            cbStatus.SelectedIndex = 0;
            if(Mode==enMode.AddNew)
            {
               dtpCheackOut.Enabled = false;    
                Attendance=new clsAttendance();
            }
            else
            {
                dtpCheackIn.Enabled=false;
                cbStatus.Enabled=false;
            }
        }
        private void _LoadData()
        {
            
            Attendance = clsAttendance.FindAttendance(_AttendanceID, _AttendanceDate);
           
            if( Attendance == null )
            {
                MessageBox.Show("No Attendance with ID: " + _AttendanceID.ToString() + " At " + _AttendanceDate.ToString());
                return;
            }
            dtpCheackIn.Value = DateTime.Today.Add(Attendance.CheackIn);
            if (Attendance.CheakOut != null)
            {
                dtpCheackOut.Value = DateTime.Today.Add(Attendance.CheakOut.Value);

            }
            else
            {
                dtpCheackOut.Value = DateTime.Today.AddHours(14);


            }
            lblDate.Text = DateTime.Now.ToString("dd/M/yyyy");
            lblID.Text = _AttendanceID.ToString();
            cbStatus.SelectedIndex = Attendance.Status;
            ctrlEmployeeCardWithFilter1.LoadData(Attendance.EmployeeID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if(!ValidateChildren()) 
                return;
            

            Attendance.EmployeeID = ctrlEmployeeCardWithFilter1.EmployeeID;
            Attendance.CheackIn =dtpCheackIn.Value.TimeOfDay;
            if(dtpCheackOut.Enabled)
            Attendance.CheakOut = dtpCheackOut.Value.TimeOfDay;
            else
                Attendance.CheakOut= null;
            Attendance.CreatedByUserID=clsGlobal.CurrentUser.UserID;

            if (cbStatus.SelectedIndex == 0)
            Attendance.Status = 0;
            else
                Attendance.Status = 1;

 

            if(Attendance.Save())
            {
                
                lblID.Text=Attendance.AttendanceID.ToString();
                lblDate.Text=_AttendanceDate.ToString();
                MessageBox.Show("Data Saved Sucssesfuly");
            }
            else
            {
                MessageBox.Show("An Error ");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogAttendanceForEmployee_Load(object sender, EventArgs e)
        {
             _ResetControls();
            if(Mode==enMode.Update)
                _LoadData();
        }

        private void ctrlEmployeeCardWithFilter2_OnEmployeeSelectedEvent(object sender, Employees.Controls.ctrlEmployeeCardWithFilter.OnEmployeeSelectedEvenArgs e)
        {
            if(clsAttendance.IsEmployeerHasAttendanceForToday(e.EmoloyeeID,DateTime.Now))
            {
                MessageBox.Show("This Employeer Has An Attendance For Today");
                this.Close();
                return;
            }
        }

        private void dtpCheackIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheackIn.Value > DateTime.Today.AddHours(8))
                cbStatus.SelectedIndex = 1;
            else
                cbStatus.SelectedIndex = 0;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
