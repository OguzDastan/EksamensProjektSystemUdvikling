using System;

namespace WeatherLibrary
{
    public class WeatherData
    {
        public int _id;
        public float _pressure;
        public float _temperature;
        public float _humidity;
        public DateTime Time;

        public WeatherData()
        {
        }

        public WeatherData(int id, float pressure, float temperature, float humidity, DateTime time)
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

        public float Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }

        public float Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public float Humidity
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
