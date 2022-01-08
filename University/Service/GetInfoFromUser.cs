using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Extension;
using University.Models;
using University.Repositories;

namespace University.Service
{
    internal class GetInfoFromUser
    {
        public static User GetInfoForSignup()
        {
           

            Console.Clear();
            var users = UserRepository.GetAll();


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


            return user;
        }

        public static bool GetConfirmLogin()
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
    }
}
