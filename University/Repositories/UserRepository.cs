using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Extension;
using University.IRepositories;
using University.Menus;
using University.Models;
using University.Service;

namespace University.Repositories
{
    public class UserRepository : IUserRepository
    {
       
        public void Login(bool isLogged)
        {
            if (!isLogged)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t   Invalid login or Password\n");
                Console.ForegroundColor = ConsoleColor.White;
                MainEntryMenu.RoleMenu();

            }
            else
            {
                StudentMenu.StudentEntryMenu();
            }

        }

        public User Signup(User user)
        {
            Console.Clear();
            var users = GetAll();
           
            
            users.Add(user);
            var serializedUsers = JsonConvert.SerializeObject(users);
            File.WriteAllText(Constants.UserDbPath, serializedUsers);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully Created the Account !");
            Console.ForegroundColor = ConsoleColor.White;
            StudentMenu.StudentEntryMenu();

            return user;
        }

        

        public static IList<User> GetAll()
        {
            string json = File.ReadAllText(Constants.UserDbPath);
            return JsonConvert.DeserializeObject<IList<User>>(json);

        }
    }
}
