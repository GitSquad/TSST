using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cloud
{
    class Connection
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private static IPAddress host = IPAddress.Loopback;
        private static int port = 25000;
        private static BinaryWriter bw = null;
        private static BinaryReader br = null;
        private static List<TcpClient> clients = new List<TcpClient>();
        private static NetworkStream stream;
        public Connection()
        {
           
        }

        public void Connect()
        {
            tcpListener = new TcpListener(host, port);
            tcpListener.Start();
            Console.WriteLine("Server is ON");
            while (true)
            {
                /*
                while (!tcpListener.Pending())
                {
                    
                    if (!ifConnect)
                    {
                        if (client != null) client.Close();
                        listener.Stop();
                        return;
                    }
                }*/

                Console.WriteLine("tutaj");

                tcpClient = tcpListener.AcceptTcpClient();
                if (tcpClient.Connected == true)
                    Console.WriteLine("polaczono");
                else
                    Console.WriteLine("nie polaczono");
                clients.Add(tcpClient);
                Thread thread = new Thread(delegate()
                {
                    handleClient(tcpClient);
                });
                thread.Start();
            }
        }

        private void handleClient(TcpClient tcpClient)
        {
            
            stream = tcpClient.GetStream();
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            stream.Read(buffer, 0, (int)tcpClient.ReceiveBufferSize);

            // Returns the data received from the host to the console.
            string message = Encoding.UTF8.GetString(buffer);
            Console.WriteLine("Odebralem " + message);

            //send(message);
        }

        private void send(byte[] message)
        {
            
           
        }

    }
}
