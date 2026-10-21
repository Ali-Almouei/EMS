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

namespace EMS_Presentation_Layer.Employees
{
    public partial class frmAddUpdateEmployee : Form
    {
        public frmAddUpdateEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            _Mode=enMode.Update;
        }
        public frmAddUpdateEmployee()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        private int _EmployeeID;
        clsEmployees Employee;
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void _FillDataInComboBoxs()
        {
            DataTable dtAllDepartments=clsDepartments.GetAllDepartmets();
            DataTable dtAllJobLevels=clsJobLevels.GetAllLevels();
            DataTable dtAllStatus=clsStatus.GetAllStatus();
            foreach(DataRow dr in dtAllDepartments.Rows)
            {
                cbDepartment.Items.Add(dr["DepartmentName"]);
            }
            foreach(DataRow ds in dtAllJobLevels.Rows)
            {
                cbLevel.Items.Add(ds["LevelName"]);
            }
            foreach (DataRow df in dtAllStatus.Rows)
            {
                cbStatus.Items.Add(df["StatusName"]);
            }
        }
        private void _LoadData()
        {
            Employee=clsEmployees.FindEmployee(_EmployeeID);
            if (Employee == null)
            {
                MessageBox.Show("We Dont Found The Emoployee");
                return;
            }

            dtpHireDate.Value= Employee.HireDate;
            cbDepartment.SelectedIndex = Employee.DepartmentID - 1;
            cbLevel.SelectedIndex = Employee.LevelID - 1;
            cbStatus.SelectedIndex = Employee.StatusID - 1;
            ctrlPesonCardWithFilter1.LoadPersonInfo(Employee.PersonID);
            dtpExpirDate.Enabled = Employee.ExpiredDate != null;
            if (dtpExpirDate.Enabled)
            {
                dtpExpirDate.Value = Employee.ExpiredDate.Value;
            }

        }
        private void _ResetControls()
        {
            _FillDataInComboBoxs();
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Employee";
                Employee = new clsEmployees();
                tpEmployeeInfo.Enabled = false;
                btnSave.Enabled = false;
                dtpExpirDate.Enabled = false;

                ctrlPesonCardWithFilter1.Focus();
            }
            else
            {
                this.Text = "Update User";

                tbPersonEmployee.Enabled = true;
                btnSave.Enabled = true;


            }


            dtpHireDate.Value=DateTime.Now;
            cbDepartment.SelectedIndex=0;
            cbLevel.SelectedIndex=0;
            cbStatus.SelectedIndex=0;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            Employee.HireDate = dtpHireDate.Value;
            Employee.ExpiredDate=null;
            Employee.DepartmentID = cbDepartment.SelectedIndex + 1;
            Employee.LevelID = cbLevel.SelectedIndex + 1;
            Employee.StatusID = cbStatus.SelectedIndex + 1;
            Employee.PersonID=ctrlPesonCardWithFilter1.PersonID;
            Employee.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            if(Employee.Save())
            {
                MessageBox.Show("Saved Succsffuly");
                lblID.Text=Employee.EmployeeID.ToString();
                return;
            }
            else
            {
                MessageBox.Show("ERROR");
            }



        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tbPersonEmployee.SelectedTab = tbPersonEmployee.TabPages["tpEmployeeInfo"];

                btnSave.Enabled = true;
                tpEmployeeInfo.Enabled = true;
                return;
            }

           // we mean !=-1 the filter was found the Employer because we chose -1 to refer null
            if (ctrlPesonCardWithFilter1.PersonID != -1)
            {
                // we should verfiy if the Person not two Employee or more because this is the rule
                if (clsEmployees.IsEmployeeExistByPersonID(ctrlPesonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPesonCardWithFilter1.Focus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpEmployeeInfo.Enabled = true;
                    tbPersonEmployee.SelectedTab = tbPersonEmployee.TabPages["tpEmployeeInfo"];//next page
                    //if the person not doublicate we can enable next page and  go to it
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPesonCardWithFilter1.Focus();

            }



        }

        private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            _ResetControls();
            if(_Mode ==enMode.Update) 
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
