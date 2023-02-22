using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WGUC969Project.Database;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WGUC969Project
{
	public partial class UpdateAppoint : Form
	{

		public int _dbApptId;
		public string inputDescription;
		public string inputType;
		private Form1 _form1;
		DataTable _dt_2;

		DateTime FROMhhmmttUDP;			public string fromTimeConvertedUDP = "";
		DateTime FROMmmddyyyyUDP;		public string fromDateConvertedUDP = "";
		DateTime TOhhmmttUDP;			public string toTimeConvertedUDP = "";
		DateTime TOmmddyyyyUDP;			public string toDateConvertedUDP = "";

		public UpdateAppoint()
		{
			InitializeComponent();
		}

		public UpdateAppoint(Form1 form1, int dbApptId, DataTable dt_2)
		{
			
			_form1 = form1;
			_dbApptId = dbApptId;
			_dt_2 = dt_2;
			//MessageBox.Show(_dbApptId.ToString());
			InitializeComponent();
			UpdateAppointmenIDtInputText.Text = _dbApptId.ToString();
		}

		//chosen with highlight
		private void UpdateAppointmenIDtInputText_TextChanged(object sender, EventArgs e)
		{
			//un changable			
		}

		private void UpdateAppointDescTextInput_TextChanged(object sender, EventArgs e)
		{
			if (!Regex.IsMatch(UpdateAppointDescTextInput.Text, @"^[a-zA-Z\s]+$") && UpdateAppointDescTextInput.Text.Length > 0)
			{
				UpdateAppointDescTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
				UpdateAppointDescTextInput.Text = "";
			}
			else
			{
				UpdateAppointDescTextInput.BackColor = (UpdateAppointDescTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				inputDescription = UpdateAppointDescTextInput.Text;
			}
		}

		private void dateTimePicker1FROM_ValueChanged(object sender, EventArgs e)
		{

			DateTime Early = DateTime.Parse("09:00:00 AM");
			DateTime Late = DateTime.Parse("05:00:00 PM");
			if(dateTimePicker1FROM.Value < Early || dateTimePicker1FROM.Value > Late) {
				MessageBox.Show("Business hours are from 9am to 5pm");
				
				return; // exit this functions execution
			} else {
				 // continue this functions execution
			}

			FROMhhmmttUDP = dateTimePicker1FROM.Value;
			//MessageBox.Show(FROMhhmmtt.ToString("hh':'mm':'ss"));
			fromTimeConvertedUDP = FROMhhmmttUDP.ToUniversalTime().ToString("HH':'mm':'ss"); //start time
			MessageBox.Show(fromTimeConvertedUDP);
			label2.BackColor = Color.LightGreen;
			label2.Text = "Time selected";
		}

		private void dateTimePicker2FROM_ValueChanged(object sender, EventArgs e)
		{
			FROMmmddyyyyUDP = dateTimePicker2FROM.Value;
			//MessageBox.Show(FROMmmddyyyy.ToString("yyyy'-'MM'-'dd"));
			fromDateConvertedUDP = FROMmmddyyyyUDP.ToString("yyyy'-'MM'-'dd"); //start date
			label5.BackColor = Color.LightGreen;
			label5.Text = "Date selected";

		}

		private void dateTimePicker1TO_ValueChanged(object sender, EventArgs e)
		{

			DateTime Early = DateTime.Parse("09:00:00 AM");
			DateTime Late = DateTime.Parse("05:00:00 PM");
			if(dateTimePicker1TO.Value < Early || dateTimePicker1TO.Value > Late) {
				MessageBox.Show("Business hours are from 9am to 5pm");
				
				return; // exit this functions execution
			} else {
				 // continue this functions execution
			}

			TOhhmmttUDP = dateTimePicker1TO.Value;
			//MessageBox.Show(TOhhmmtt.ToString("hh':'mm':'ss"));
			toTimeConvertedUDP = TOhhmmttUDP.ToUniversalTime().ToString("HH':'mm':'ss"); //end time
			label3.BackColor = Color.LightGreen;
			label3.Text = "Time selected";
		}

		private void dateTimePicker2TO_ValueChanged(object sender, EventArgs e)
		{
			TOmmddyyyyUDP = dateTimePicker2TO.Value;
			//MessageBox.Show(TOmmddyyyy.ToString("yyyy'-'MM'-'dd"));
			toDateConvertedUDP = TOmmddyyyyUDP.ToString("yyyy'-'MM'-'dd"); //end date
			label8.BackColor = Color.LightGreen;
			label8.Text = "Date selected";
		}

		private void UpdateAppointSubmitButton_Click(object sender, EventArgs e)
		{
			if 
			(
				fromDateConvertedUDP.Length < 1 ||
				fromTimeConvertedUDP.Length  < 1 || 
				toDateConvertedUDP.Length < 1 ||
				toTimeConvertedUDP.Length < 1 
			)
			{
				MessageBox.Show("You must select to and from dates and times");
				return;
			} else 
			{
				//executre rest of function
			}

			//if times are outside of business hours and also not in proper order
			if (FROMhhmmttUDP > TOhhmmttUDP) {
				MessageBox.Show("Your end time cannot be before your start time");
				return;
			}

			//if times overlap check
			for (int i = 0; i < _dt_2.Rows.Count; i++) {
				//grab times
				DateTime DBAppStartTimeUTC = (DateTime)_dt_2.Rows[i]["start"];
				DateTime DBAppEndTimeUTC =	(DateTime)_dt_2.Rows[i]["end"];
				DateTime DBAppStartTimeLocal = DBAppStartTimeUTC.ToLocalTime();
				DateTime DBAppEndTimeLocal = DBAppEndTimeUTC.ToLocalTime();
				DateTime inputFrom = DateTime.Parse(fromDateConvertedUDP + " " + fromTimeConvertedUDP);
				DateTime inputTo = DateTime.Parse(toDateConvertedUDP + " " + toTimeConvertedUDP);

				if (inputFrom >= DBAppStartTimeLocal && inputTo <= DBAppEndTimeLocal){
					MessageBox.Show("Your Appointment times overlap with a prexisting appointment");
					return;
				}
			}

			//update appointment where appoinment id = _dbApptId;
			string updateSQl = "update appointment set description = '" + inputDescription + "' where appointmentId = '" + _dbApptId.ToString() + "'";
			//MessageBox.Show(updateSQl);
			MySqlCommand updApp = new MySqlCommand(updateSQl, DBConnection.conn);
			updApp.ExecuteNonQuery();

			string updateFromSql = "update appointment set start = '" + fromDateConvertedUDP + " "+fromTimeConvertedUDP+"' where appointmentId = '"+_dbApptId.ToString()+"';";
			//MessageBox.Show(updateFromSql);
			MySqlCommand updFrom = new MySqlCommand(updateFromSql, DBConnection.conn);
			updFrom.ExecuteNonQuery();

			string updateToSql = "update appointment set end = '" + toDateConvertedUDP + " "+toTimeConvertedUDP+"' where appointmentId = '"+ _dbApptId.ToString()+ "';";
			//MessageBox.Show(updateToSql);
			MySqlCommand updTo = new MySqlCommand(updateToSql, DBConnection.conn);
			updTo.ExecuteNonQuery();

			//update Type sql
			//update appointment set type = 'newType' where appointmentId = 1;
			string updateTypeSql = "update appointment set type = '"+ inputType +"' where appointmentId = '"+ _dbApptId.ToString() +"';";
			MySqlCommand updType = new MySqlCommand(updateTypeSql, DBConnection.conn);
			updType.ExecuteNonQuery();


			//refresh
			_form1.outerCallToRefresh();

			//close
			this.Close();
		}

		private void UpdateAppointCancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void UpdateAppTypeTextBox_TextChanged(object sender, EventArgs e)
		{

			//check for proper input type validation
			if (!Regex.IsMatch(UpdateAppTypeTextBox.Text, @"^[a-zA-Z\s]+$") && UpdateAppTypeTextBox.Text.Length > 0)
			{
				UpdateAppTypeTextBox.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
				UpdateAppTypeTextBox.Text = "";
			}
			else
			{
				UpdateAppTypeTextBox.BackColor = (UpdateAppTypeTextBox.Text.Length == 0) ? Color.Chocolate : Color.White;
				inputType = UpdateAppTypeTextBox.Text;
			}
		}
	}
}
