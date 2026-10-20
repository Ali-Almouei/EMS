namespace EMS_Presentation_Layer.InterviewAppointment
{
    partial class frmAppointmentListThismonth
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
            this.components = new System.ComponentModel.Container();
            this.dgvAppointmentsThisMonth = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddApointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.goToInterviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsThisMonth)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAppointmentsThisMonth
            // 
            this.dgvAppointmentsThisMonth.AllowUserToAddRows = false;
            this.dgvAppointmentsThisMonth.AllowUserToDeleteRows = false;
            this.dgvAppointmentsThisMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentsThisMonth.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointmentsThisMonth.Location = new System.Drawing.Point(0, 184);
            this.dgvAppointmentsThisMonth.Name = "dgvAppointmentsThisMonth";
            this.dgvAppointmentsThisMonth.ReadOnly = true;
            this.dgvAppointmentsThisMonth.RowHeadersWidth = 51;
            this.dgvAppointmentsThisMonth.Size = new System.Drawing.Size(1050, 353);
            this.dgvAppointmentsThisMonth.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToInterviewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(251, 30);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // dtpFilter
            // 
            this.dtpFilter.Location = new System.Drawing.Point(150, 141);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(200, 24);
            this.dtpFilter.TabIndex = 1;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pixel Digivolve", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Month/Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OMEGLE", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(371, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appointemnt List ";
            // 
            // btnAddApointment
            // 
            this.btnAddApointment.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.Appointment;
            this.btnAddApointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddApointment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddApointment.Location = new System.Drawing.Point(975, 123);
            this.btnAddApointment.Name = "btnAddApointment";
            this.btnAddApointment.Size = new System.Drawing.Size(75, 55);
            this.btnAddApointment.TabIndex = 4;
            this.btnAddApointment.UseVisualStyleBackColor = true;
            this.btnAddApointment.Click += new System.EventHandler(this.btnAddApointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon_36;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 50);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // goToInterviewToolStripMenuItem
            // 
            this.goToInterviewToolStripMenuItem.Image = global::EMS_Presentation_Layer.Properties.Resources.Interview21;
            this.goToInterviewToolStripMenuItem.Name = "goToInterviewToolStripMenuItem";
            this.goToInterviewToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.goToInterviewToolStripMenuItem.Text = "Go To Interview";
            this.goToInterviewToolStripMenuItem.Click += new System.EventHandler(this.goToInterviewToolStripMenuItem_Click);
            // 
            // frmAppointmentListThismonth
            // 
            this.AcceptButton = this.btnAddApointment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1050, 599);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddApointment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFilter);
            this.Controls.Add(this.dgvAppointmentsThisMonth);
            this.Name = "frmAppointmentListThismonth";
            this.Text = "frmAppointmentListThismonth";
            this.Load += new System.EventHandler(this.frmAppointmentListThismonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsThisMonth)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointmentsThisMonth;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddApointment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToInterviewToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}