using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WGUC969Project.Database
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }
        public static void startConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);

                //Open the connection
                conn.Open();

				//Use for trouble shooting connection to DB
                //MessageBox.Show("Connection is open");
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void closeConnection() 
        {
            try 
            {
                //close the connection
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
