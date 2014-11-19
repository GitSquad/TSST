using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cloud
{
    class CloudMain
    {
        static byte[] Buffer = new byte[1024];

        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.WriteLine("Chmura odpalona");
            startServer();
            
        }

        private static void startServer()
        {
            Console.WriteLine("Starting the server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 1020));
            serverSocket.Listen(100);
            //serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

            Socket accepted = serverSocket.Accept();
            Console.WriteLine("Server is ON");
            accepted.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), accepted);
            
            
            
            //serverSocket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), accepted);
            
           
   
            Console.Read();
            
           
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            Console.WriteLine("Server is ON");
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] data = new byte[received];
            Array.Copy(Buffer, data, received);
            String strData = Encoding.ASCII.GetString(data);
            
            Console.WriteLine("Otrzymalem: " + strData);
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }
    }
}
