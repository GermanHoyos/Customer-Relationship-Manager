
namespace WGUC969Project
{
	partial class UpdateAppoint
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
			this.UpdateAppointmenIDtInputText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.UpdateAppointSubmitButton = new System.Windows.Forms.Button();
			this.UpdateAppointCancelButton = new System.Windows.Forms.Button();
			this.UpdateAppointDescTextInput = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePicker1TO = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1FROM = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2FROM = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2TO = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.UpdateAppTypeTextBox = new System.Windows.Forms.TextBox();
			this.UpdAppTypeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// UpdateAppointmenIDtInputText
			// 
			this.UpdateAppointmenIDtInputText.BackColor = System.Drawing.Color.LightGray;
			this.UpdateAppointmenIDtInputText.Enabled = false;
			this.UpdateAppointmenIDtInputText.Location = new System.Drawing.Point(12, 22);
			this.UpdateAppointmenIDtInputText.Name = "UpdateAppointmenIDtInputText";
			this.UpdateAppointmenIDtInputText.ReadOnly = true;
			this.UpdateAppointmenIDtInputText.Size = new System.Drawing.Size(200, 20);
			this.UpdateAppointmenIDtInputText.TabIndex = 0;
			this.UpdateAppointmenIDtInputText.TextChanged += new System.EventHandler(this.UpdateAppointmenIDtInputText_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Appointment ID";
			// 
			// UpdateAppointSubmitButton
			// 
			this.UpdateAppointSubmitButton.Location = new System.Drawing.Point(12, 301);
			this.UpdateAppointSubmitButton.Name = "UpdateAppointSubmitButton";
			this.UpdateAppointSubmitButton.Size = new System.Drawing.Size(75, 23);
			this.UpdateAppointSubmitButton.TabIndex = 6;
			this.UpdateAppointSubmitButton.Text = "Submit";
			this.UpdateAppointSubmitButton.UseVisualStyleBackColor = true;
			this.UpdateAppointSubmitButton.Click += new System.EventHandler(this.UpdateAppointSubmitButton_Click);
			// 
			// UpdateAppointCancelButton
			// 
			this.UpdateAppointCancelButton.Location = new System.Drawing.Point(93, 301);
			this.UpdateAppointCancelButton.Name = "UpdateAppointCancelButton";
			this.UpdateAppointCancelButton.Size = new System.Drawing.Size(75, 23);
			this.UpdateAppointCancelButton.TabIndex = 7;
			this.UpdateAppointCancelButton.Text = "Cancel";
			this.UpdateAppointCancelButton.UseVisualStyleBackColor = true;
			this.UpdateAppointCancelButton.Click += new System.EventHandler(this.UpdateAppointCancelButton_Click);
			// 
			// UpdateAppointDescTextInput
			// 
			this.UpdateAppointDescTextInput.BackColor = System.Drawing.Color.Chocolate;
			this.UpdateAppointDescTextInput.Location = new System.Drawing.Point(218, 22);
			this.UpdateAppointDescTextInput.Name = "UpdateAppointDescTextInput";
			this.UpdateAppointDescTextInput.Size = new System.Drawing.Size(200, 20);
			this.UpdateAppointDescTextInput.TabIndex = 8;
			this.UpdateAppointDescTextInput.TextChanged += new System.EventHandler(this.UpdateAppointDescTextInput_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(215, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Description";
			// 
			// dateTimePicker1TO
			// 
			this.dateTimePicker1TO.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1TO.Location = new System.Drawing.Point(218, 70);
			this.dateTimePicker1TO.Name = "dateTimePicker1TO";
			this.dateTimePicker1TO.ShowUpDown = true;
			this.dateTimePicker1TO.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1TO.TabIndex = 10;
			this.dateTimePicker1TO.ValueChanged += new System.EventHandler(this.dateTimePicker1TO_ValueChanged);
			// 
			// dateTimePicker1FROM
			// 
			this.dateTimePicker1FROM.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePicker1FROM.Location = new System.Drawing.Point(12, 70);
			this.dateTimePicker1FROM.Name = "dateTimePicker1FROM";
			this.dateTimePicker1FROM.ShowUpDown = true;
			this.dateTimePicker1FROM.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1FROM.TabIndex = 11;
			this.dateTimePicker1FROM.ValueChanged += new System.EventHandler(this.dateTimePicker1FROM_ValueChanged);
			// 
			// dateTimePicker2FROM
			// 
			this.dateTimePicker2FROM.Location = new System.Drawing.Point(12, 120);
			this.dateTimePicker2FROM.Name = "dateTimePicker2FROM";
			this.dateTimePicker2FROM.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2FROM.TabIndex = 12;
			this.dateTimePicker2FROM.ValueChanged += new System.EventHandler(this.dateTimePicker2FROM_ValueChanged);
			// 
			// dateTimePicker2TO
			// 
			this.dateTimePicker2TO.Location = new System.Drawing.Point(218, 120);
			this.dateTimePicker2TO.Name = "dateTimePicker2TO";
			this.dateTimePicker2TO.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2TO.TabIndex = 13;
			this.dateTimePicker2TO.ValueChanged += new System.EventHandler(this.dateTimePicker2TO_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Chocolate;
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Must select a time";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Chocolate;
			this.label3.Location = new System.Drawing.Point(218, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Must select a time";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Chocolate;
			this.label5.Location = new System.Drawing.Point(12, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Must select a date";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Chocolate;
			this.label8.Location = new System.Drawing.Point(218, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Must select a date";
			// 
			// UpdateAppTypeTextBox
			// 
			this.UpdateAppTypeTextBox.BackColor = System.Drawing.Color.Chocolate;
			this.UpdateAppTypeTextBox.Location = new System.Drawing.Point(133, 192);
			this.UpdateAppTypeTextBox.Name = "UpdateAppTypeTextBox";
			this.UpdateAppTypeTextBox.Size = new System.Drawing.Size(179, 20);
			this.UpdateAppTypeTextBox.TabIndex = 20;
			this.UpdateAppTypeTextBox.TextChanged += new System.EventHandler(this.UpdateAppTypeTextBox_TextChanged);
			// 
			// UpdAppTypeLabel
			// 
			this.UpdAppTypeLabel.AutoSize = true;
			this.UpdAppTypeLabel.Location = new System.Drawing.Point(130, 176);
			this.UpdAppTypeLabel.Name = "UpdAppTypeLabel";
			this.UpdAppTypeLabel.Size = new System.Drawing.Size(93, 13);
			this.UpdAppTypeLabel.TabIndex = 21;
			this.UpdAppTypeLabel.Text = "Appointment Type";
			// 
			// UpdateAppoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 336);
			this.Controls.Add(this.UpdAppTypeLabel);
			this.Controls.Add(this.UpdateAppTypeTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker2TO);
			this.Controls.Add(this.dateTimePicker2FROM);
			this.Controls.Add(this.dateTimePicker1FROM);
			this.Controls.Add(this.dateTimePicker1TO);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.UpdateAppointDescTextInput);
			this.Controls.Add(this.UpdateAppointCancelButton);
			this.Controls.Add(this.UpdateAppointSubmitButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.UpdateAppointmenIDtInputText);
			this.Name = "UpdateAppoint";
			this.Text = "UpdateAppoint";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox UpdateAppointmenIDtInputText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button UpdateAppointSubmitButton;
		private System.Windows.Forms.Button UpdateAppointCancelButton;
		private System.Windows.Forms.TextBox UpdateAppointDescTextInput;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.DateTimePicker dateTimePicker1TO;
		public System.Windows.Forms.DateTimePicker dateTimePicker1FROM;
		public System.Windows.Forms.DateTimePicker dateTimePicker2FROM;
		public System.Windows.Forms.DateTimePicker dateTimePicker2TO;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox UpdateAppTypeTextBox;
		private System.Windows.Forms.Label UpdAppTypeLabel;
	}
}