using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            roleChoose();
            Console.ReadLine();
        }  
        static void roleChoose()
        {
            while (true)
            {
                Console.WriteLine("Introduce yourself.");
                string Name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Welcome {0} Select your role. ( 1 for customer, 2 for librarians)", Name);
                char role = Console.ReadKey().KeyChar;
                if (role == '1')
                {
                    Console.Clear();
                    Customer a = new Customer(Name);
                    a.customer_menu();
                    break;
                }
                else if (role == '2')
                {
                    Console.Clear();
                    Librarian b = new Librarian(Name);
                    b.Librarian_menu();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number plz try again.");
                }
            }
        }
    }
 }   
