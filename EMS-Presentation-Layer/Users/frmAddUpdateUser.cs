using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Business_Layer;
using EMS_Presentation_Layer.Classes;
using EMS_Presentation_Layer.People.Controls;

namespace EMS_Presentation_Layer.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private int _UserID;
        private clsUsers _User;
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        enum enPermissions { enManagePeople = 1, enManageEmployees = 2, enManageInterviews = 4, enMangeSalaryLog = 8, enManageAttendance = 16, enSalaryAdjustment = 32 }
        private int _Permissions;
        private int _FullyPersmission;
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New User";
                _User = new clsUsers();
                tpLoginInfo.Enabled = false;

                ctrlPesonCardWithFilter1.Focus();
            }
            else
            {
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
            chkManagePeople.Checked = false;
            chkManageEmployees.Checked = false;
            chkManageInterviews.Checked = false;
            chkManageAttendance.Checked = false;
            chkManageSalaryAdjustment.Checked = false;
            chkManageSalarylog.Checked = false;
            chkIsAdmin.Checked = false;



        }

        private void _LoadData()
        {

            _User = clsUsers.FindUserByID(_UserID);
            ctrlPesonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            chkIsAdmin.Checked = _User.IsAdmin;
            ctrlPesonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            chkManagePeople.Checked = ((int)enPermissions.enManagePeople & _User.Permissions) == (int)enPermissions.enManagePeople;
            chkManageEmployees.Checked = ((int)enPermissions.enManageEmployees & _User.Permissions) == (int)enPermissions.enManageEmployees;
            chkManageInterviews.Checked = ((int)enPermissions.enManageInterviews & _User.Permissions) == (int)enPermissions.enManageInterviews;
            chkManageSalarylog.Checked = ((int)enPermissions.enMangeSalaryLog & _User.Permissions) == (int)enPermissions.enMangeSalaryLog;
            chkManageSalaryAdjustment.Checked = ((int)enPermissions.enSalaryAdjustment & _User.Permissions) == (int)enPermissions.enSalaryAdjustment;
            chkManageAttendance.Checked = ((int)enPermissions.enManageAttendance & _User.Permissions) == (int)enPermissions.enManageAttendance;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPesonCardWithFilter1.PersonID != -1)
            {

                if (clsUsers.IsUserExistByPersonID(ctrlPesonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPesonCardWithFilter1.Focus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPesonCardWithFilter1.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPesonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;
            _User.IsAdmin = chkIsAdmin.Checked;
            if(chkIsAdmin.Checked)
            _User.Permissions = _FullyPersmission;
            else
            _User.Permissions = _Permissions;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkManagePeople_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManagePeople.Checked)
                _Permissions += (int)enPermissions.enManagePeople;
            else
                _Permissions -= (int)enPermissions.enManagePeople;

        }

        private void chkManageEmployees_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageEmployees.Checked)
                _Permissions += (int)enPermissions.enManageEmployees;
            else
                _Permissions -= (int)enPermissions.enManageEmployees;
        }

        private void chkManageInterviews_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageInterviews.Checked)
                _Permissions += (int)enPermissions.enManageInterviews;
            else
                _Permissions -= (int)enPermissions.enManageInterviews;
        }

        private void chkManageSalarylog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageSalarylog.Checked)
                _Permissions += (int)enPermissions.enMangeSalaryLog;
            else
                _Permissions -= (int)enPermissions.enMangeSalaryLog;
        }

        private void chkManageAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageAttendance.Checked)
                _Permissions += (int)enPermissions.enManageAttendance;
            else
                _Permissions -= (int)enPermissions.enManageAttendance;
        }

        private void chkManageSalaryAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManageSalaryAdjustment.Checked)
                _Permissions += (int)enPermissions.enSalaryAdjustment;
            else
                _Permissions -= (int)enPermissions.enSalaryAdjustment;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "You must add your User Name!");
            }
            else
            {
                e.Cancel = false;
            }


            if (_Mode == enMode.AddNew)
            {
                if (clsUsers.IsUserExistByUserName(txtUserName.Text.Trim()))
                {

                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "this User Name be Exist");

                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);

                }
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {

                    if(clsUsers.IsUserExistByUserName(txtUserName.Text.Trim()))
                {

                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "this User Name be Exist");
                        return;
                    }
                else
                    {
                        errorProvider1.SetError(txtUserName, null);

                    }


                }


            }
        }

        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAdmin.Checked)
{
                groupBox1.Enabled = false;
                _FullyPersmission = 63;
}            else groupBox1.Enabled=true;
           
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}