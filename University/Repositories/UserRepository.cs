using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Extension;
using University.IRepositories;
using University.Models;
using University.Service;

namespace University.Repositories
{
    public class UserRepository : IUserRepository
    {
       
        public bool Login()
        {
            Console.Clear();
            bool isLogged = false;
            Console.WriteLine("Login : ");
            string login = Console.ReadLine().Trim();

            Console.WriteLine("Password : ");
            string password = MethodService.HidePass();
            password = password.HashingCode();

            isLogged = MethodService.IsLoginExist(login, password);

            return isLogged;
            
        }

        public User Signup()
        {
            Console.Clear();
            var users = GetAll();
           

            User user = new User();
            Console.WriteLine("FirstName : ");
            user.FirstName = Console.ReadLine().Trim().Cap();

            Console.WriteLine("LastName : ");
            user.LastName = Console.ReadLine().Trim().Cap();

            Console.WriteLine("Login : ");
            user.Login = Console.ReadLine().Trim();

            Start:
            Console.WriteLine("Password : ");
            string password = MethodService.HidePass();

            user.Password = password.HashingCode();

            foreach (User userr in users)
            {
                
                if (userr.Password == user.Password)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bu Password invalid. Boshqa password kiriting ");
                    Console.ForegroundColor = ConsoleColor.White;

                    goto Start;
                }
            }

            users.Add(user);
            var serializedUsers = JsonConvert.SerializeObject(users);
            File.WriteAllText(Constants.UserDbPath, serializedUsers);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully Created the Account !");
            Console.ForegroundColor = ConsoleColor.White;
            
            return user;
        }

        public static IList<User> GetAll()
        {
            string json = File.ReadAllText(Constants.UserDbPath);
            return JsonConvert.DeserializeObject<IList<User>>(json);

        }
    }
}
