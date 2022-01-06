using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repositories;

namespace University.Menus
{
    public  class MainEntryMenu
    {
        public static int RoleMenu()
        {
            Start:
            Console.WriteLine("\t1 Sign Up\t\t2 Sign In");
            string role = Console.ReadLine().Trim();

            while(role != "1" && role != "2")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   No'to'ri buyruq kiritildi. Qaytadan kiriting .\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto Start;
            }
            
            if (role == "1")
                return 1;
            else
                return 2;


        }
    }
}
