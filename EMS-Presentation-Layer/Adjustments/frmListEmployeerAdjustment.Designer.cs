namespace EMS_Presentation_Layer.Adjustments
{
    partial class frmListEmployeerAdjustment
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
            this.dgvEmployeerAdjustments = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeerAdjustments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeerAdjustments
            // 
            this.dgvEmployeerAdjustments.AllowUserToAddRows = false;
            this.dgvEmployeerAdjustments.AllowUserToDeleteRows = false;
            this.dgvEmployeerAdjustments.AllowUserToOrderColumns = true;
            this.dgvEmployeerAdjustments.AllowUserToResizeColumns = false;
            this.dgvEmployeerAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeerAdjustments.Location = new System.Drawing.Point(-3, 84);
            this.dgvEmployeerAdjustments.Name = "dgvEmployeerAdjustments";
            this.dgvEmployeerAdjustments.RowHeadersWidth = 51;
            this.dgvEmployeerAdjustments.RowTemplate.Height = 26;
            this.dgvEmployeerAdjustments.Size = new System.Drawing.Size(1000, 300);
            this.dgvEmployeerAdjustments.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::EMS_Presentation_Layer.Properties.Resources.discotools_xyz_icon_36;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(-3, 390);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 50);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("OMEGLE", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(761, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adjustments List from Employeer ID :?";
            // 
            // frmListEmployeerAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(989, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvEmployeerAdjustments);
            this.Name = "frmListEmployeerAdjustment";
            this.Text = "frmListEmployeerAdjustment";
            this.Load += new System.EventHandler(this.frmListEmployeerAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeerAdjustments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeerAdjustments;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}