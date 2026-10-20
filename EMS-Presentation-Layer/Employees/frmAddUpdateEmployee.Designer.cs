namespace EMS_Presentation_Layer.Employees
{
    partial class frmAddUpdateEmployee
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
            this.tbPersonEmployee = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlPesonCardWithFilter1 = new EMS_Presentation_Layer.People.Controls.ctrlPesonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpEmployeeInfo = new System.Windows.Forms.TabPage();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.dtpExpirDate = new System.Windows.Forms.DateTimePicker();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbPersonEmployee.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpEmployeeInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPersonEmployee
            // 
            this.tbPersonEmployee.Controls.Add(this.tabPage1);
            this.tbPersonEmployee.Controls.Add(this.tpEmployeeInfo);
            this.tbPersonEmployee.Location = new System.Drawing.Point(4, 5);
            this.tbPersonEmployee.Name = "tbPersonEmployee";
            this.tbPersonEmployee.SelectedIndex = 0;
            this.tbPersonEmployee.Size = new System.Drawing.Size(802, 607);
            this.tbPersonEmployee.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.tabPage1.Controls.Add(this.ctrlPesonCardWithFilter1);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Selection";
            // 
            // ctrlPesonCardWithFilter1
            // 
            this.ctrlPesonCardWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.ctrlPesonCardWithFilter1.FilterEnabled = true;
            this.ctrlPesonCardWithFilter1.Location = new System.Drawing.Point(3, 0);
            this.ctrlPesonCardWithFilter1.Name = "ctrlPesonCardWithFilter1";
            this.ctrlPesonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPesonCardWithFilter1.Size = new System.Drawing.Size(808, 526);
            this.ctrlPesonCardWithFilter1.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon___2024_08_28T131945_897;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.Location = new System.Drawing.Point(719, 532);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpEmployeeInfo
            // 
            this.tpEmployeeInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.tpEmployeeInfo.Controls.Add(this.cbStatus);
            this.tpEmployeeInfo.Controls.Add(this.cbLevel);
            this.tpEmployeeInfo.Controls.Add(this.cbDepartment);
            this.tpEmployeeInfo.Controls.Add(this.dtpExpirDate);
            this.tpEmployeeInfo.Controls.Add(this.dtpHireDate);
            this.tpEmployeeInfo.Controls.Add(this.label6);
            this.tpEmployeeInfo.Controls.Add(this.label5);
            this.tpEmployeeInfo.Controls.Add(this.lblID);
            this.tpEmployeeInfo.Controls.Add(this.label4);
            this.tpEmployeeInfo.Controls.Add(this.label3);
            this.tpEmployeeInfo.Controls.Add(this.label2);
            this.tpEmployeeInfo.Controls.Add(this.label1);
            this.tpEmployeeInfo.ForeColor = System.Drawing.Color.White;
            this.tpEmployeeInfo.Location = new System.Drawing.Point(4, 25);
            this.tpEmployeeInfo.Name = "tpEmployeeInfo";
            this.tpEmployeeInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployeeInfo.Size = new System.Drawing.Size(794, 578);
            this.tpEmployeeInfo.TabIndex = 1;
            this.tpEmployeeInfo.Text = "Employee Info";
            this.tpEmployeeInfo.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(141, 291);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(183, 24);
            this.cbStatus.TabIndex = 11;
            // 
            // cbLevel
            // 
            this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Location = new System.Drawing.Point(515, 191);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(183, 24);
            this.cbLevel.TabIndex = 10;
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(527, 113);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(183, 24);
            this.cbDepartment.TabIndex = 9;
            // 
            // dtpExpirDate
            // 
            this.dtpExpirDate.Location = new System.Drawing.Point(159, 194);
            this.dtpExpirDate.Name = "dtpExpirDate";
            this.dtpExpirDate.Size = new System.Drawing.Size(214, 24);
            this.dtpExpirDate.TabIndex = 8;
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(141, 120);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(214, 24);
            this.dtpHireDate.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(381, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Department:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Job Level:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(171, 52);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(48, 20);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hire Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expired Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID:";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon___2024_08_28T132033_054;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(720, 618);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 50);
            this.btnSave.TabIndex = 12;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon_36;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(603, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 50);
            this.btnClose.TabIndex = 13;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateEmployee
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(807, 668);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbPersonEmployee);
            this.Controls.Add(this.btnSave);
            this.Name = "frmAddUpdateEmployee";
            this.Text = "frmAddUpdateEmployee";
            this.Load += new System.EventHandler(this.frmAddUpdateEmployee_Load);
            this.tbPersonEmployee.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tpEmployeeInfo.ResumeLayout(false);
            this.tpEmployeeInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbPersonEmployee;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpEmployeeInfo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpExpirDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Button btnNext;
        private People.Controls.ctrlPesonCardWithFilter ctrlPesonCardWithFilter1;
    }
}