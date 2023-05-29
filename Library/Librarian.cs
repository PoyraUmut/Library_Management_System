using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Librarian : book
    {        
        public Librarian(string Name)
        {
            Login librarian1 = new Login(Name);
        }
        public void Librarian_menu()
        {
            while (true)
            {
                Console.WriteLine("Select the action you want to do (1 for update the books, 2 for add a name to banlist).");
                char choice = Console.ReadKey().KeyChar;
                if(choice == '1')
                {
                    Console.Clear();
                    Console.WriteLine("Your special password: {0}",get_password);
                    update();
                    break;
                }
                else if(choice == '2')
                {
                    Console.Clear();
                    Console.WriteLine("Your special password: {0}", get_password);
                    ban_customer();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number plz try again.");
                }
            }
        }

        void update()
        {
            password_checking();
            book_update();
        }
        void ban()
        {
            password_checking();

        }
    }
}
