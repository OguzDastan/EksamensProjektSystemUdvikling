using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStationExam.Managers
{
    public class SQLConnectionSingleton
    {
        private static SQLConnectionSingleton _instance = new SQLConnectionSingleton();

        public static SQLConnectionSingleton Instance => _instance;

        private SQLConnectionSingleton()
        {
            _dbConnection = new SqlConnection(ConnString);
            _dbConnection.Open();
        }

        private SqlConnection _dbConnection;
        private const String ConnString = @"Server=tcp:oguzserverdb.database.windows.net,1433;Initial Catalog=MyServerDB;Persist Security Info=False;User ID=oguz0040;Password=Dastan12;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SqlConnection DbConnection => _dbConnection;
    }
}
