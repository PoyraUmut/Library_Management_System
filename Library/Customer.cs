using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Customer : book 
    {       
        public Customer(string Name)
        {
            Login customer1 = new Login(Name);
        }
        public void customer_menu()
        {
            while (true)
            {               
                Console.WriteLine("Select the action you want to do (1 for borrow, 2 for lend)");
                char customer_choice = Console.ReadKey().KeyChar;
                if (customer_choice == '1')
                {
                    Console.Clear();
                    borrow();
                    break;
                }
                else if (customer_choice == '2')
                {
                    Console.Clear();
                    lend();
                    break;
                }               
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalıd number plz try again.");
                }
            }
        }
        void borrow()
        {           
            show();
            Console.WriteLine("Enter the id which you want to borrow.");
            char choice = Console.ReadKey().KeyChar;
            book_borrow(choice);
        }
        void lend()
        {           
            Console.WriteLine("Enter the id of your book.");
            string id = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the name of your book.");
            string book_name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter the writer of you book.");
            string book_writer = Console.ReadLine();
            Console.Clear();
            book_lend(id,book_name,book_writer);
        }
    }
}
    


 
