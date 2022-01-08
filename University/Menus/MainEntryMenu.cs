using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repositories;
using University.Service;

namespace University.Menus
{
    internal  class MainEntryMenu
    {
        public static void RoleMenu()
        {
            UserRepository userRepo = new UserRepository();

        Start:
            Console.WriteLine("\t1 Sign Up\t\t2 Sign In");
            ConsoleKeyInfo role = Console.ReadKey();

            while(role.KeyChar != '1' && role.KeyChar != '2')
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   No'to'ri buyruq kiritildi. Qaytadan kiriting .\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto Start;
            }

            if (role.KeyChar == '1')
                userRepo.Signup(GetInfoFromUser.GetInfoForSignup());
            else
            {
                userRepo.Login(GetInfoFromUser.GetConfirmLogin());
            }
                
                
                
        }
    }
}
