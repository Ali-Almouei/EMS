namespace EMS_Presentation_Layer
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departmetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryAdjustmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logAdjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paySalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryLogHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("OMEGLE", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.salaryAdjustmentsToolStripMenuItem,
            this.attendanceToolStripMenuItem,
            this.salaryLogToolStripMenuItem,
            this.interviewToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmetsToolStripMenuItem,
            this.jobLevelsToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Image = global::EMS_Presentation_Layer.Properties.Resources.Verfiy;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(315, 29);
            this.toolStripMenuItem1.Text = "DepartmentsAndLevels";
            this.toolStripMenuItem1.DropDownOpening += new System.EventHandler(this.toolStripMenuItem1_DropDownOpening);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // departmetsToolStripMenuItem
            // 
            this.departmetsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.departmetsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.departmetsToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Department;
            this.departmetsToolStripMenuItem.Name = "departmetsToolStripMenuItem";
            this.departmetsToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.departmetsToolStripMenuItem.Text = "Departmets";
            this.departmetsToolStripMenuItem.Click += new System.EventHandler(this.departmetsToolStripMenuItem_Click);
            // 
            // jobLevelsToolStripMenuItem
            // 
            this.jobLevelsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.jobLevelsToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.JobLevel;
            this.jobLevelsToolStripMenuItem.Name = "jobLevelsToolStripMenuItem";
            this.jobLevelsToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.jobLevelsToolStripMenuItem.Text = "Job Levels";
            this.jobLevelsToolStripMenuItem.Click += new System.EventHandler(this.jobLevelsToolStripMenuItem_Click);
            // 
            // salaryAdjustmentsToolStripMenuItem
            // 
            this.salaryAdjustmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustmentListToolStripMenuItem,
            this.logAdjustmentToolStripMenuItem});
            this.salaryAdjustmentsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.salaryAdjustmentsToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Ajustments;
            this.salaryAdjustmentsToolStripMenuItem.Name = "salaryAdjustmentsToolStripMenuItem";
            this.salaryAdjustmentsToolStripMenuItem.Size = new System.Drawing.Size(265, 29);
            this.salaryAdjustmentsToolStripMenuItem.Text = "SalaryAdjustments";
            this.salaryAdjustmentsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.salaryAdjustmentsToolStripMenuItem_DropDownOpening);
            // 
            // adjustmentListToolStripMenuItem
            // 
            this.adjustmentListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.adjustmentListToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.adjustmentListToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.adjustment1;
            this.adjustmentListToolStripMenuItem.Name = "adjustmentListToolStripMenuItem";
            this.adjustmentListToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.adjustmentListToolStripMenuItem.Text = "Adjustment List";
            this.adjustmentListToolStripMenuItem.Click += new System.EventHandler(this.adjustmentListToolStripMenuItem_Click);
            // 
            // logAdjustmentToolStripMenuItem
            // 
            this.logAdjustmentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.logAdjustmentToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.logAdjustmentToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.LogAdjustment;
            this.logAdjustmentToolStripMenuItem.Name = "logAdjustmentToolStripMenuItem";
            this.logAdjustmentToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.logAdjustmentToolStripMenuItem.Text = "Log Adjustment";
            this.logAdjustmentToolStripMenuItem.Click += new System.EventHandler(this.logAdjustmentToolStripMenuItem_Click);
            // 
            // attendanceToolStripMenuItem
            // 
            this.attendanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attendanceListToolStripMenuItem,
            this.logAttendanceToolStripMenuItem});
            this.attendanceToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.attendanceToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Calendar;
            this.attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            this.attendanceToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.attendanceToolStripMenuItem.Text = "Attendance";
            this.attendanceToolStripMenuItem.DropDownOpening += new System.EventHandler(this.attendanceToolStripMenuItem_DropDownOpening);
            this.attendanceToolStripMenuItem.DoubleClick += new System.EventHandler(this.attendanceToolStripMenuItem_DoubleClick);
            // 
            // attendanceListToolStripMenuItem
            // 
            this.attendanceListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.attendanceListToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.attendanceListToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.AttendanceList;
            this.attendanceListToolStripMenuItem.Name = "attendanceListToolStripMenuItem";
            this.attendanceListToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.attendanceListToolStripMenuItem.Text = "Attendance List";
            this.attendanceListToolStripMenuItem.Click += new System.EventHandler(this.attendanceListToolStripMenuItem_Click);
            // 
            // logAttendanceToolStripMenuItem
            // 
            this.logAttendanceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.logAttendanceToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.logAttendanceToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.LogAttendance;
            this.logAttendanceToolStripMenuItem.Name = "logAttendanceToolStripMenuItem";
            this.logAttendanceToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.logAttendanceToolStripMenuItem.Text = "Log Attendance";
            this.logAttendanceToolStripMenuItem.Click += new System.EventHandler(this.logAttendanceToolStripMenuItem_Click);
            // 
            // salaryLogToolStripMenuItem
            // 
            this.salaryLogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paySalaryToolStripMenuItem,
            this.salaryLogHistoryToolStripMenuItem});
            this.salaryLogToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.salaryLogToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Salary2;
            this.salaryLogToolStripMenuItem.Name = "salaryLogToolStripMenuItem";
            this.salaryLogToolStripMenuItem.Size = new System.Drawing.Size(163, 29);
            this.salaryLogToolStripMenuItem.Text = "SalaryLog";
            this.salaryLogToolStripMenuItem.DropDownOpening += new System.EventHandler(this.salaryLogToolStripMenuItem_DropDownOpening);
            // 
            // paySalaryToolStripMenuItem
            // 
            this.paySalaryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.paySalaryToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.paySalaryToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Salary1;
            this.paySalaryToolStripMenuItem.Name = "paySalaryToolStripMenuItem";
            this.paySalaryToolStripMenuItem.Size = new System.Drawing.Size(316, 30);
            this.paySalaryToolStripMenuItem.Text = "Pay Salary";
            this.paySalaryToolStripMenuItem.Click += new System.EventHandler(this.paySalaryToolStripMenuItem_Click);
            // 
            // salaryLogHistoryToolStripMenuItem
            // 
            this.salaryLogHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.salaryLogHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.salaryLogHistoryToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Salary11;
            this.salaryLogHistoryToolStripMenuItem.Name = "salaryLogHistoryToolStripMenuItem";
            this.salaryLogHistoryToolStripMenuItem.Size = new System.Drawing.Size(316, 30);
            this.salaryLogHistoryToolStripMenuItem.Text = "Salary Log History";
            this.salaryLogHistoryToolStripMenuItem.Click += new System.EventHandler(this.salaryLogHistoryToolStripMenuItem_Click);
            // 
            // interviewToolStripMenuItem
            // 
            this.interviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appointmentsToolStripMenuItem,
            this.resultsToolStripMenuItem});
            this.interviewToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.interviewToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Interview1;
            this.interviewToolStripMenuItem.Name = "interviewToolStripMenuItem";
            this.interviewToolStripMenuItem.Size = new System.Drawing.Size(163, 29);
            this.interviewToolStripMenuItem.Text = "Interviews";
            this.interviewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.interviewToolStripMenuItem_DropDownOpening);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.appointmentsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.appointmentsToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Appointment1;
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            this.appointmentsToolStripMenuItem.Click += new System.EventHandler(this.appointmentsToolStripMenuItem_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.resultsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.resultsToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Interview2;
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.resultsToolStripMenuItem.Text = "Interviews";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.employeesToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Employees;
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(171, 29);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.peopleToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Person;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(127, 29);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.usersToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Users;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingToolStripMenuItem
            // 
            this.accountSettingToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.accountSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.accountSettingToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.accountSettingToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Settings;
            this.accountSettingToolStripMenuItem.Name = "accountSettingToolStripMenuItem";
            this.accountSettingToolStripMenuItem.Size = new System.Drawing.Size(234, 29);
            this.accountSettingToolStripMenuItem.Text = "Account Setting";
            this.accountSettingToolStripMenuItem.Click += new System.EventHandler(this.accountSettingToolStripMenuItem_Click);
            // 
            // currentUserToolStripMenuItem
            // 
            this.currentUserToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.currentUserToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.currentUserToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.CurrentUser;
            this.currentUserToolStripMenuItem.Name = "currentUserToolStripMenuItem";
            this.currentUserToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.currentUserToolStripMenuItem.Text = "Current User";
            this.currentUserToolStripMenuItem.Click += new System.EventHandler(this.currentUserToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.changePasswordToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.changePasswordToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.ChangePassword;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.logOutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.logOutToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.LogOut;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(307, 30);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.EMS;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 465);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salaryAdjustmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departmetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logAdjustmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paySalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryLogHistoryToolStripMenuItem;
    }
}