﻿namespace QLHT
{
    partial class frmReportKN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportKN));
            this.reportViewer6 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewer6
            // 
            this.reportViewer6.LocalReport.ReportEmbeddedResource = "QLHT.Report1.rdlc";
            this.reportViewer6.Location = new System.Drawing.Point(12, 85);
            this.reportViewer6.Name = "reportViewer6";
            this.reportViewer6.ServerReport.BearerToken = null;
            this.reportViewer6.Size = new System.Drawing.Size(761, 353);
            this.reportViewer6.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.Purple;
            this.btnLoad.Location = new System.Drawing.Point(428, 52);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 29);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(208, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "REPORT INFORMATION";
            // 
            // frmReportKN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer6);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportKN";
            this.Text = "Khả năng report";
            this.Load += new System.EventHandler(this.frmReportKN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
    }
}