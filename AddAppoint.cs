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

	public partial class AddAppoint : Form
	{

		public string addAppointStr;
		public int existsInDB;
		public string inputCust;
		public string  inputDescription;
		public string inputStartTime;
		public string inputEndTime;
		public string inputType;
		public int getExistsReturn;
		private Form1 _form1;
		DataTable _dt_2;

		DateTime FROMhhmmtt;	public string fromTimeConverted = "";	
		DateTime FROMmmddyyyy;	public string fromDateConverted = "";   
		DateTime TOhhmmtt;		public string toTimeConverted = "";		
		DateTime TOmmddyyyy;	public string toDateConverted = "";		

		//DATAFLOW for displaying times
			//1) take local datime picker and convert to UTC / string
			//2) put utc time in DB
			//3) refresh DGV and display times in local time

		public AddAppoint()
		{
			InitializeComponent();
		}

		public AddAppoint(Form1 form1, DataTable dt_2)
		{

			_form1 = form1;
			_dt_2 = dt_2;
			InitializeComponent();
			
			dateTimePicker1FROM.CustomFormat = "HH:mm:ss tt";
			dateTimePicker1TO.CustomFormat = "HH:mm:ss tt";
		}

		private void AddAppointmentCustIDTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddAppointmentCustIDTextInput.Text, @"^[0-9]+$") && AddAppointmentCustIDTextInput.Text.Length > 0)
			{
				AddAppointmentCustIDTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Numbers Only");
				AddAppointmentCustIDTextInput.Text = "";
			}
			else
			{
				AddAppointmentCustIDTextInput.BackColor = (AddAppointmentCustIDTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				inputCust = AddAppointmentCustIDTextInput.Text;
			}
		}

		private void AddAppointDescriptionTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddAppointDescriptionTextInput.Text, @"^[a-zA-Z\s]+$") && AddAppointDescriptionTextInput.Text.Length > 0)
			{
				AddAppointDescriptionTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            AddAppointDescriptionTextInput.Text = "";
			}
			else
			{
				AddAppointDescriptionTextInput.BackColor = (AddAppointDescriptionTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				inputDescription = AddAppointDescriptionTextInput.Text;
			}
			
			
		}

		//FROM time
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
			FROMhhmmtt = dateTimePicker1FROM.Value;
			//MessageBox.Show(FROMhhmmtt.ToString("hh':'mm':'ss"));
			//fromTimeConverted = FROMhhmmtt.ToString("HH':'mm':'ss"); //start time
			fromTimeConverted = FROMhhmmtt.ToUniversalTime().ToString("HH':'mm':'ss"); //start time
			
			label3.BackColor = Color.LightGreen;
			label3.Text = "Time selected";
		}

		//FROM date
		private void dateTimePicker2FROM_ValueChanged(object sender, EventArgs e)
		{
			FROMmmddyyyy = dateTimePicker2FROM.Value;
			//MessageBox.Show(FROMmmddyyyy.ToString("yyyy'-'MM'-'dd"));
			fromDateConverted = FROMmmddyyyy.ToString("yyyy'-'MM'-'dd"); //start date // "converted means to string not to LOCAL" All db times are UTC
			label1.BackColor = Color.LightGreen;
			label1.Text = "Date selected";
		}

		//TO time
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

			TOhhmmtt = dateTimePicker1TO.Value;
			//MessageBox.Show(TOhhmmtt.ToString("hh':'mm':'ss"));
			toTimeConverted = TOhhmmtt.ToUniversalTime().ToString("HH':'mm':'ss"); //end time // "converted means to string not to LOCAL" All db times are UTC
			label2.BackColor = Color.LightGreen;
			label2.Text = "Time selected";
		}

		//TO date
		private void dateTimePicker2TO_ValueChanged(object sender, EventArgs e)
		{
			TOmmddyyyy = dateTimePicker2TO.Value;
			//MessageBox.Show(TOmmddyyyy.ToString("yyyy'-'MM'-'dd"));
			toDateConverted = TOmmddyyyy.ToString("yyyy'-'MM'-'dd"); //end date
			label4.BackColor = Color.LightGreen;
			label4.Text = "Date Selected";
		}

		private void AddAppointSubmitButton_Click(object sender, EventArgs e)
		{
			int dbCustId = Convert.ToInt32(inputCust);
			
			if 
			(
				fromDateConverted.Length < 1 || 
				fromTimeConverted.Length  < 1 || // "converted means to string not to LOCAL" All db times are UTC
				toDateConverted.Length < 1 ||
				toTimeConverted.Length < 1 // "converted means to string not to LOCAL" All db times are UTC
			)
			{
				MessageBox.Show("You must select to and from dates and times");
				return;
			} else 
			{
				//executre rest of function
			}

			//if times are outside of business hours and also not in proper order
			if (FROMhhmmtt > TOhhmmtt) {
				MessageBox.Show("Your end time cannot be before your start time");
				return;
			}

			//check if times overlap check
			for (int i = 0; i < _dt_2.Rows.Count; i++) {
				//grab times
				
				//[START](A)
				DateTime DBAppStartTimeUTC = (DateTime)_dt_2.Rows[i]["start"]; DateTime START_A = DBAppStartTimeUTC;
				//[END](A)
				DateTime DBAppEndTimeUTC =	(DateTime)_dt_2.Rows[i]["end"]; DateTime END_A = DBAppEndTimeUTC;
				
				//[START](B)						(date)						(time)
				DateTime inputFrom = DateTime.Parse(fromDateConverted + " " + fromTimeConverted); DateTime START_B = inputFrom;   // this is in UTC
				//[END](B)							(date)						(time)
				DateTime inputTo = DateTime.Parse(toDateConverted + " " + toTimeConverted); DateTime END_B = inputTo; //this is in UTC

				// keep in mind - even though the DB is in utc - make these comparisons at the USER LEVEL which is local
					// 1) get the [START](A) and [END](A) time of each row
					// 2) get the [START](B) and [END](B) time of input value
					// 
					// 3) if  the [START](B) > [START](A) AND [START](B) < [END](A) RETURN FAIL
					// 3) if  the [END](B) > [START](A) AND [END](B) < [END](A)		RETURN FAIL

				if (START_B.ToLocalTime() > START_A && START_B.ToLocalTime() < END_A) {MessageBox.Show("INPUT START= " + START_B.ToString() + "DBROW START= " + START_A.ToString() + " DBROWEND= " + END_A.ToString()); return;}
				if (END_B.ToLocalTime() > START_A && END_B.ToLocalTime() < END_A) {MessageBox.Show("your selected end time conflicts with an existing appointment"); return;}

			}

			//check to see if customer ID exists
			string custExists = "select count(customerId) as \"customer Exists\" from customer where customerId = " + dbCustId + "";
			MySqlCommand getExists = new MySqlCommand(custExists, DBConnection.conn);
			getExistsReturn = Convert.ToInt32(getExists.ExecuteScalar());
			if (getExistsReturn > 0) // returns 0 if the custExists cmd results in no customers found
			{
				//MessageBox.Show("this customer does exist");

				//execute code to add appointment to customer
				string insertAppStr = "insert into appointment (customerId,userId,title,description,location,contact,type,url,start,end,createDate,createdBy,lastUpdateBy)" +
				" value ("+ dbCustId +","+ _form1._userId +",'test','" + inputDescription + "','test','test','"+ inputType +"','test'," +
				"'"+fromDateConverted+" "+fromTimeConverted+"'," + //start // "converted means to string not to LOCAL" All db times are UTC                      
				"'"+toDateConverted+" "+toTimeConverted+"'," + //end // "converted means to string not to LOCAL" All db times are UTC
				"'2023-01-09 00:00:00'," + //createDate
				"'test','test');";
				//MessageBox.Show(insertAppStr);
				MySqlCommand insertAppSql = new MySqlCommand(insertAppStr, DBConnection.conn);
				insertAppSql.ExecuteNonQuery();
				
				//refresh
				_form1.outerCallToRefresh();
				
				//close
				//this.Close();
				
			} else {
				MessageBox.Show("this customer does not exist");
			}
		}

		private void AddAppointCancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddAppointmentTypeTextBox_TextChanged(object sender, EventArgs e)
		{
			//check for proper input type validation
			if (!Regex.IsMatch(AddAppointmentTypeTextBox.Text, @"^[a-zA-Z\s]+$") && AddAppointmentTypeTextBox.Text.Length > 0)
			{
				AddAppointmentTypeTextBox.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
				AddAppointmentTypeTextBox.Text = "";
			}
			else
			{
				AddAppointmentTypeTextBox.BackColor = (AddAppointmentTypeTextBox.Text.Length == 0) ? Color.Chocolate : Color.White;
				inputType = AddAppointmentTypeTextBox.Text;
			}
		}
	}
}
