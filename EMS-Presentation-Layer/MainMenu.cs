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
using EMS_Presentation_Layer.Adjustments;
using EMS_Presentation_Layer.Attendance;
using EMS_Presentation_Layer.Classes;
using EMS_Presentation_Layer.Departments;
using EMS_Presentation_Layer.Employees;
using EMS_Presentation_Layer.Interview;
using EMS_Presentation_Layer.InterviewAppointment;
using EMS_Presentation_Layer.JobLevels;
using EMS_Presentation_Layer.People;
using EMS_Presentation_Layer.SalaryLog;
using EMS_Presentation_Layer.Users;

namespace EMS_Presentation_Layer
{
    public partial class MainMenu : Form
    {
        private frmLogin _frmLogin;
        public MainMenu(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }
        enum enPermissions { enManagePeople = 1, enManageEmployees = 2, enManageInterviews = 4, enMangeSalaryLog = 8, enManageAttendance = 16, enSalaryAdjustment = 32 }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.White;
            if (!clsGlobal.CurrentUser.IsAdmin)
            {
                peopleToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManagePeople) == ((int)enPermissions.enManagePeople);
                usersToolStripMenuItem.Enabled = clsGlobal.CurrentUser.IsAdmin;
                employeesToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManageEmployees) == ((int)enPermissions.enManageEmployees);
                attendanceToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManagePeople) == ((int)enPermissions.enManageAttendance);
                salaryAdjustmentsToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enSalaryAdjustment) == ((int)enPermissions.enSalaryAdjustment);
                salaryLogToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enMangeSalaryLog) == ((int)enPermissions.enMangeSalaryLog);
                interviewToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManageInterviews) == ((int)enPermissions.enManageInterviews);
            }
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frmPeopleList frmPeopleList = new frmPeopleList();

            if (clsGlobal.CurrentUser.IsAdmin)
            {
                frmPeopleList.ShowDialog();
                return;
            }
            if((clsGlobal.CurrentUser.Permissions&(int)enPermissions.enManagePeople)==(int)enPermissions.enManagePeople)
            {
            frmPeopleList.ShowDialog();

            }
            else
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                return;
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CurrentUser.IsAdmin)
            {
                MessageBox.Show("You Are not an Admin", "Permission Deniad");
                return;
            }
                frmUserList frmUserList = new frmUserList();
                frmUserList.ShowDialog();
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            _frmLogin.Show();
            this.Close();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo f = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            f.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword g = new frmChangePassword(clsGlobal.CurrentUser.UserID); 
            g.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeesList frmEmployeesList = new frmEmployeesList();
            if (clsGlobal.CurrentUser.IsAdmin)
            {
                frmEmployeesList.ShowDialog();
                return;
            }
            if ((clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManageEmployees) == (int)enPermissions.enManageEmployees)
            {
                frmEmployeesList.ShowDialog();

            }
            else
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                return;
            }
        }

        private void departmetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentList frmDepartmentList = new frmDepartmentList();
            frmDepartmentList.ShowDialog(); 
        }

        private void jobLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJobLevelList s = new frmJobLevelList();
            s.ShowDialog();
        }

        private void logAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
          LogAttendanceForEmployee logAttendanceForEmployee = new LogAttendanceForEmployee();
            logAttendanceForEmployee.ShowDialog();
        }

        private void attendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceList frmAttendanceList = new frmAttendanceList();
                frmAttendanceList.ShowDialog();
        }

        private void attendanceToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void attendanceToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.IsAdmin)
            {
                return;
            }
            if (!((clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManageAttendance) == (int)enPermissions.enManageAttendance))
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                attendanceListToolStripMenuItem.Enabled = false;
                logAttendanceToolStripMenuItem.Enabled = false;

                return;
            }
        }

        private void adjustmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdjustmentList frmAdjustmentList = new frmAdjustmentList();
            frmAdjustmentList.ShowDialog();
        }

        private void logAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogAdjustment frmLogAdjustment = new frmLogAdjustment();
            frmLogAdjustment.ShowDialog();
        }

        private void salaryAdjustmentsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if(clsGlobal.CurrentUser.IsAdmin)
            {
                return;
            }
            if (!((clsGlobal.CurrentUser.Permissions & (int)enPermissions.enSalaryAdjustment) == (int)enPermissions.enSalaryAdjustment))
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                logAdjustmentToolStripMenuItem.Enabled = false;
                adjustmentListToolStripMenuItem.Enabled = false;

                return;
            }
        }

        private void paySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaySalaryForEmployee frmPaySalary = new frmPaySalaryForEmployee();
            frmPaySalary.ShowDialog();
        }

        private void salaryLogHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalaryLogList jds = new frmSalaryLogList();  
            jds.ShowDialog();
        }

        private void salaryLogToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.IsAdmin)
            {
                return;
            }
            if (!((clsGlobal.CurrentUser.Permissions & (int)enPermissions.enMangeSalaryLog) == (int)enPermissions.enMangeSalaryLog))
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                paySalaryToolStripMenuItem.Enabled = false;
                salaryLogHistoryToolStripMenuItem.Enabled = false;

                return;
            }
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppointmentListThismonth frmAppointment = new frmAppointmentListThismonth();
            frmAppointment.ShowDialog();
        }

        private void interviewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.IsAdmin)
            {
                return;
            }
            if (!((clsGlobal.CurrentUser.Permissions & (int)enPermissions.enManageInterviews) == (int)enPermissions.enManageInterviews))
            {
                MessageBox.Show("You Are not Have Permission To enter this filed", "Permission Deniad");
                appointmentsToolStripMenuItem.Enabled = false;
                resultsToolStripMenuItem.Enabled = false;

                return;
            }
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInterviewList h = new frmInterviewList();    
            h.ShowDialog();
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {

        }
    }
}
