using System;

namespace WeatherLibrary
{
    [Serializable]
    public class WeatherData
    {
        private int _id;
        private decimal _pressure;
        private decimal _temperature;
        private decimal _humidity;
        private DateTime time;

        public WeatherData()
        {
        }
        /*
        public WeatherData(int id, decimal pressure, decimal temperature, decimal humidity, DateTime time)
        {
            _id = id;
            _pressure = pressure;
            _temperature = temperature;
            _humidity = humidity;
            Time = time;
        }
        */
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public decimal Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }

        public decimal Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public decimal Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }

        public DateTime Time
        {
            get => time;
            set => time = value;
        }

        public override string ToString()
        {
            return Id + " " + Pressure + " " + Temperature + " " + Humidity +
                   " " + Time;
        }
    }
}
