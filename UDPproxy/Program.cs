using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using WeatherLibrary;

namespace UDPproxy
{
    class Program
    {
        public static bool isRunning = false;
        public static int listeningSocket = 6969;



        static void Main(string[] args)
        {
            Console.WriteLine("UDP Proxy says hello!");
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, listeningSocket);

            while (true)
            {
                byte[] receiveBytes = client.Receive(ref endPoint);
                var receiveStream = new MemoryStream(receiveBytes);
                //string returnData = Encoding.ASCII.GetString(receiveBytes);
                WeatherData rData = new WeatherData();
                IFormatter formatter = new BinaryFormatter();

                rData = (formatter.Deserialize(receiveStream) as WeatherData);
                Console.WriteLine(rData.ToString());
            }

        }

    }
}
