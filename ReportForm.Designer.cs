using System;
using System.Windows.Forms;
using System.Drawing;

namespace Segment_Color_Mappin

{
    partial class ReportForm
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
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.txtMedicalHistory = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // Create labels
            Label lblName = new Label();
            Label lblAge = new Label();
            Label lblGender = new Label();
            Label lblAddress = new Label();
            Label lblContactNumber = new Label();
            Label lblMedicalHistory = new Label();

            // Set properties for labels
            lblName.Text = "Name:";
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(30, 33);

            lblAge.Text = "Age:";
            lblAge.AutoSize = true;
            lblAge.Location = new Point(30, 63);

            lblGender.Text = "Gender:";
            lblGender.AutoSize = true;
            lblGender.Location = new Point(30, 93);

            lblAddress.Text = "Address:";
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(30, 123);

            lblContactNumber.Text = "Contact Number:";
            lblContactNumber.AutoSize = true;
            lblContactNumber.Location = new Point(30, 153);

            lblMedicalHistory.Text = "Medical History:";
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Location = new Point(30, 183);

            // Add labels to the form
            this.Controls.Add(lblName);
            this.Controls.Add(lblAge);
            this.Controls.Add(lblGender);
            this.Controls.Add(lblAddress);
            this.Controls.Add(lblContactNumber);
            this.Controls.Add(lblMedicalHistory);
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Location = new System.Drawing.Point(150, 250);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(200, 30);
            this.btnSaveReport.TabIndex = 6;
            this.btnSaveReport.Text = "Save Report";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // txtMedicalHistory
            // 
            this.txtMedicalHistory.Location = new System.Drawing.Point(150, 180);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.Size = new System.Drawing.Size(200, 50);
            this.txtMedicalHistory.TabIndex = 5;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(150, 150);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 20);
            this.txtContactNumber.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(150, 120);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(150, 90);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(200, 20);
            this.txtGender.TabIndex = 2;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(150, 60);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(200, 20);
            this.txtAge.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 311);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.txtMedicalHistory);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtName);
            this.Name = "ReportForm";
            this.Text = "Patient Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtMedicalHistory;
        private System.Windows.Forms.Button btnSaveReport;
    }
}
