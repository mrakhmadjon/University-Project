using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;
using University.Repositories;

namespace University.Service
{
    public class MethodService
    {
        #region GetUserPath
        /// <summary>
        /// GetUserPath returns a path of file under the name of Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string GetUserPath(Guid Id)
        {
            return Path.Combine(Constants.UserDbPath, Id.ToString() + ".txt");

        }

        #endregion

        #region HidePassword
        /// <summary>
        /// This Method Will Hide the Typed Password so it will be seen by the user
        /// </summary>
        /// <returns></returns>
        public static string HidePass()
        {
            var password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return password;
        }
        #endregion

        #region Random Unique Id
        /// <summary>
        /// Generating Random unique Id
        /// </summary>
        /// <returns></returns>
        public static string generateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }
        #endregion


        #region Checking the string whether it is numeric or not
        /// <summary>
        /// Checks if the string is numeric
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        #endregion

        
        #region IsUserLoginExist
        /// <summary>
        /// This Method Checks whether With this kind of login is already exists
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsLoginExist(string login,  string password)
        {
            bool isLogged = false;

            var users = UserRepository.GetAll();

            foreach (User user in users)
            {

                if (user.Login == login && user.Password == password)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tYou Are Logged in");
                    isLogged = true;
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            return isLogged;
        }
        #endregion
         

    }
}
