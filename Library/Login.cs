using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Login : book
    {        
        string Nick_name;         //default nickname
        string Password = "123";  //default password 

        public string name
        {
            get { return Nick_name; }
            set { Nick_name = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public Login(string Name)
        {
            while (true)
            {
                Console.WriteLine("Hello {0}. 1 for sign in 2 for sign up.",Name);
                this.Nick_name = Name;// setting new default nickname
                char choice = Console.ReadKey().KeyChar;
                if (choice == '1')
                {
                    Console.Clear();
                    sign_in();
                    break;
                }
                else if (choice == '2')
                {
                    Console.Clear();
                    sign_up();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number plz try again.");
                }
            }
             void sign_in()
            {
                while (true)
                {
                    Console.WriteLine("Enter your nickname");
                    string nick_name = Console.ReadLine();
                    Console.WriteLine("Enter you password");
                    string password = Console.ReadLine();                                      
                    if (nick_name == Nick_name && password == Password && check_ban_list(nick_name) == true) 
                    {
                        Console.Clear();
                        Console.WriteLine("You are sending the menu..");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid user information. plz try again.");
                    }
                }
            }
             void sign_up()
            {
                while (true)
                {

                    Console.WriteLine("Enrer your nickname.");
                    string new_nickname = Console.ReadLine();
                    Console.WriteLine("Enter your password.");
                    string new_password = Console.ReadLine();
                    Console.WriteLine("Enter you password again.");
                    string new_password_check = Console.ReadLine();
                    if (new_password == new_password_check)
                    {
                        Console.Clear();
                        Nick_name = new_nickname;
                        Password = new_password;
                        Console.WriteLine("You are sending to sign in menu..");
                        sign_in();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Your password is not same with password check. Plz try again.");
                    }
                }
            }
        }
    }
}
