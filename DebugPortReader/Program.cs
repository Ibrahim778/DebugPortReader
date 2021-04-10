using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DebugPortReader
{
    class Program
    {
        static int port = 8080;

        static void Main(string[] args)
        {
            Console.WriteLine("Setting port to: " + port);
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                string gotString = sr.ReadLine();
                while(gotString != null)
                {
                    Console.WriteLine(gotString);
                    gotString = sr.ReadLine();
                }
                sr.Close();
                sr.Dispose();
                client.Close();
                client.Dispose();
            }
            listener.Stop();
        }
    }
}
