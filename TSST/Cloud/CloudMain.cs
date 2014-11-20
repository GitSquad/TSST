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
        private static Connection connection;
        
        

        static void Main(string[] args)
        {
            Console.WriteLine("Chmura odpalona");
            startServer();
            
        }

        private static void startServer()
        {
            Console.WriteLine("Starting the server...");

            connection = new Connection();
            connection.Connect();

            
           
   
            Console.Read();
            
           
        }

       
    }
}
