using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUC969Project.Database;
using System.Globalization;

namespace WGUC969Project {
public partial class Login : Form {
	
	MySqlDataReader reader;
	string usrInptName, usrInputPwd;
	static string QUERY1 = "select userName, password, userId from user"; // reader[0] reader[1] reader[2]
	MySqlCommand cmd_1 = new MySqlCommand(QUERY1, DBConnection.conn);
	public int userId;
	
	public Login() {
		InitializeComponent();
		reader = cmd_1.ExecuteReader();
		
		if(RegionInfo.CurrentRegion.DisplayName == "Mexico"){
			label1.Text = "Nombre de usuario";
			label2.Text = "Contrasena";
		}

	}

	//username textbox
	private void textBox1_TextChanged(object sender, EventArgs e) {
		usrInptName = textBox1.Text;
	}

	//password textbox
	private void textBox2_TextChanged(object sender, EventArgs e) {
		usrInputPwd = textBox2.Text;
	}
		
	//submit button click event
	private void button1_Click(object sender, EventArgs e) {
		//confirm readers operation
		//A reader must be closed before using another reader
		if (reader.Read()) {}
		if (usrInptName.Trim() != reader.GetValue(0).ToString() || usrInputPwd.Trim() != reader.GetValue(1).ToString()) {
			if (RegionInfo.CurrentRegion.DisplayName == "Mexico") {
				MessageBox.Show("Nombre de usuario o contraseña incorrecta");
			} else {
				MessageBox.Show("UserName or Password is incorrect");
			}
		} else {
			userId = (int)reader.GetValue(2);
			if (RegionInfo.CurrentRegion.DisplayName == "Mexico") {
				//MessageBox.Show("Credenciales verificadas:  True\nRegión actual:  " + RegionInfo.CurrentRegion.ToString());
			} else {
				//MessageBox.Show("Credentials Verified:  True\nCurrent Region:  " + RegionInfo.CurrentRegion.ToString());
			}
			reader.Close();

			Form1 instance = new Form1(userId);
			instance.Show();
			this.Hide();
		}
	}
}









}
