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
using WGUC969Project;

namespace WGUC969Project
{
	public partial class AddCust : Form
	{

		//insert into customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
		//value('auto guyTwo',3,1,'2019-01-01 00:00:00','Supertest','2019-01-01 00:00:00','test');
		
		public string firstName;
		public string lastName;
		public string customerAddress;
		public string customerCity;
		public string customerCountry;
		public string finalNameForDB;
		public string addCustStr;
		public string phoneNumber;
					
		//id's should be returned for each of the following commands
				//add country command
				public string addCountryCmd;
				public int countryTableId;
				//add city command
				public string addCityCmd;
				public int cityTableId;
				//add address command
				public string addAddressCmd;
				public int addressTableId;

		DateTime utcConverted = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
		DateTime localTime = TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now);
		private Form1 _form1;

		public AddCust()
		{
			InitializeComponent();
		}

		public AddCust(Form1 form1){
			InitializeComponent();
			_form1 = form1; //excellent lesson in creating an instance elsewere and passing it in c#
		}

		private void AddCustNameTextInput1_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddCustNameTextInput1.Text, @"^[a-zA-Z\s]+$") && AddCustNameTextInput1.Text.Length > 0)
			{
				AddCustNameTextInput1.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            AddCustNameTextInput1.Text = "";
			}
			else
			{
				AddCustNameTextInput1.BackColor = (AddCustNameTextInput1.Text.Length == 0) ? Color.Chocolate : Color.White;
				firstName = AddCustNameTextInput1.Text;
			}
		}

		private void AddCustNameTextInput2_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddCustNameTextInput2.Text, @"^[a-zA-Z\s]+$") && AddCustNameTextInput2.Text.Length > 0)
			{
				AddCustNameTextInput2.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            AddCustNameTextInput2.Text = "";
			}
			else
			{
				AddCustNameTextInput2.BackColor = (AddCustNameTextInput2.Text.Length == 0) ? Color.Chocolate : Color.White;
				lastName = AddCustNameTextInput2.Text;
			}
		}

		private void AddCustAddressTextInput_TextChanged(object sender, EventArgs e)
		{
			AddCustAddressTextInput.BackColor = (AddCustAddressTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
			customerAddress = AddCustAddressTextInput.Text;		
		}

		private void AddCustCityTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddCustCityTextInput.Text, @"^[a-zA-Z\s]+$") && AddCustCityTextInput.Text.Length > 0)
			{
				AddCustCityTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            AddCustCityTextInput.Text = "";
			}
			else
			{
				AddCustCityTextInput.BackColor = (AddCustCityTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				customerCity = AddCustCityTextInput.Text;
			}
		}

		private void AddCustCountryTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddCustCountryTextInput.Text, @"^[a-zA-Z\s]+$") && AddCustCountryTextInput.Text.Length > 0)
			{
				AddCustCountryTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Letters Only");
	            AddCustCountryTextInput.Text = "";
			}
			else
			{
				AddCustCountryTextInput.BackColor = (AddCustCountryTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				customerCountry = AddCustCountryTextInput.Text;
			}
		}


		private void AddCustPhoneTextInput_TextChanged(object sender, EventArgs e)
		{
			if(!Regex.IsMatch(AddCustPhoneTextInput.Text, @"^[0-9]+$") && AddCustPhoneTextInput.Text.Length > 0)
			{
				AddCustPhoneTextInput.BackColor = Color.Chocolate;
				MessageBox.Show("Numbers Only");
				AddCustPhoneTextInput.Text = "";
			}
			else
			{
				AddCustPhoneTextInput.BackColor = (AddCustPhoneTextInput.Text.Length == 0) ? Color.Chocolate : Color.White;
				phoneNumber = AddCustPhoneTextInput.Text;
			}
		}


		private void AddCustSubmitButton_Click(object sender, EventArgs e)
		{

			if (
				AddCustNameTextInput1.Text.Length == 0 ||
				AddCustNameTextInput2.Text.Length == 0 ||
				AddCustAddressTextInput.Text.Length == 0 ||
				AddCustCityTextInput.Text.Length == 0 ||
				AddCustCountryTextInput.Text.Length == 0 ||
				AddCustPhoneTextInput.Text.Length == 0
			)
			{
				MessageBox.Show("No fields can be left blank");
				return;
			} else
			{
				
			//insert into country (country, createDate, createdBy, lastUpdateBy) value ('zubia', '2019-12-12 00:00:00', 'test', 'test');
			string[] buildMe = {firstName,lastName};
			finalNameForDB = string.Join(" ", buildMe);

			//MessageBox.Show(customerCountry);
			//multi table insert
				//country insert
				addCountryCmd = "insert into country (country, createDate, createdBy, lastUpdateBy) value ('"+ customerCountry +"', '2019-12-12 00:00:00', 'test', 'test');";
				MySqlCommand addCountrySqlCmd = new MySqlCommand(addCountryCmd, DBConnection.conn);
				addCountrySqlCmd.ExecuteNonQuery();
					//get id of country that was just inserted
					string findID = "select MAX(countryId) from country;";
					MySqlCommand getMaxId = new MySqlCommand(findID, DBConnection.conn);
					countryTableId = (Int32)getMaxId.ExecuteScalar();
					//MessageBox.Show("new countryID = " + countryTableId);

				//city insert
				addCityCmd = "insert into city(city,countryId,createDate,createdBy,lastUpdateBy) value ('"+ customerCity +"','"+ countryTableId +"','2019-12-12 00:00:00','test','test');";
				MySqlCommand addCitySqlCmd = new MySqlCommand(addCityCmd, DBConnection.conn);
				addCitySqlCmd.ExecuteNonQuery();
					//get id of city that was just inserted
					string findID2 = "select MAX(cityId) from city";
					MySqlCommand getMaxId2 = new MySqlCommand(findID2, DBConnection.conn);
					cityTableId = (Int32)getMaxId2.ExecuteScalar();
					//MessageBox.Show("new cityID = " + cityTableId);

				//address insert
				addAddressCmd = "insert into address(address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdateBy) value ('"+ customerAddress +"','NAadd2','"+ cityTableId +"','NApostal','"+ phoneNumber +"','2019-12-12 00:00:00','test','test');";
				MySqlCommand addAddressSqlCmd = new MySqlCommand(addAddressCmd, DBConnection.conn);
				addAddressSqlCmd.ExecuteNonQuery();
					//get id of address that was just inserted
					string findID3 = "select MAX(addressId) from address";
					MySqlCommand getMaxId3 = new MySqlCommand(findID3, DBConnection.conn);
					addressTableId = (Int32)getMaxId3.ExecuteScalar();	
					MessageBox.Show("new addressId = " + addressTableId);

				//customer insert
				//submit name to customer DB with city and country and address ID's based on above
				addCustStr = "insert into customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) value ('"+ finalNameForDB +"', "+ addressTableId +",1, '2019-12-12 00:00:00','test','test' ); ";
				MySqlCommand cmd_1 = new MySqlCommand(addCustStr, DBConnection.conn);
				cmd_1.ExecuteNonQuery();

			//must pass an instance of form1 for use
			_form1.outerCallToRefresh();

			//close this object form			
			this.Close();
			} //end if statement that checks for blank fields
		}

		private void AddCustCancelButton_Click(object sender, EventArgs e)
		{
			//clear all data
			this.Close();
		}


	}
}
