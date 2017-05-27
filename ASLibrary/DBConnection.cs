using System;
using MySql.Data.MySqlClient;

namespace ASLibrary
{
    class DBConnection //singleton
    {
        //DataBase Connection
        private MySqlConnection Connection { get; set; }

        //DataBase Instance (hishenq singleton-@)
        private static DBConnection _instance;

        //DataBase Instance Getter
        public static DBConnection Instance
        {
            //If _instance is null initialize it
            get
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }
        }

        //Constructor (no need to call) 
        private DBConnection()
        {
        }

        //If has connection return it else create it
        public bool IsConnect()
        {
            if(Connection == null)
            {
                if (String.IsNullOrEmpty(Config.DBHost) || String.IsNullOrEmpty(Config.DBName))
                    return false;
                string connectionstring = string.Format("Server={0}; database={1}; UID={2}; password={3}; charset=utf8;", Config.DBHost, Config.DBName, Config.DBUsername, Config.DBPassword);
                Connection = new MySqlConnection(connectionstring);
                Connection.Open();
            }
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
