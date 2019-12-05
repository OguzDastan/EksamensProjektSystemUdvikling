using System;

namespace WeatherLibrary
{
    public class WeatherData
    {
        public int _id;
        public decimal _pressure;
        public decimal _temperature;
        public decimal _humidity;
        public DateTime Time;

        public WeatherData()
        {
        }

        public WeatherData(int id, decimal pressure, decimal temperature, decimal humidity, DateTime time)
        {
            _id = id;
            _pressure = pressure;
            _temperature = temperature;
            _humidity = humidity;
            Time = time;
        }

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

        public DateTime Time1
        {
            get => Time;
            set => Time = value;
        }
    }
}
