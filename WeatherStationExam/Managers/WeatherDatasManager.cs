using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WeatherLibrary;


namespace WeatherStationExam.Managers
{
    public class WeatherDatasManager
    {
        private const string GET_ALL = "SELECT * FROM WeatherData";
        private const string GET_ONE = "SELECT * FROM WeatherData WHERE Id = @WeatherId";
        private const string INSERT = "INSERT INTO WeatherData values (@DataId, @Pressure, @Temperature, @Humidity, @Time)";

        public List<WeatherData> Get()
        {
            List<WeatherData> weatherdata = new List<WeatherData>();

            using (SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    weatherdata.Add(new WeatherData()
                    {
                        Id = reader.GetInt32(0),
                        Pressure = reader.GetInt32(1),
                        Temperature = reader.GetInt32(2),
                        Humidity = reader.GetInt32(3),
                        Time = reader.GetDateTime(4)

                    });
                }
                return weatherdata;
            }
        }

        public WeatherData Get(int WeatherId)
        {
            //create empty activity object
            WeatherData a = null;

            //query database 
            using (SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection))
            {
                //binding of relevent DB parameters
                cmd.Parameters.AddWithValue("@WeatherID", WeatherId);

                //Reader to handle the result
                SqlDataReader reader = cmd.ExecuteReader();

                //while there's a result
                while (reader.Read())
                {
                    a = new WeatherData()
                    {
                        Id = reader.GetInt32(0),
                        Pressure = reader.GetInt32(1),
                        Temperature = reader.GetInt32(2),
                        Humidity = reader.GetInt32(3),
                        Time = reader.GetDateTime(4)
                    };
                }
                //the IO stream of data, coming from database is closed
                reader.Close();
            }
            //Return the activity from database, or "null" if no user what Activity = ActivityID
            return a;
        }

        public bool Post(WeatherData wd)
        {
            using (SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection))
            {
                cmd.Parameters.AddWithValue("@DataId", wd.Id);
                cmd.Parameters.AddWithValue("@Pressure", wd.Pressure);
                cmd.Parameters.AddWithValue("@Temperature", wd.Temperature);
                cmd.Parameters.AddWithValue("@Humdity", wd.Humidity);
                cmd.Parameters.AddWithValue("@Time", wd.Time);

                int RowsAffected = cmd.ExecuteNonQuery();

                return RowsAffected == 1;
            }
        }

    }
}
