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
        public const int listeningSocket = 6969;



        static void Main(string[] args)
        {
            Console.WriteLine("UDP Proxy says hello!");
            UdpClient client = new UdpClient(listeningSocket);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            /*
            while (true)
            {
                byte[] bytes = client.Receive(ref endPoint);
                string str = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("Modtaget " + str);
                string upperStr = str.ToUpper();
                byte[] buffer = Encoding.UTF8.GetBytes(upperStr.ToCharArray(), 0,
                    upperStr.Length);

                client.Send(buffer, buffer.Length, endPoint);

            }
            */

            
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
