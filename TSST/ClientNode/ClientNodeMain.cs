using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientNode
{
    class ClientNodeMain
    {
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
                Boolean q = true;
                Console.WriteLine("Wezeł kliencki odpalony!");
                Connect();
                while(q)
                {
                
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("1. Przeslij wiadomość");
                Console.WriteLine("2. Pokaz odebrane wiadomości");
                Console.WriteLine("3. Wyjdź z programu");

                int choice;
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {

                            Console.WriteLine("Podaj wiadomość do przesłania");
                            String message = Console.ReadLine();
                            Console.WriteLine(message);
                            byte[] data = Encoding.ASCII.GetBytes(message);
                            clientSocket.Send(data);
                            Console.WriteLine("Wyslano: " + message);


                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {

                            clientSocket.Close();
                            q = false;
                            break;
                        }
                }
                }
                Console.WriteLine("Koniec");
            Console.Read();
        }

        private static void Connect()
        {
            try
            {
                clientSocket.Connect(IPAddress.Loopback, 1020);
            }
            catch
            {

            }
            Console.WriteLine("Connected");
        }
    }
}
