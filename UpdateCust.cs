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
	public partial class UpdateCust : Form
	{
		//globals
		public string firstName;
		public string lastName;
		public string customerAddress;
		public string customerCity;
		public string customerCountry;
		public string finalNameForDB;
		public string addCustStr;
		public string phoneNumber;
					
		//relevent Keys of selected customer and associated tables
		//custID <-> addressId <-> cityId <-> countryId
		public int dbCustIdglobal;
		public int countryTableId;
		public int cityTableId;
		public int addressTableId;

		//commands needed for editing data
		public string addCountryCmd;
		public string addCityCmd;
		public string addAddressCmd;
		private Form1 _form1;
		
		
		public UpdateCust()
		{
			InitializeComponent();
		}

		public UpdateCust(int dbCustid, int addressIdKey, int cityIdKey, int countryIdKey, Form1 form1)
		{
			InitializeComponent();
			dbCustIdglobal = dbCustid;
			addressTableId = addressIdKey;
			cityTableId = cityIdKey;
			countryTableId = countryIdKey;
			_form1 = form1;


			//get customer name
			string getFname = "select customerName from customer where customerId = " + dbCustid;
			MySqlCommand sqlConvert1 = new MySqlCommand(getFname, DBConnection.conn);
			finalNameForDB = (string)sqlConvert1.ExecuteScalar();
			string[]fullName = finalNameForDB.Split(' '); 
			UpdateCustFirstNameTextInp.Text = fullName[0];
			UpdateCustLastNameTextInp.Text = fullName[1];

			//get customer address
			string getAddress = "select address from address where addressId = " + addressIdKey;
			MySqlCommand sqlConvert2 = new MySqlCommand(getAddress, DBConnection.conn);
			customerAddress = (string)sqlConvert2.ExecuteScalar();
			UpdateCustAddressTextInp.Text = customerAddress;

			//get customer city
			string getCity = "select city from city where cityId = " + cityIdKey;
			MySqlCommand sqlConvert3 = new MySqlCommand(getCity, DBConnection.conn);
			customerCity = (string)sqlConvert3.ExecuteScalar();
			UpdCustCityTextInput.Text = customerCity;

			//get customer country
			string getCountry = "select country from country where countryId = " + countryIdKey;
			MySqlCommand sqlConvert4 = new MySqlCommand(getCountry, DBConnection.conn);
			customerCountry = (string)sqlConvert4.ExecuteScalar();
			UpdCustCountryTextInput.Text = customerCountry;

			//get customer phone
			string getPhoneNumber = "select phone from address where addressId = " + addressIdKey;
			MySqlCommand sqlConvert5 = new MySqlCommand(getPhoneNumber, DBConnection.conn);
			phoneNumber = (string)sqlConvert5.ExecuteScalar();
			UpdCustPhoneTextInput.Text = phoneNumber;
			

		}

		private void UpdateCust_Load(object sender, EventArgs e)
		{
			
		}

		private void UpdateCustFirstNameTextInp_TextChanged(object sender, EventArgs e)
		{

			if(!Regex.IsMatch(UpdateCustFirstNameTextInp.Text, @"^[a-zA-Z\s]+$") && UpdateCustFirstNameTextInp.Text.Length > 0)
			{
				UpdateCustFirstNameTextInp.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            UpdateCustFirstNameTextInp.Text = "";
			}
			else
			{
				UpdateCustFirstNameTextInp.BackColor = (UpdateCustFirstNameTextInp.Text.Length == 0) ? Color.Chocolate : Color.White;
				firstName = UpdateCustFirstNameTextInp.Text;
			}

			//firstName = UpdateCustFirstNameTextInp.Text;
		}

		private void UpdateCustLastNameTextInp_TextChanged(object sender, EventArgs e)
		{

			if(!Regex.IsMatch(UpdateCustLastNameTextInp.Text, @"^[a-zA-Z\s]+$") && UpdateCustLastNameTextInp.Text.Length > 0)
			{
				UpdateCustLastNameTextInp.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            UpdateCustLastNameTextInp.Text = "";
			}
			else
			{
				UpdateCustLastNameTextInp.BackColor = (UpdateCustLastNameTextInp.Text.Length == 0) ? Color.Chocolate : Color.White;
				lastName = UpdateCustLastNameTextInp.Text;
			}

			//lastName = UpdateCustLastNameTextInp.Text;
		}

		private void UpdateCustAddressTextInp_TextChanged(object sender, EventArgs e)
		{	
			UpdateCustAddressTextInp.BackColor = (UpdateCustAddressTextInp.Text.Length == 0) ? Color.Chocolate : Color.White;
			customerAddress = UpdateCustAddressTextInp.Text;
		}

		private void UpdCustCityTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(UpdCustCityTextInput.Text, @"^[a-zA-Z\s]+$") && UpdCustCityTextInput.Text.Length > 0)
			{
				UpdCustCityTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            UpdCustCityTextInput.Text = "";
			}
			else
			{
				UpdCustCityTextInput.BackColor = (UpdCustCityTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				customerCity = UpdCustCityTextInput.Text;
			}

			customerCity = UpdCustCityTextInput.Text;
		}

		private void UpdCustCountryTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(UpdCustCountryTextInput.Text, @"^[a-zA-Z\s]+$") && UpdCustCountryTextInput.Text.Length > 0)
			{
				UpdCustCountryTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            UpdCustCountryTextInput.Text = "";
			}
			else
			{
				UpdCustCountryTextInput.BackColor = (UpdCustCountryTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				customerCountry = UpdCustCountryTextInput.Text;
			}

			customerCountry = UpdCustCountryTextInput.Text;
		}

		private void UpdCustPhoneTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(UpdCustPhoneTextInput.Text, @"^[0-9]+$") && UpdCustPhoneTextInput.Text.Length > 0)
			{
				UpdCustPhoneTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Numbers Only");
				UpdCustPhoneTextInput.Text = "";
			}
			else
			{
				UpdCustPhoneTextInput.BackColor = (UpdCustPhoneTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				phoneNumber = UpdCustPhoneTextInput.Text;
			}

			phoneNumber = UpdCustPhoneTextInput.Text;
		}

		private void UpdateCustSubmitBttn_Click(object sender, EventArgs e)
		{

			if (
				UpdateCustFirstNameTextInp.Text.Length == 0 ||
				UpdateCustLastNameTextInp.Text.Length == 0 ||
				UpdateCustAddressTextInp.Text.Length == 0 ||
				UpdCustCityTextInput.Text.Length == 0 ||
				UpdCustCountryTextInput.Text.Length == 0 ||
				UpdCustPhoneTextInput.Text.Length == 0
			)
			{
				MessageBox.Show("No fields can be left blank");
				return;
			}



			string[] buildMe = {firstName,lastName};
			finalNameForDB = string.Join(" ",buildMe);

			//update finalName
			string updName = "update customer set customerName = '" + finalNameForDB + "' where customerId = " + dbCustIdglobal + ";";
			MySqlCommand updNameCmd = new MySqlCommand(updName, DBConnection.conn);
			updNameCmd.ExecuteNonQuery();

			//update address
			string updAddress = "update address set address = '" + customerAddress + "' where addressId = " + addressTableId + ";";
			MySqlCommand updAddressCmd = new MySqlCommand(updAddress, DBConnection.conn);
			updAddressCmd.ExecuteNonQuery();

			//update city
			string updCity = "update city set city = '" + customerCity + "' where cityId = " + cityTableId + ";";
			MySqlCommand updCityCmd = new MySqlCommand(updCity, DBConnection.conn);
			updCityCmd.ExecuteNonQuery();

			//update country
			string updCountry = "update country set country = '" + customerCountry + "' where countryId = " + countryTableId + ";";
			MySqlCommand updCountryCmd = new MySqlCommand(updCountry, DBConnection.conn);
			updCountryCmd.ExecuteNonQuery();

			//update phone
			string updPhone = "update address set phone = '" + phoneNumber + "' where addressId = " + addressTableId + ";";
			MySqlCommand updPhoneCmd = new MySqlCommand(updPhone, DBConnection.conn);
			updPhoneCmd.ExecuteNonQuery();

			//call updates on all DGV's
			_form1.outerCallToRefresh();

			//close window
			this.Close();


		}

		private void UpdateCustCancelBttn_Click(object sender, EventArgs e)
		{

		}
	}
}
