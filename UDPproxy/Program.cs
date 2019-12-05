using System;
using System.Net.Sockets;


namespace UDPproxy
{
    class Program
    {
        public static bool isRunning = false;
        public static int listeningSocket = 6969;



        static void Main(string[] args)
        {
            Console.WriteLine("UDP Proxy says hello!");
            Start();

            while (isRunning)
            {
                //here we listen
            }

        }


        static void Start()
        {
            UdpClient client = new UdpClient();
            

            isRunning = true;
        }

    }
}
