namespace EMS_Presentation_Layer.Employees
{
    partial class frmEmployeeIinfo
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
            this.ctrlEmployeeInfo1 = new EMS_Presentation_Layer.Employees.Controls.ctrlEmployeeInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlEmployeeInfo1
            // 
            this.ctrlEmployeeInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.ctrlEmployeeInfo1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlEmployeeInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlEmployeeInfo1.Location = new System.Drawing.Point(2, 3);
            this.ctrlEmployeeInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlEmployeeInfo1.Name = "ctrlEmployeeInfo1";
            this.ctrlEmployeeInfo1.Size = new System.Drawing.Size(795, 736);
            this.ctrlEmployeeInfo1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon_36;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(2, 734);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 50);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEmployeeIinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(797, 781);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlEmployeeInfo1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmEmployeeIinfo";
            this.Text = "frmEmployeeIinfo";
            this.Load += new System.EventHandler(this.frmEmployeeIinfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlEmployeeInfo ctrlEmployeeInfo1;
        private System.Windows.Forms.Button button1;
    }
}