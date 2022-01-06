using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repositories;

namespace University.Menus
{
    internal class StudentMenu
    {
        public static int StudentEntryMenu()
        {
            Start:
            Console.WriteLine("1: O'quvchini bazaga kiritish");
            Console.WriteLine("2: O'quvchini bazadan o'chirish");
            Console.WriteLine("3: O'quvchini yangilash");
            Console.WriteLine("4: Barcha O'quvchilarni sonini ko'rish");
            Console.WriteLine("5: Barcha O'quvchilarni");
            Console.WriteLine("6: Universal Search");
            Console.WriteLine("7: Dasturdan Chiqish");

            string option = Console.ReadLine().Trim();
            while(option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Noto'g'ri buyruq kiritdingiz.Qaytadan urinib ko'ring");
                Console.ForegroundColor = ConsoleColor.White;
                goto Start;
            }
            

            return int.Parse(option);

        }
    }
}
