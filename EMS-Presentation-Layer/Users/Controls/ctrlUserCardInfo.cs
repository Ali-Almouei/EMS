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

namespace EMS_Presentation_Layer.Users.Controls
{
    public partial class ctrlUserCardInfo : UserControl
    {
        private int _UserID;
        clsUsers User;

        enum enPermissions { enManagePeople = 1, enManageEmployees = 2, enManageInterviews = 4, enMangeSalaryLog = 8, enManageAttendance = 16, enSalaryAdjustment = 32 }

        public ctrlUserCardInfo()
        {
            InitializeComponent();
        }
        public int UserID
        {
            get { return _UserID; }
        }
        public void HideEditLabel()
        {
            ctrlPersonInfoCard1.HideEditLabel();
        }

        private void _ResetControls()
        {
            ctrlPersonInfoCard1._ResetValue();
            lblUserID.Text = "??";
            lblUserName.Text = "??";
            lblIsActive.Text = "??";
            lblIsAdmin.Text = "??";
            chkManagePeople.Checked = false;
            chkManageEmployees.Checked = false;
            chkManageInterviews.Checked = false;
            chkManageAttendance.Checked = false;
            chkManageSalaryAdjustment.Checked = false;
            chkManageSalarylog.Checked = false;     
            
        }
        private void _LoadData()
        {
            ctrlPersonInfoCard1.LoadPesonInfo(User.PersonID);
            lblUserID.Text=User.UserID.ToString();
            lblUserName.Text=User.UserName.ToString();
            lblIsActive.Text = User.IsActive ? "YES" : "NO";
            lblIsAdmin.Text = User.IsAdmin ? "YES" : "NO";
            groupBox1.Enabled = !User.IsAdmin;
            chkManagePeople.Checked = ((int)enPermissions.enManagePeople & User.Permissions) == (int)enPermissions.enManagePeople;
            chkManageEmployees.Checked = ((int)enPermissions.enManageEmployees & User.Permissions) == (int)enPermissions.enManageEmployees;
            chkManageInterviews.Checked = ((int)enPermissions.enManageInterviews & User.Permissions) == (int)enPermissions.enManageInterviews;
            chkManageSalarylog.Checked = ((int)enPermissions.enMangeSalaryLog & User.Permissions) == (int)enPermissions.enMangeSalaryLog;
            chkManageSalaryAdjustment.Checked = ((int)enPermissions.enSalaryAdjustment & User.Permissions) == (int)enPermissions.enSalaryAdjustment;
            chkManageAttendance.Checked = ((int)enPermissions.enManageAttendance & User.Permissions) == (int)enPermissions.enManageAttendance;

        }
        public void LoadUserInfo(int UserID)
        {
            User=clsUsers.FindUserByID(UserID);
            _UserID = UserID;
            if (User == null)
            {
                _ResetControls();
                return;
            }
            _LoadData();
        }
        
    }
}
