using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientNode
{
    class ClientNodeMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wezeł kliencki odpalony!");
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1. Przeslij wiadomość");
            Console.WriteLine("2. Pokaz odebrane wiadomości");
            Console.WriteLine("3. Wyjdź z programu");

            int choice;
            choice = int.Parse(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                    {
                        Console.WriteLine("Podaj wiadomość do przesłania");
                        Console.ReadLine();

                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }

            }

        }
    }
}
