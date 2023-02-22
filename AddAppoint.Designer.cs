
namespace WGUC969Project
{
	partial class AddAppoint
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
			this.AddAppointmentCustIDTextInput = new System.Windows.Forms.TextBox();
			this.AddAppointmentCustIDLabel = new System.Windows.Forms.Label();
			this.AddAppointDescriptionTextInput = new System.Windows.Forms.TextBox();
			this.AddAppointDescriptionLabel = new System.Windows.Forms.Label();
			this.AddAppointSubmitButton = new System.Windows.Forms.Button();
			this.AddAppointCancelButton = new System.Windows.Forms.Button();
			this.dateTimePicker1FROM = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2FROM = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2TO = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1TO = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.AddAppointmentTypeTextBox = new System.Windows.Forms.TextBox();
			this.AddAppTypeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// AddAppointmentCustIDTextInput
			// 
			this.AddAppointmentCustIDTextInput.BackColor = System.Drawing.Color.Chocolate;
			this.AddAppointmentCustIDTextInput.Location = new System.Drawing.Point(12, 22);
			this.AddAppointmentCustIDTextInput.Name = "AddAppointmentCustIDTextInput";
			this.AddAppointmentCustIDTextInput.Size = new System.Drawing.Size(200, 20);
			this.AddAppointmentCustIDTextInput.TabIndex = 0;
			this.AddAppointmentCustIDTextInput.TextChanged += new System.EventHandler(this.AddAppointmentCustIDTextInput_TextChanged);
			// 
			// AddAppointmentCustIDLabel
			// 
			this.AddAppointmentCustIDLabel.AutoSize = true;
			this.AddAppointmentCustIDLabel.Location = new System.Drawing.Point(9, 6);
			this.AddAppointmentCustIDLabel.Name = "AddAppointmentCustIDLabel";
			this.AddAppointmentCustIDLabel.Size = new System.Drawing.Size(65, 13);
			this.AddAppointmentCustIDLabel.TabIndex = 1;
			this.AddAppointmentCustIDLabel.Text = "Customer ID";
			// 
			// AddAppointDescriptionTextInput
			// 
			this.AddAppointDescriptionTextInput.BackColor = System.Drawing.Color.Chocolate;
			this.AddAppointDescriptionTextInput.Location = new System.Drawing.Point(218, 22);
			this.AddAppointDescriptionTextInput.Name = "AddAppointDescriptionTextInput";
			this.AddAppointDescriptionTextInput.Size = new System.Drawing.Size(200, 20);
			this.AddAppointDescriptionTextInput.TabIndex = 6;
			this.AddAppointDescriptionTextInput.TextChanged += new System.EventHandler(this.AddAppointDescriptionTextInput_TextChanged);
			// 
			// AddAppointDescriptionLabel
			// 
			this.AddAppointDescriptionLabel.AutoSize = true;
			this.AddAppointDescriptionLabel.Location = new System.Drawing.Point(215, 6);
			this.AddAppointDescriptionLabel.Name = "AddAppointDescriptionLabel";
			this.AddAppointDescriptionLabel.Size = new System.Drawing.Size(60, 13);
			this.AddAppointDescriptionLabel.TabIndex = 7;
			this.AddAppointDescriptionLabel.Text = "Description";
			// 
			// AddAppointSubmitButton
			// 
			this.AddAppointSubmitButton.Location = new System.Drawing.Point(12, 304);
			this.AddAppointSubmitButton.Name = "AddAppointSubmitButton";
			this.AddAppointSubmitButton.Size = new System.Drawing.Size(75, 23);
			this.AddAppointSubmitButton.TabIndex = 8;
			this.AddAppointSubmitButton.Text = "Submit";
			this.AddAppointSubmitButton.UseVisualStyleBackColor = true;
			this.AddAppointSubmitButton.Click += new System.EventHandler(this.AddAppointSubmitButton_Click);
			// 
			// AddAppointCancelButton
			// 
			this.AddAppointCancelButton.Location = new System.Drawing.Point(93, 304);
			this.AddAppointCancelButton.Name = "AddAppointCancelButton";
			this.AddAppointCancelButton.Size = new System.Drawing.Size(75, 23);
			this.AddAppointCancelButton.TabIndex = 9;
			this.AddAppointCancelButton.Text = "Cancel";
			this.AddAppointCancelButton.UseVisualStyleBackColor = true;
			this.AddAppointCancelButton.Click += new System.EventHandler(this.AddAppointCancelButton_Click);
			// 
			// dateTimePicker1FROM
			// 
			this.dateTimePicker1FROM.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1FROM.Location = new System.Drawing.Point(12, 70);
			this.dateTimePicker1FROM.Name = "dateTimePicker1FROM";
			this.dateTimePicker1FROM.ShowUpDown = true;
			this.dateTimePicker1FROM.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1FROM.TabIndex = 10;
			this.dateTimePicker1FROM.ValueChanged += new System.EventHandler(this.dateTimePicker1FROM_ValueChanged);
			// 
			// dateTimePicker2FROM
			// 
			this.dateTimePicker2FROM.Location = new System.Drawing.Point(12, 122);
			this.dateTimePicker2FROM.Name = "dateTimePicker2FROM";
			this.dateTimePicker2FROM.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2FROM.TabIndex = 11;
			this.dateTimePicker2FROM.ValueChanged += new System.EventHandler(this.dateTimePicker2FROM_ValueChanged);
			// 
			// dateTimePicker2TO
			// 
			this.dateTimePicker2TO.Location = new System.Drawing.Point(218, 122);
			this.dateTimePicker2TO.Name = "dateTimePicker2TO";
			this.dateTimePicker2TO.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2TO.TabIndex = 12;
			this.dateTimePicker2TO.ValueChanged += new System.EventHandler(this.dateTimePicker2TO_ValueChanged);
			// 
			// dateTimePicker1TO
			// 
			this.dateTimePicker1TO.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1TO.Location = new System.Drawing.Point(218, 70);
			this.dateTimePicker1TO.Name = "dateTimePicker1TO";
			this.dateTimePicker1TO.ShowUpDown = true;
			this.dateTimePicker1TO.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1TO.TabIndex = 13;
			this.dateTimePicker1TO.ValueChanged += new System.EventHandler(this.dateTimePicker1TO_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Chocolate;
			this.label1.Location = new System.Drawing.Point(12, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Must select a date";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Chocolate;
			this.label2.Location = new System.Drawing.Point(218, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Must select a time";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Chocolate;
			this.label3.Location = new System.Drawing.Point(12, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Must select a time";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Chocolate;
			this.label4.Location = new System.Drawing.Point(218, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Must select a date";
			// 
			// AddAppointmentTypeTextBox
			// 
			this.AddAppointmentTypeTextBox.BackColor = System.Drawing.Color.Chocolate;
			this.AddAppointmentTypeTextBox.Location = new System.Drawing.Point(132, 187);
			this.AddAppointmentTypeTextBox.Name = "AddAppointmentTypeTextBox";
			this.AddAppointmentTypeTextBox.Size = new System.Drawing.Size(180, 20);
			this.AddAppointmentTypeTextBox.TabIndex = 18;
			this.AddAppointmentTypeTextBox.TextChanged += new System.EventHandler(this.AddAppointmentTypeTextBox_TextChanged);
			// 
			// AddAppTypeLabel
			// 
			this.AddAppTypeLabel.AutoSize = true;
			this.AddAppTypeLabel.Location = new System.Drawing.Point(133, 171);
			this.AddAppTypeLabel.Name = "AddAppTypeLabel";
			this.AddAppTypeLabel.Size = new System.Drawing.Size(93, 13);
			this.AddAppTypeLabel.TabIndex = 19;
			this.AddAppTypeLabel.Text = "Appointment Type";
			// 
			// AddAppoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 336);
			this.Controls.Add(this.AddAppTypeLabel);
			this.Controls.Add(this.AddAppointmentTypeTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1TO);
			this.Controls.Add(this.dateTimePicker2TO);
			this.Controls.Add(this.dateTimePicker2FROM);
			this.Controls.Add(this.dateTimePicker1FROM);
			this.Controls.Add(this.AddAppointCancelButton);
			this.Controls.Add(this.AddAppointSubmitButton);
			this.Controls.Add(this.AddAppointDescriptionLabel);
			this.Controls.Add(this.AddAppointDescriptionTextInput);
			this.Controls.Add(this.AddAppointmentCustIDLabel);
			this.Controls.Add(this.AddAppointmentCustIDTextInput);
			this.Name = "AddAppoint";
			this.Text = "AddAppoint";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox AddAppointmentCustIDTextInput;
		private System.Windows.Forms.Label AddAppointmentCustIDLabel;
		private System.Windows.Forms.TextBox AddAppointDescriptionTextInput;
		private System.Windows.Forms.Label AddAppointDescriptionLabel;
		private System.Windows.Forms.Button AddAppointSubmitButton;
		private System.Windows.Forms.Button AddAppointCancelButton;
		public System.Windows.Forms.DateTimePicker dateTimePicker1FROM;
		private System.Windows.Forms.DateTimePicker dateTimePicker2FROM;
		private System.Windows.Forms.DateTimePicker dateTimePicker2TO;
		public System.Windows.Forms.DateTimePicker dateTimePicker1TO;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox AddAppointmentTypeTextBox;
		private System.Windows.Forms.Label AddAppTypeLabel;
	}
}