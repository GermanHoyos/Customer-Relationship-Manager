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
using System.IO;

namespace WGUC969Project {

//DATAFLOW for building DGV's
	// load "all customers" and "all Appointments" via sql query to dgv's							 [complete]
	// bold highlight in calender every appointment based on sql query								 [complete]
	// grab the first date of the month of the selected date in calender and parse					 [complete]
	// grab the first sunday prior to the selected date in calender and parse						 [complete]
	// used the above parsed values to construct sql queries that build the bottom right dgv		 [complete]
	// when monthly or weekly bools are cycled, repaint above steps									 [complete]
	// when any add/update/delete occures on cust's or app's, repaint above steps					 [complete]

//DATAFLOW for displaying times as per requirments
	//1) take local datetime picker and convert to UTC / string										 [complete]
	//2) put utc time in DB																			 [complete]
	//3) refresh DGV and display times in local time												 [complete]

public partial class Form1 : Form {
	//build datatables objetcs to populate later
		DataTable dt_1 = new DataTable();
		DataTable dt_2 = new DataTable();
		DataTable dt_3 = new DataTable();
	//write and save sql queries
		private static string QUERY1 = "select * from customer";
		private static string QUERY2 = "select * from appointment";
		public string QUERY3 = "select userName, password from user";
		public string FLUXQUERY = ""; //use concatanation / reassignment to modify this query as needed
		public string FLUXQUERY2 = ""; //use concatanation / reassignment to modify this query as needed
		public string DELETEAPPQUERY = "";
		public string DELETEAPPQUERY2 = "";
		public string DELETECUSTQUERY = "";
		public string deleteAscCountry = "";
	//public globals
		public bool loginSuccessfull = false;
		public bool weekly = false;
		public bool monthly = true;
		public string outPut;
		public string dateOnly;
		public string firstDayOfMonth;
		public string lastDayOfMonth;
		public string firstDayOfWeek;
	//select * from appointment where appointmentId = X; //mySql
	//populate this array dependent on date selected and bools above
		public int[] appointmentIDs = {};
	//convert to local or utc [testing purposes]
		//DateTime utcConverted = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
		//DateTime localTime = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);
		public int _userId;
	//x2 lambdas as per requirments
		Func<DateTime, DateTime> convertUTC = x => x.ToUniversalTime(); //function used convert passed value to UTC
		Func<DateTime, DateTime> convertLocal = x => x.ToLocalTime();  //functions used convert passed value to Local Time
	//x3 reports as per requirements
		//num of appointments types by month
		List<String> monthlyTypes = new List<String>();	
		//scheduale for each "consultant"
		List<String> custSched = new List<String>();
		////when customers where enrolled
		//List<String> custEnrol = new List<String>();


    public Form1(int userId) {//[--INITIAL BUILD--] //build this form and setup all DGV's only if username / password is confirmed
        InitializeComponent();

		//calls lambdas
		MessageBox.Show("Local Time: " + convertLocal(DateTime.Now) + "\nUTC time: " + convertUTC(DateTime.Now));

		//writes to file
		using(StreamWriter writetext = File.AppendText("loginLog.txt"))
		{
			writetext.WriteLine("UTC login time = " + DateTime.UtcNow.ToString() + ", User = " + userId.ToString());
		}
		
		//logged in user is
		_userId = userId;
		//MessageBox.Show(_userId.ToString());

		//a way to read individual fields
		MySqlDataReader reader;

		//initialize the DGV's to a null datasource;
		CustDGV.DataSource = dt_1;
		ApptDGV.DataSource = dt_2;
		CalDGV.DataSource = dt_3;

		//parse the above querys and attach them to MySqlCommand object
		MySqlCommand cmd_1 = new MySqlCommand(QUERY1, DBConnection.conn);
		MySqlCommand cmd_2 = new MySqlCommand(QUERY2, DBConnection.conn);

		//Represents a set of data commands and a db connection that are used to fill a
		//dataset and update a mySql database.This Class cannot be inheretid.
		MySqlDataAdapter adap_1 = new MySqlDataAdapter(cmd_1);
		MySqlDataAdapter adap_2 = new MySqlDataAdapter(cmd_2);

		//fill the "All Customers" and "All Appointments" DGV's with the data from the DB
		adap_1.Fill(dt_1);
		adap_2.Fill(dt_2);

		//Test Time Variables
		//MessageBox.Show("Your Local Time: " + localTime + "\n\nYour Time Converted to UTC " + utcConverted);
		
		//DGV formating
		CustDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		CustDGV.ReadOnly = true;
		CustDGV.MultiSelect = false;
		CustDGV.AllowUserToAddRows = false;
		CustDGV.RowHeadersVisible = false;
		CustDGV.Columns["addressId"].Visible = true;
		CustDGV.Columns["active"].Visible = false;
		CustDGV.Columns["createDate"].Visible = false;
		CustDGV.Columns["createdBy"].Visible = false;
		CustDGV.Columns["lastUpdate"].Visible = false;
		CustDGV.Columns["lastUpdateBy"].Visible = false;

		ApptDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		ApptDGV.ReadOnly = true;
		ApptDGV.MultiSelect = false;
		ApptDGV.AllowUserToAddRows = false;
		ApptDGV.RowHeadersVisible = false;
		ApptDGV.Columns["userId"].Visible = false;
		ApptDGV.Columns["title"].Visible = false;
		//ApptDGV.Columns["description"].Visible = false;
		ApptDGV.Columns["location"].Visible = false;
		ApptDGV.Columns["contact"].Visible = false;
		ApptDGV.Columns["url"].Visible = false;
		ApptDGV.Columns["createDate"].Visible = false;

		CalDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		CalDGV.ReadOnly = true;
		CalDGV.MultiSelect = false;
		CalDGV.AllowUserToAddRows = false;
		CalDGV.RowHeadersVisible = false;

		//modify times so there they are displayed in local to users time
		for (int i = 0; i < dt_2.Rows.Count; i++)
		{
			DateTime convertMe = (DateTime)dt_2.Rows[i]["start"];
			//DateTime convertMeUTC = convertMe;
			dt_2.Rows[i]["start"] = convertMe.ToLocalTime();
			//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime() + " DateTimeNow = " + DateTime.Now);
			
			//find any appointments within the next 15 mins and alert
			if 
			(
				convertMe <  DateTime.UtcNow.AddMinutes(15)	&&
				convertMe >= DateTime.UtcNow
			) 
			{
				MessageBox.Show("You have an appointment within the next 15 mins at: " + convertMe.ToLocalTime());
			}

		}
		for (int i = 0; i < dt_2.Rows.Count; i++)
		{
			DateTime convertMe = (DateTime)dt_2.Rows[i]["end"];
			//DateTime convertMeUTC = convertMe;
			dt_2.Rows[i]["end"] = convertMe.ToLocalTime();
			//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
		}

		//build CalDGV after this is built and called
		updateCalander();
	}

	public void updateCalander()  {//[--UPDATE BUILD--] //call this method anytime the calender needs updating and upon initial load of Form1
		monthCalendar1.RemoveAllBoldedDates();
		monthCalendar1.Refresh();
		foreach (DataRow row in dt_2.Rows) {// make dates bold
			string fluxDates = row["start"].ToString();
			//parse flux dates so that it can be passed to a date time object
			string parsedFlux = Regex.Match(fluxDates, @"^\S+").Value;
			DateTime highlightTheseDates = DateTime.Parse(parsedFlux);
			monthCalendar1.AddBoldedDate(highlightTheseDates);
		}
		monthCalendar1.UpdateBoldedDates();

		//Only show monthly appointments in DGV
		if (monthly) {
			//month of selected day
			string myMonth = monthCalendar1.SelectionRange.Start.Month.ToString();

			//year of selected day
			string myYear = monthCalendar1.SelectionRange.Start.Year.ToString();
			
			//convert to ints the above values
			int intMnth = Int32.Parse(myMonth);
			int intYr = Int32.Parse(myYear);	

			//how many days are in selected month
			int daysInMonth = DateTime.DaysInMonth(intYr, intMnth);

			//last date of month
			string finalDayInMonth = daysInMonth.ToString();

			//first day of month
			string firstDay = "1";

			//array to hold vals for join
			//string[] buildMe = {myMonth,firstDay,myYear};
			string[] buildMe = {myYear,myMonth,firstDay};
			
			//string[] buildMe2 = {myMonth,finalDayInMonth,myYear};
			string[] buildMe2 = {myYear,myMonth,finalDayInMonth};

			//first day of month of selected day
			firstDayOfMonth = string.Join("/",buildMe);

			//last day of month of selected day
			lastDayOfMonth = string.Join("/", buildMe2);

			//load dgv
			if (monthly) {
				//firstDayOfMonth
				//FLUXQUERY = "select * from appointment where start between \"2023-01-01\" and \"2023-01-31\""; // TEST
				FLUXQUERY = "select * from appointment where start between \"" + firstDayOfMonth + "\" and \"" + lastDayOfMonth +"\"";
				//MessageBox.Show(FLUXQUERY);
				//mySql command
				MySqlCommand cmd_3 = new MySqlCommand(FLUXQUERY, DBConnection.conn);
				MySqlDataAdapter adap_3 = new MySqlDataAdapter(cmd_3);
				dt_3.Clear();
				adap_3.Fill(dt_3);
				
				//convert to local here:
				for (int i = 0; i < dt_3.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_3.Rows[i]["start"];
					DateTime convertMeUTC = convertMe;
					dt_3.Rows[i]["start"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}
				for (int i = 0; i < dt_3.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_3.Rows[i]["end"];
					DateTime convertMeUTC = convertMe;
					dt_3.Rows[i]["end"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}

			}
		}
		//Only show weekly appointments in DGV
		if (weekly) {
			DateTime begginingOfWeek = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);
			DateTime endOfWeek = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);

			//stringified current date
			string  mmddyyyy = monthCalendar1.SelectionRange.Start.ToShortDateString(); //[mm/dd/yyyy]
			
			//pasred sringified date to DateTime Object
			DateTime myDateObj = DateTime.Parse(mmddyyyy);

			//find first day if week of the selected date
			for (int i = 7; i > 0; i--)	{
				if (myDateObj.DayOfWeek.ToString() != "Sunday"){
					myDateObj = myDateObj.AddDays(-1);
				} else {
					begginingOfWeek = myDateObj; //returns [1/8/2023]
				}
			}

			//range needed for 7 days of the week
			endOfWeek = begginingOfWeek.AddDays(+6);

			//MessageBox.Show("Beggining of week: " + begginingOfWeek.ToString("yyyy/dd/MM") + "\nend of week " + endOfWeek.ToString("yyyy/dd/MM")); //verified true [1/8/2023]
			
			//assign globaly
			firstDayOfWeek = begginingOfWeek.ToShortDateString();

			//load dgv
			if (weekly) {
				//begginingOfWeek
				//FLUXQUERY = "select * from appointment where start between \"2023-01-01\" and \"2023-01-7\"";
				FLUXQUERY2 = "select * from appointment where start between \""+ begginingOfWeek.ToString("yyyy/MM/dd") +"\" and \""+ endOfWeek.ToString("yyyy/MM/dd") +"\"";
				//mySql command
				MySqlCommand cmd_4 = new MySqlCommand(FLUXQUERY2, DBConnection.conn);
				MySqlDataAdapter adap_4 = new MySqlDataAdapter(cmd_4);
				dt_3.Clear();
				adap_4.Fill(dt_3);

				//convert to local here:
				for (int i = 0; i < dt_3.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_3.Rows[i]["start"];
					DateTime convertMeUTC = convertMe;
					dt_3.Rows[i]["start"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}
				for (int i = 0; i < dt_3.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_3.Rows[i]["end"];
					DateTime convertMeUTC = convertMe;
					dt_3.Rows[i]["end"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}
			}
		}
	}

	//event listener of new selection of an date
	private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
		//MessageBox.Show(monthCalendar1.SelectionRange.Start.ToLongDateString()); // ex: [Thursday, Januaray 5th, 2023]
		updateCalander();
	}

	//constructed by following WGU video // not used btn
    private void ConnectB_Click(object sender, EventArgs e) {
        //get connetion string
        string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        //Make connection
        MySqlConnection conn = null;

        //Try to Open connection
        try {
            conn = new MySqlConnection(constr);
            //Open the connection
            conn.Open();
            //MessageBox.Show("Connection is open");
        }
        catch (MySqlException ex) {
            //MessageBox.Show(ex.Message);
        }
        finally {
            //close the connection
            if (conn != null) {
                conn.Close();
            }
        }

    }

	//deleted button
	private void LoginButton_Click(object sender, EventArgs e) {
		Login loginForm = new Login();
		loginForm.Show();
	}

	//cust add button
	private void CustAddButton_Click(object sender, EventArgs e) {
		AddCust addCustForm = new AddCust(this);
		addCustForm.Show();
	}

	private void CustUpdateButton_Click(object sender, EventArgs e)
	{

		//[CUSTOMER ID KEY]
		int selectedRow = CustDGV.CurrentCell.RowIndex;
		int dbCustId = (int)CustDGV.Rows[selectedRow].Cells[0].Value;
		//MessageBox.Show("Customer selected for deletion: " + dbCustId.ToString());

		//delete associated but not displayed in DGV connections
		//[ADDRESS ID KEY]
		string findThisAddressCmd = "select addressId from customer where customerId = " + dbCustId;
		MySqlCommand sqlConvert1 = new MySqlCommand(findThisAddressCmd, DBConnection.conn);
		int addressIdKey = (Int32)sqlConvert1.ExecuteScalar();

		//[CITY ID KEY]
		string findThisCityCmd = "select cityId from address where addressId = " + addressIdKey;
		MySqlCommand sqlConvert2 = new MySqlCommand(findThisCityCmd, DBConnection.conn);
		int cityIdKey = (Int32)sqlConvert2.ExecuteScalar();

		//[COUNTRY ID KEY]
		string findThisCountryCmd = "select countryId from city where cityId = " + cityIdKey;
		MySqlCommand sqlConvert3 = new MySqlCommand(findThisCountryCmd, DBConnection.conn);
		int countryIdKey = (Int32)sqlConvert3.ExecuteScalar();		

		//UpdateCust updateCustForm = new UpdateCust(); // not overloaded call
		UpdateCust updateCustForm = new UpdateCust(dbCustId, addressIdKey, cityIdKey, countryIdKey, this);
		updateCustForm.Show();		

	}

	private void CustDeleteButton_Click(object sender, EventArgs e)
	{
		string message = "Delete customer and all associated appointments / data?";
		string title = "Delete Confirmation";
		MessageBoxButtons buttons = MessageBoxButtons.YesNo;
		DialogResult result = MessageBox.Show(message, title, buttons);
		if (result == DialogResult.Yes){
			if(CustDGV.RowCount > 0){
				//CustDGV.DataSource = dt_1;
				//ApptDGV.DataSource = dt_2;
				//CalDGV.DataSource = dt_3;

				//[CUSTOMER ID KEY]
				int selectedRow = CustDGV.CurrentCell.RowIndex;
				int dbCustId = (int)CustDGV.Rows[selectedRow].Cells[0].Value;
				//MessageBox.Show("Customer selected for deletion: " + dbCustId.ToString());
				string keyConnects = "SET FOREIGN_KEY_CHECKS="+0+"";
				MySqlCommand keyF = new MySqlCommand(keyConnects, DBConnection.conn);
				keyF.ExecuteNonQuery();
				
				//delete associated but not displayed in DGV connections
				//[ADDRESS ID KEY]
				string findThisAddressCmd = "select addressId from customer where customerId = " + dbCustId;
				MySqlCommand sqlConvert1 = new MySqlCommand(findThisAddressCmd, DBConnection.conn);
				int addressIdKey = (Int32)sqlConvert1.ExecuteScalar();

				//[CITY ID KEY]
				string findThisCityCmd = "select cityId from address where addressId = " + addressIdKey;
				MySqlCommand sqlConvert2 = new MySqlCommand(findThisCityCmd, DBConnection.conn);
				int cityIdKey = (Int32)sqlConvert2.ExecuteScalar();

				//[COUNTRY ID KEY]
				string findThisCountryCmd = "select countryId from city where cityId = " + cityIdKey;
				MySqlCommand sqlConvert3 = new MySqlCommand(findThisCountryCmd, DBConnection.conn);
				int countryIdKey = (Int32)sqlConvert3.ExecuteScalar();

				//for testing purposes
				//MessageBox.Show("***********" + countryIdKey.ToString());

				//[DELETE APPOINTMENTS]
				//delete from appointment table all instances of cust X
				DELETEAPPQUERY2 = "delete from appointment where customerId = " + dbCustId.ToString();
				MySqlCommand cmd_5 = new MySqlCommand(DELETEAPPQUERY2, DBConnection.conn);
				cmd_5.ExecuteNonQuery(); //remove apps from DB		

				//[DELETE CUSTOMER]
				//delete selected customer 
				DELETECUSTQUERY = "delete from customer where customerId = " + dbCustId.ToString();
				MySqlCommand cmd_6 = new MySqlCommand(DELETECUSTQUERY, DBConnection.conn);
				cmd_6.ExecuteNonQuery();

				//delete [ASSOCIATED ADDRESS]
				string dltAscAddress = "delete from address where addressId = " + addressIdKey.ToString();
				MySqlCommand sqlConvert6 = new MySqlCommand(dltAscAddress, DBConnection.conn);
				sqlConvert6.ExecuteNonQuery();

				//delete [ASSOCIATED CITY]
				string dltAscCity = "delete from city where cityId = " + cityIdKey.ToString();
				MySqlCommand sqlConvert5 = new MySqlCommand(dltAscCity, DBConnection.conn);
				sqlConvert5.ExecuteNonQuery();

				//delete [ASSOCIATED COUNTRY] //used a global string for testing purposes
				deleteAscCountry = "delete from country where countryId = " + countryIdKey.ToString();
				MySqlCommand sqlConvert4 = new MySqlCommand(deleteAscCountry, DBConnection.conn);
				sqlConvert4.ExecuteNonQuery();
				string keyConnectsOn = "SET FOREIGN_KEY_CHECKS="+1+"";
				MySqlCommand keyFOn = new MySqlCommand(keyConnectsOn, DBConnection.conn);
				keyFOn.ExecuteNonQuery();

				//refresh ApptDGV and CalDGV and Cal
				dt_2.Clear(); // clear ApptDGV
				MySqlCommand cmd_2 = new MySqlCommand(QUERY2, DBConnection.conn); //"select * from appointment"
				MySqlDataAdapter adap_4 = new MySqlDataAdapter(cmd_2);
				adap_4.Fill(dt_2); // fill ApptDGV

				//convert to local here:
				for (int i = 0; i < dt_2.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_2.Rows[i]["start"];
					DateTime convertMeUTC = convertMe;
					dt_2.Rows[i]["start"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}				
				for (int i = 0; i < dt_2.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_2.Rows[i]["end"];
					DateTime convertMeUTC = convertMe;
					dt_2.Rows[i]["end"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}

				dt_3.Clear(); // clear calender
				updateCalander(); // fill calender

				//refresh Cust.DGV 
				dt_1.Clear(); // clear custDGV 
				MySqlCommand cmd_1 = new MySqlCommand(QUERY1, DBConnection.conn); //"select * from customer"
				MySqlDataAdapter adap_1 = new MySqlDataAdapter(cmd_1);
				adap_1.Fill(dt_1); // fill custDGV

				updateCalander();
			} else {
				MessageBox.Show("No customers to delete");
			}
		} else {
			return;
		}
	}

	private void ApptAddButton_Click(object sender, EventArgs e)
	{
		AddAppoint addAppointForm = new AddAppoint(this, dt_2);
		addAppointForm.Show();
	}

	private void ApptUpdateButton_Click(object sender, EventArgs e)
	{
		int selectedRow = ApptDGV.CurrentCell.RowIndex;
		int dbApptId = (int)ApptDGV.Rows[selectedRow].Cells[0].Value;
		UpdateAppoint updateAppointForm = new UpdateAppoint(this, dbApptId, dt_2);
		//UpdateAppoint updateAppointForm = new UpdateAppoint();
		
		updateAppointForm.Show();
	}

	//delete App btn
	private void button4_Click(object sender, EventArgs e) 
	{
		string message = "Delete this selected appointment?";
		string title = "Delete Confirmation";
		MessageBoxButtons buttons = MessageBoxButtons.YesNo;
		DialogResult result = MessageBox.Show(message, title, buttons);
		if (result == DialogResult.Yes){
			if(ApptDGV.RowCount > 0){
				int selectedRow = ApptDGV.CurrentCell.RowIndex;
				int dbApptId = (int)ApptDGV.Rows[selectedRow].Cells[0].Value;
				//MessageBox.Show("The appointment you selected is: " + dbApptId);
				DELETEAPPQUERY = "delete from appointment where appointmentID = " + dbApptId.ToString();
				MySqlCommand cmd_4 = new MySqlCommand(DELETEAPPQUERY, DBConnection.conn);
				cmd_4.ExecuteNonQuery();
				dt_2.Clear();
				MySqlCommand cmd_2 = new MySqlCommand(QUERY2, DBConnection.conn);
				MySqlDataAdapter adap_4 = new MySqlDataAdapter(cmd_2);
				adap_4.Fill(dt_2);

				//convert to local here:
				for (int i = 0; i < dt_2.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_2.Rows[i]["start"];
					DateTime convertMeUTC = convertMe;
					dt_2.Rows[i]["start"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}
				for (int i = 0; i < dt_2.Rows.Count; i++)
				{
					DateTime convertMe = (DateTime)dt_2.Rows[i]["end"];
					DateTime convertMeUTC = convertMe;
					dt_2.Rows[i]["end"] = convertMe.ToLocalTime();
					//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
				}

				dt_3.Clear();
				updateCalander();
			} else {
				MessageBox.Show("No appointments to delete");
			}			
		} else {
			return;
		}
	}

	//to be ran win form closes
	private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
		Application.Exit();
	}
	
	//to be ran win form loads
	private void Form1_Load(object sender, EventArgs e) {

	}

	private void CalenderWeeklyButton_Click(object sender, EventArgs e) {
		weekly = true;
		monthly = false;
		updateCalander();
		label1.Text = "WEEKLY appointments based on selected calender date";
	}
	
	private void CalenderMonthlyButton_Click(object sender, EventArgs e) {
		monthly = true;
		weekly = false;
		updateCalander();
		label1.Text = "MONTHLY appointments based on selected calender date";

	}

	public void outerCallToRefresh() 
	{
		//test call
		MessageBox.Show("called");

		//refresh Cust.DGV 
		dt_1.Clear(); // clear custDGV 
		MySqlCommand cmd_1 = new MySqlCommand(QUERY1, DBConnection.conn); //"select * from customer"
		MySqlDataAdapter adap_1 = new MySqlDataAdapter(cmd_1);
		adap_1.Fill(dt_1); // fill custDGV

		//refresh ApptDGV and CalDGV and Cal
		dt_2.Clear(); // clear ApptDGV
		MySqlCommand cmd_2 = new MySqlCommand(QUERY2, DBConnection.conn); //"select * from appointment"
		MySqlDataAdapter adap_4 = new MySqlDataAdapter(cmd_2);
		adap_4.Fill(dt_2); // fill ApptDGV

		//convert to local here:
		for (int i = 0; i < dt_2.Rows.Count; i++)
		{
			DateTime convertMe = (DateTime)dt_2.Rows[i]["start"];
			DateTime convertMeUTC = convertMe;
			dt_2.Rows[i]["start"] = convertMe.ToLocalTime();
			//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
		}
		for (int i = 0; i < dt_2.Rows.Count; i++)
		{
			DateTime convertMe = (DateTime)dt_2.Rows[i]["end"];
			DateTime convertMeUTC = convertMe;
			dt_2.Rows[i]["end"] = convertMe.ToLocalTime();
			//MessageBox.Show("UTC = " + convertMeUTC + " Local = " + convertMe.ToLocalTime());
		}

		dt_3.Clear(); // clear calender
		updateCalander(); // fill calender
		
	}

	//x3 reports as per requirements
	////num of appointments types by month
		//List<String> monthlyTypes = new List<String>();	
	////scheduale for each "consultant"
		//List<String> custSched = new List<String>();
	////when customers where enrolled
		//List<String> custEnrol = new List<String>();

	private void TypeReportButton_Click(object sender, EventArgs e)
	{
		label2.Text = "Report: Num of appointment types by month";
		ReportViewer.Text = "";
		int indexTrack = 0;
		string[] Months = new string[] {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
		string[] numMnt = new string[] {"01","02","03","04","05","06","07","08","09","10","11","12"};
		foreach (string month in Months){
			ReportViewer.Text += month + Environment.NewLine;	
			string monthlyReportsSQL = "select type, count(*) from appointment where month(start) = \""+numMnt[indexTrack]+"\" group by type;";
			MySqlCommand cmd_1 = new MySqlCommand(monthlyReportsSQL, DBConnection.conn);
			MySqlDataReader reportString = cmd_1.ExecuteReader();
			while (reportString.Read()) {
				//ReportViewer.Text += "   ";
				string type = reportString.GetString("type");
				string count = reportString.GetString("count(*)");
				//ReportViewer.Text += "    " + type + ": " + count + Environment.NewLine;
				//add to list
				monthlyTypes.Add("    " + month + " : " + type + " : " + count + Environment.NewLine);
			}
			foreach (string types in monthlyTypes){
				//MessageBox.Show(types);
				ReportViewer.Text += types;
			}
			monthlyTypes.Clear();
			reportString.Close();
			indexTrack++;
			if (indexTrack == 12) {
				indexTrack = 0;
			}
		}
	}

	private void SchedReportButton_Click(object sender, EventArgs e) //List<String> custSched = new List<String>();
	{
		label2.Text = "Report: Signed in user scheduale";
		ReportViewer.Text = "";
		//initialize the DGV's to a null datasource;
		//CustDGV.DataSource = dt_1;
		//ApptDGV.DataSource = dt_2;
		//CalDGV.DataSource = dt_3;
		ReportViewer.Text = "Your User ID: " + _userId + Environment.NewLine + "Your Appointments: " + Environment.NewLine;
		string getUserReport = "select * from appointment where userId = " + _userId.ToString()+ ";";
		MySqlCommand cmd_2 = new MySqlCommand(getUserReport, DBConnection.conn);
		MySqlDataReader reportString = cmd_2.ExecuteReader();
		while (reportString.Read()) {
			ReportViewer.Text += "   ";
			string appId = reportString.GetString("appointmentId");
			string apptype = reportString.GetString("type");
			string appStart = reportString.GetString("start");
			string appEnd = reportString.GetString("end");
			//ReportViewer.Text += "App ID: " + appId + " Type: " + apptype + " Start: " + appStart + " End: " + appEnd  + Environment.NewLine + Environment.NewLine;
			custSched.Add("App ID: " + appId + " Type: " + apptype + " Start: " + appStart + " End: " + appEnd  + Environment.NewLine + Environment.NewLine);
		}
			foreach (string apps in custSched){
				//MessageBox.Show(apps);
				ReportViewer.Text += apps;
			}
			custSched.Clear();

		reportString.Close();
	}	

	private void CustReportButton_Click(object sender, EventArgs e) 
	{
		label2.Text = "Report: all customer ID's";
		ReportViewer.Text = "";
		string getCustomerReport = "select * from customer";
		MySqlCommand cmd_3 = new MySqlCommand(getCustomerReport, DBConnection.conn);
		MySqlDataReader reportstring = cmd_3.ExecuteReader();
		while (reportstring.Read()) {
			string custId = reportstring.GetString("customerId");
			string custName = reportstring.GetString("customerName");
			ReportViewer.Text += "Customer ID: " + custId + " >> Customer Name: " + custName + Environment.NewLine + Environment.NewLine;
		}
		reportstring.Close();
		


	}






























	} // end public partial class Form1 : Form {

} // end namespace WGUC969Project {
