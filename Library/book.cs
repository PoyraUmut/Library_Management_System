using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Library
{
    
    internal class book
    {
        string special_password = "28";

        protected string get_password
        {
            get { return special_password;}               
        }
        SqlConnection connect = new SqlConnection("Data Source=SAYNUR\\SQLEXPRESS01;Initial Catalog=Library;Integrated Security=True");

        protected void show()
        {
            connect.Open();
            SqlCommand command = new SqlCommand("Select *From Book", connect);
            SqlDataReader reader = command.ExecuteReader();              
            while (reader.Read())
            {
                Console.Write(reader["id"]);                
                Console.Write(reader["book"]);               
                Console.Write(reader["writer"]);                
                Console.WriteLine();                
            }           
            connect.Close();
        }

        protected void book_borrow(char x)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("Delete From Book Where id = (" + x + ")", connect);//borrowing book.
            command.ExecuteNonQuery();
            connect.Close();
            Console.Clear();           
            Console.WriteLine("Your transaction has been completed successfully.");
            Console.WriteLine("The remaining books are below.");
            show();
        }

        protected void book_lend(string id, string book_name, string book_writer)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("Insert into Book (id,book,writer) values ('" +id+"','"+book_name+"','"+book_writer+"')",connect);
            command.ExecuteNonQuery();
            connect.Close();
            Console.WriteLine("Your transaction has been completed successfully.");
        }

        protected void book_update()
        {
            show();
            Console.WriteLine("Enter the id of the book you want to change the id of.");
            string id = Console.ReadLine(); 
            Console.WriteLine("\nEnter the new id.");
            string update_id = Console.ReadLine();
            Console.WriteLine("Enter the new book name.");
            string update_book_name = Console.ReadLine();
            Console.WriteLine("Enter the new writer name.");
            string update_writer = Console.ReadLine();

            connect.Open();
            SqlCommand command = new SqlCommand("Update Book set id = '" + update_id + "',book='" + update_book_name +
                "',writer='" + update_writer + "'where id ="+id+"", connect);
            command.ExecuteNonQuery();
            connect.Close();
            Console.Clear();
            Console.WriteLine("Your transaction has been completed successfully.");
            Console.WriteLine("You can see the updated book list below.");
            show();
        }

        protected void ban_customer()
        {
            connect.Open();
            Console.WriteLine("Enter the name of you want to ban customer.");
            string banned_customer = Console.ReadLine();
            SqlCommand command = new SqlCommand("Insert into Ban (name) values ('" + banned_customer + "')", connect);
            command.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("Your transaction has been completed successfully.");
            Console.WriteLine("You can see the banned customer list below.");
            SqlCommand cmd = new SqlCommand("Select *From Ban", connect);
            SqlDataReader reader = cmd.ExecuteReader();           
            while (reader.Read())
            {
                Console.WriteLine(reader["name"]);             
                Console.WriteLine();
            }
            connect.Close();
        }

        protected bool check_ban_list(string nickname)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("Select *From Ban", connect);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;           
            string[] Ban_list = new string[20];          
            while (reader.Read())
            {
                Ban_list[i] = reader["name"].ToString();
                Console.WriteLine(Ban_list[i]);
                if (nickname == Ban_list[i])
                {
                    return false;
                }                
                i++;
            }
            connect.Close();
            return true;                                                      
        }
        protected void password_checking()
        {
            while (true)
            {
                Console.WriteLine("Enter the special password.");
                string password_check = Console.ReadLine();
                if (password_check == special_password)
                {
                    Console.Clear();                    
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong password. Plz try again.");
                }
            }
        }
    }
    
}
