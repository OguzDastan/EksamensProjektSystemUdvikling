using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherLibrary;

namespace UDPproxy
{
    class Program
    {
        public static bool isRunning = false;
        public const int listeningSocket = 6969;
        private const string URI = "https://voresvejrstation.azurewebsites.net/api/WeatherDatas";

        static void Main(string[] args)
        {
            Console.WriteLine("UDP Proxy says hello!");
            UdpClient client = new UdpClient(listeningSocket);
            Console.WriteLine();
            Console.WriteLine("Server started...");
            Console.WriteLine();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Endpoint established...");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                byte[] receiveBytes = client.Receive(ref endPoint);
                string str = Encoding.UTF8.GetString(receiveBytes);
                Console.WriteLine("Recieved bytes...");
                Console.WriteLine(str);


                using (HttpClient httpClient = new HttpClient())
                {

                    StringContent jsonStr = new StringContent(JsonConvert.SerializeObject(new WeatherData()
                    {
                        Humidity = Convert.ToDecimal(str.Substring(0, 4)),
                        Pressure = Convert.ToDecimal(str.Substring(4, 4)),
                        Temperature = Convert.ToDecimal(str.Substring(5, 4)),
                        Time = DateTime.Now
                    }), Encoding.UTF8, "application/json");

                    Console.WriteLine("Serialized string to JSON");
                    Console.WriteLine();

                    Task<HttpResponseMessage> response = httpClient.PostAsync(URI, jsonStr);
                    Console.WriteLine("Object sent to REST");
                    Console.WriteLine();

                    HttpResponseMessage resp = response.Result;
                    String jsonResStr = resp.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("Task done...");
                }

            }
        }

    }
}
