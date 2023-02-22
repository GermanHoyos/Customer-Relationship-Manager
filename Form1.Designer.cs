
namespace WGUC969Project
{
    partial class Form1
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
			this.CustDGV = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.ApptDGV = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.CustDeleteButton = new System.Windows.Forms.Button();
			this.CustUpdateButton = new System.Windows.Forms.Button();
			this.CustAddButton = new System.Windows.Forms.Button();
			this.ApptDeleteButton = new System.Windows.Forms.Button();
			this.ApptUpdateButton = new System.Windows.Forms.Button();
			this.ApptAddButton = new System.Windows.Forms.Button();
			this.CalDGV = new System.Windows.Forms.DataGridView();
			this.CalenderMonthlyButton = new System.Windows.Forms.Button();
			this.CalenderWeeklyButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.ReportViewer = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CustReportButton = new System.Windows.Forms.Button();
			this.SchedReportButton = new System.Windows.Forms.Button();
			this.TypeReportButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.CustDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ApptDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CalDGV)).BeginInit();
			this.SuspendLayout();
			// 
			// CustDGV
			// 
			this.CustDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CustDGV.Location = new System.Drawing.Point(15, 28);
			this.CustDGV.Name = "CustDGV";
			this.CustDGV.Size = new System.Drawing.Size(234, 150);
			this.CustDGV.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "All Customers";
			// 
			// ApptDGV
			// 
			this.ApptDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ApptDGV.Location = new System.Drawing.Point(273, 28);
			this.ApptDGV.Name = "ApptDGV";
			this.ApptDGV.Size = new System.Drawing.Size(470, 150);
			this.ApptDGV.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(270, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "All Appointments";
			// 
			// CustDeleteButton
			// 
			this.CustDeleteButton.Location = new System.Drawing.Point(176, 184);
			this.CustDeleteButton.Name = "CustDeleteButton";
			this.CustDeleteButton.Size = new System.Drawing.Size(75, 23);
			this.CustDeleteButton.TabIndex = 9;
			this.CustDeleteButton.Text = "Delete";
			this.CustDeleteButton.UseVisualStyleBackColor = true;
			this.CustDeleteButton.Click += new System.EventHandler(this.CustDeleteButton_Click);
			// 
			// CustUpdateButton
			// 
			this.CustUpdateButton.Location = new System.Drawing.Point(95, 184);
			this.CustUpdateButton.Name = "CustUpdateButton";
			this.CustUpdateButton.Size = new System.Drawing.Size(75, 23);
			this.CustUpdateButton.TabIndex = 10;
			this.CustUpdateButton.Text = "Update";
			this.CustUpdateButton.UseVisualStyleBackColor = true;
			this.CustUpdateButton.Click += new System.EventHandler(this.CustUpdateButton_Click);
			// 
			// CustAddButton
			// 
			this.CustAddButton.Location = new System.Drawing.Point(14, 184);
			this.CustAddButton.Name = "CustAddButton";
			this.CustAddButton.Size = new System.Drawing.Size(75, 23);
			this.CustAddButton.TabIndex = 11;
			this.CustAddButton.Text = "Add";
			this.CustAddButton.UseVisualStyleBackColor = true;
			this.CustAddButton.Click += new System.EventHandler(this.CustAddButton_Click);
			// 
			// ApptDeleteButton
			// 
			this.ApptDeleteButton.Location = new System.Drawing.Point(668, 184);
			this.ApptDeleteButton.Name = "ApptDeleteButton";
			this.ApptDeleteButton.Size = new System.Drawing.Size(75, 23);
			this.ApptDeleteButton.TabIndex = 12;
			this.ApptDeleteButton.Text = "Delete";
			this.ApptDeleteButton.UseVisualStyleBackColor = true;
			this.ApptDeleteButton.Click += new System.EventHandler(this.button4_Click);
			// 
			// ApptUpdateButton
			// 
			this.ApptUpdateButton.Location = new System.Drawing.Point(587, 184);
			this.ApptUpdateButton.Name = "ApptUpdateButton";
			this.ApptUpdateButton.Size = new System.Drawing.Size(75, 23);
			this.ApptUpdateButton.TabIndex = 13;
			this.ApptUpdateButton.Text = "Update";
			this.ApptUpdateButton.UseVisualStyleBackColor = true;
			this.ApptUpdateButton.Click += new System.EventHandler(this.ApptUpdateButton_Click);
			// 
			// ApptAddButton
			// 
			this.ApptAddButton.Location = new System.Drawing.Point(506, 184);
			this.ApptAddButton.Name = "ApptAddButton";
			this.ApptAddButton.Size = new System.Drawing.Size(75, 23);
			this.ApptAddButton.TabIndex = 14;
			this.ApptAddButton.Text = "Add";
			this.ApptAddButton.UseVisualStyleBackColor = true;
			this.ApptAddButton.Click += new System.EventHandler(this.ApptAddButton_Click);
			// 
			// CalDGV
			// 
			this.CalDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CalDGV.Location = new System.Drawing.Point(273, 314);
			this.CalDGV.Name = "CalDGV";
			this.CalDGV.Size = new System.Drawing.Size(470, 162);
			this.CalDGV.TabIndex = 15;
			// 
			// CalenderMonthlyButton
			// 
			this.CalenderMonthlyButton.Location = new System.Drawing.Point(669, 482);
			this.CalenderMonthlyButton.Name = "CalenderMonthlyButton";
			this.CalenderMonthlyButton.Size = new System.Drawing.Size(75, 23);
			this.CalenderMonthlyButton.TabIndex = 17;
			this.CalenderMonthlyButton.Text = "Monthly";
			this.CalenderMonthlyButton.UseVisualStyleBackColor = true;
			this.CalenderMonthlyButton.Click += new System.EventHandler(this.CalenderMonthlyButton_Click);
			// 
			// CalenderWeeklyButton
			// 
			this.CalenderWeeklyButton.Location = new System.Drawing.Point(588, 482);
			this.CalenderWeeklyButton.Name = "CalenderWeeklyButton";
			this.CalenderWeeklyButton.Size = new System.Drawing.Size(75, 23);
			this.CalenderWeeklyButton.TabIndex = 18;
			this.CalenderWeeklyButton.Text = "Weekly";
			this.CalenderWeeklyButton.UseVisualStyleBackColor = true;
			this.CalenderWeeklyButton.Click += new System.EventHandler(this.CalenderWeeklyButton_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 296);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(177, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Appointments are highlighted in bold";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(18, 312);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 19;
			this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(270, 296);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(284, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "MONTHLY appointments based on selected calender date";
			// 
			// ReportViewer
			// 
			this.ReportViewer.Location = new System.Drawing.Point(772, 28);
			this.ReportViewer.Multiline = true;
			this.ReportViewer.Name = "ReportViewer";
			this.ReportViewer.ReadOnly = true;
			this.ReportViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReportViewer.Size = new System.Drawing.Size(210, 448);
			this.ReportViewer.TabIndex = 21;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(769, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(214, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "Report: Num of appointment types by month";
			// 
			// CustReportButton
			// 
			this.CustReportButton.Location = new System.Drawing.Point(919, 482);
			this.CustReportButton.Name = "CustReportButton";
			this.CustReportButton.Size = new System.Drawing.Size(63, 23);
			this.CustReportButton.TabIndex = 23;
			this.CustReportButton.Text = "Cust";
			this.CustReportButton.UseVisualStyleBackColor = true;
			this.CustReportButton.Click += new System.EventHandler(this.CustReportButton_Click);
			// 
			// SchedReportButton
			// 
			this.SchedReportButton.Location = new System.Drawing.Point(847, 482);
			this.SchedReportButton.Name = "SchedReportButton";
			this.SchedReportButton.Size = new System.Drawing.Size(64, 23);
			this.SchedReportButton.TabIndex = 24;
			this.SchedReportButton.Text = "Sched";
			this.SchedReportButton.UseVisualStyleBackColor = true;
			this.SchedReportButton.Click += new System.EventHandler(this.SchedReportButton_Click);
			// 
			// TypeReportButton
			// 
			this.TypeReportButton.Location = new System.Drawing.Point(772, 482);
			this.TypeReportButton.Name = "TypeReportButton";
			this.TypeReportButton.Size = new System.Drawing.Size(66, 23);
			this.TypeReportButton.TabIndex = 25;
			this.TypeReportButton.Text = "Type";
			this.TypeReportButton.UseVisualStyleBackColor = true;
			this.TypeReportButton.Click += new System.EventHandler(this.TypeReportButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 519);
			this.Controls.Add(this.TypeReportButton);
			this.Controls.Add(this.SchedReportButton);
			this.Controls.Add(this.CustReportButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ReportViewer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.CalenderWeeklyButton);
			this.Controls.Add(this.CalenderMonthlyButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.CalDGV);
			this.Controls.Add(this.ApptAddButton);
			this.Controls.Add(this.ApptUpdateButton);
			this.Controls.Add(this.ApptDeleteButton);
			this.Controls.Add(this.CustAddButton);
			this.Controls.Add(this.CustUpdateButton);
			this.Controls.Add(this.CustDeleteButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ApptDGV);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.CustDGV);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.CustDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ApptDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CalDGV)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.DataGridView CustDGV;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView ApptDGV;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button CustDeleteButton;
		private System.Windows.Forms.Button CustUpdateButton;
		private System.Windows.Forms.Button CustAddButton;
		private System.Windows.Forms.Button ApptDeleteButton;
		private System.Windows.Forms.Button ApptUpdateButton;
		private System.Windows.Forms.Button ApptAddButton;
		private System.Windows.Forms.DataGridView CalDGV;
		private System.Windows.Forms.Button CalenderMonthlyButton;
		private System.Windows.Forms.Button CalenderWeeklyButton;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.MonthCalendar monthCalendar1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox ReportViewer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button CustReportButton;
		private System.Windows.Forms.Button SchedReportButton;
		private System.Windows.Forms.Button TypeReportButton;
	}
}

