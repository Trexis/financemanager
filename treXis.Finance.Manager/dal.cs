using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trexis.Finance.Manager
{
    class Dal
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        public Dal()
        {
            Config config = new Config();
            this.server = config.GetSetting("server");
            this.database = config.GetSetting("database");
            this.username = config.GetSetting("username");
            this.password = config.GetSetting("password");
            Initialize();
        }

        public Dal(String server, String database, String username, String password)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
            Initialize();
        }

        public HashSet<Hashtable> executeAsHashset(String query)
        {
            HashSet<Hashtable> list = new HashSet<Hashtable>();
            
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Hashtable record = new Hashtable();
                        for (int index = 0; index < dataReader.FieldCount; index++)
                        {
                            record.Add(dataReader.GetName(index), dataReader[index]);
                        }
                        list.Add(record);
                    }
                }

                dataReader.Close();
                this.CloseConnection();
            }
            return list;
        }

        public void executeNonQuery(String query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + this.server + ";" + "DATABASE=" +
            this.database + ";" + "UID=" + this.username + ";" + "PASSWORD=" + this.password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                if(ex.Number.Equals(1045)){
                        throw new Exception("Invalid username/password, please try again", ex);
                } else {
                        throw new Exception("Cannot connect to server.  Contact administrator", ex);                        
                }
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //fail silent //MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
