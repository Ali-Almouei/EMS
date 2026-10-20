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

namespace EMS_Presentation_Layer.Employees.Controls
{
    public partial class ctrlEmployeeInfo : UserControl
    {
        private int _EmployeeeID;
        private clsEmployees _Employee;

        public int EmployeeID
        {
            get { return _EmployeeeID; }


        } 
        public clsEmployees Employee
        {
            get { return _Employee; }
        }

        public ctrlEmployeeInfo()
        {
            InitializeComponent();
        }

        private void _ResetControls()
        {
            lblEmployeeID.Text = "[??]";
            lblStatus.Text = "[??]";
            lblDepartment.Text = "[??]";
            lblJobLevel.Text = "[??]";
            lblHireDate.Text = "[??]";
            lblExpiredDate.Text = "[??]";
            lblCreatedByUser.Text = "[??]";
            ctrlPersonInfoCard1._ResetValue();

        }

        private void _LoadData()
        {
           
            lblEmployeeID.Text=_Employee.EmployeeID.ToString();
            lblStatus.Text=_Employee.EmployerStatus.StatusName;
            lblDepartment.Text=_Employee.DepartmentInfo.DepartmentName;
            lblJobLevel.Text=_Employee.JobLevels.LevelName;
            lblHireDate.Text=_Employee.HireDate.ToString("dd/M/yyyy");
            lblExpiredDate.Text=_Employee.ExpiredDate==null?"NULL":_Employee.ExpiredDate.ToString();
            lblCreatedByUser.Text=_Employee.CreatedUserInfo.UserName;
            ctrlPersonInfoCard1.LoadPesonInfo(_Employee.PersonID);



        }

        public void LoadEmployeerInfo(int EmployeeID)
        {
            _EmployeeeID = EmployeeID;
            _Employee = clsEmployees.FindEmployee(_EmployeeeID);
            if (_Employee == null)
            {
                _ResetControls();
                MessageBox.Show("The Employeer With ID: " + _EmployeeeID.ToString());
                return;
            }
            _LoadData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}