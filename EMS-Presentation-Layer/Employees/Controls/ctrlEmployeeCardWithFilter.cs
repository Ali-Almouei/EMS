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
using EMS_Presentation_Layer.People.Controls;

namespace EMS_Presentation_Layer.Employees.Controls
{
    public partial class ctrlEmployeeCardWithFilter : UserControl
    {
        public ctrlEmployeeCardWithFilter()
        {
            InitializeComponent();
        }
        private int _EmployeeID;
        private clsEmployees _Employee;


        public clsEmployees EmployeeInfo
        {
            get { return _Employee; }
        }
        public int EmployeeID
        {
            get {  return _EmployeeID
                    ; }
        }

        public class OnEmployeeSelectedEvenArgs : EventArgs
        {
            public int EmoloyeeID { get; set; }
            public DateTime HireDate { get; set; }
            public DateTime? ExpiedDate { get; set; }
            public int Status { get; set; }
            public int PersonID { get; set; }
            public int DepartmentID { get; set; }
            public int JobLevel { get; set; }
            public int CreatedByUserID { get; set; }
            public OnEmployeeSelectedEvenArgs(int EmployeeID, DateTime HireDate, DateTime? ExpiedDate, int Status, int PersonID
                , int DepartmentID, int JobLevelID, int CreatedByUserID)
            {
                this.EmoloyeeID = EmployeeID;
                this.HireDate = HireDate;
                this.ExpiedDate = ExpiedDate;
                this.Status = Status;
                this.PersonID = PersonID;
                this.DepartmentID = DepartmentID;
                this.JobLevel = JobLevel;
                this.CreatedByUserID = CreatedByUserID;
            }

        }

            public event EventHandler<OnEmployeeSelectedEvenArgs> OnEmployeeSelectedEvent;



            protected virtual void RaiseOnEmployeeSelected(OnEmployeeSelectedEvenArgs e)
            {
               OnEmployeeSelectedEvent?.Invoke(this, e);
            }
            public void RaiseOnEmployeeSelected(int EmployeeID, DateTime HireDate, DateTime? ExpiedDate, int Status, int PersonID
                , int DepartmentID, int JobLevelID, int CreatedByUserID)
            {
                RaiseOnEmployeeSelected(new OnEmployeeSelectedEvenArgs(EmployeeID,HireDate,ExpiedDate,Status,PersonID, DepartmentID, JobLevelID, CreatedByUserID));
            }
        
        public void ResetControls()
        {
            lblEmploeeID.Text = "[??]";
            lblStatus.Text = "[??]";
            lblDepartment.Text = "[??]";
            lblJobLevel.Text = "[??]";
            lblHireDate.Text = "[??]";
            lblExpiredDate.Text = "[??]";
            lblCreatedByUser.Text = "[??]";
            lblFullName.Text = "[??]";
            txtFilterValue.Text = "";
            gbFilters.Enabled = true;
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public void LoadData(int EmployeeID)
        {
            _EmployeeID = EmployeeID;

            _Employee = clsEmployees.FindEmployee(_EmployeeID);
            if (_Employee == null)
            {
                ResetControls();
                MessageBox.Show("The Employeer With ID: " + _EmployeeID.ToString());
                return;
            }
            //gbFilters.Enabled = false;   
            txtFilterValue.Text=_EmployeeID.ToString();
            lblEmploeeID.Text = _Employee.EmployeeID.ToString();
            lblStatus.Text = _Employee.EmployerStatus.StatusName;
            lblDepartment.Text = _Employee.DepartmentInfo.DepartmentName;
            lblJobLevel.Text = _Employee.JobLevels.LevelName;
            lblHireDate.Text = _Employee.HireDate.ToString("dd/M/yyyy");
            lblExpiredDate.Text = _Employee.ExpiredDate == null ? "NULL" : _Employee.ExpiredDate.ToString();
            lblCreatedByUser.Text = _Employee.CreatedUserInfo.UserName;
            lblFullName.Text=_Employee.PersonInfo.FullName;
        }


        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "EmployeeID":
                    {
                        LoadData(int.Parse(txtFilterValue.Text.Trim()));
                        
                        break;
                    }
                default:
                    break;
            }

            if(_Employee != null && FilterEnabled)
                RaiseOnEmployeeSelected(_Employee.EmployeeID, _Employee.HireDate, _Employee.ExpiredDate != null ? _Employee.ExpiredDate : null, _Employee.StatusID, _Employee.PersonID,
                    _Employee.DepartmentID, _Employee.LevelID, _Employee.CreatedByUserID);
           



        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void ctrlEmployeeCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
