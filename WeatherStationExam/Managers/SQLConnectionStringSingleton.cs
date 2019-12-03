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
        private const String ConnString = @"Server=tcp:saxildserver.database.windows.net,1433;Initial Catalog=SaxildDB;Persist Security Info=False;User ID=jon270r;Password=Qwerty12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SqlConnection DbConnection => _dbConnection;
    }
}
