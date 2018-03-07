using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Display to the console, all the passwords that are "hello"
            var helloPassword = from user in users
                                where (user.Password == "hello")
                                select user;

            Console.WriteLine("Following are the names of the user with hello password:");
            foreach (var element in helloPassword)
            {
                Console.WriteLine($" {element.Name}");
            }


            //Delete any passwords that are the lower-cased version of their Name. 
            users.RemoveAll(r => r.Password == r.Name.ToLower());

            //Delete the first User that has the password "hello"
            var firstUserWithHelloPassword = users.First(t => t.Password == "hello");

            users.Remove(firstUserWithHelloPassword);

            //Display to the console the remaining users with their Name and Password
            Console.WriteLine();
            Console.WriteLine("Following are the users left in the list:");
            foreach (var ele in users)
            {
                Console.Write($" {ele.Name} {ele.Password}");
            }
            Console.WriteLine();


        }
    }
}
