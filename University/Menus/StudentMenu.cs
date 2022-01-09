using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Repositories;
using University.Service;

namespace University.Menus
{
    internal class StudentMenu
    {
        public static void StudentEntryMenu()
        {

            Start:
            Console.WriteLine("1: O'quvchini bazaga kiritish");
            Console.WriteLine("2: O'quvchini bazadan o'chirish");
            Console.WriteLine("3: O'quvchini yangilash");
            Console.WriteLine("4: Barcha O'quvchilarni sonini ko'rish");
            Console.WriteLine("5: Barcha O'quvchilar");
            Console.WriteLine("6: Universal Search");
            Console.WriteLine("7: Dasturdan Chiqish");

            ConsoleKeyInfo option = Console.ReadKey();
            while(option.KeyChar != '1' && option.KeyChar != '2' && option.KeyChar != '3' && option.KeyChar != '4' && option.KeyChar != '5' && option.KeyChar != '6' && option.KeyChar != '7')
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Noto'g'ri buyruq kiritdingiz.Qaytadan urinib ko'ring");
                Console.ForegroundColor = ConsoleColor.White;
                goto Start;
            }
            
            StudentRepository studentRepository = new StudentRepository();
            if(option.KeyChar == '1')
            {
                studentRepository.CreateStudent(GetInfoFromUser.GetInfoOfStudent());
            }
            else if (option.KeyChar == '2')
            {
                Console.Clear();
                Console.Write("PhoneNumber : \n>>> ");
                studentRepository.DeleteStudent(Console.ReadLine().Trim());
            }
            else if (option.KeyChar == '3')
            {
                Console.Clear();
                Console.Write("PhoneNumber : \n>>> ");
                studentRepository.UpdateStudent(Console.ReadLine().Trim());
            }
            else if (option.KeyChar == '4')
            {
                Console.Clear();
                
                studentRepository.GetCountOfStudents();
            }
            else if (option.KeyChar == '5')
            {
                Console.Clear();
                studentRepository.GetAllStudentsList();
            }
            else if (option.KeyChar == '6')
            {
                Console.Clear();
                studentRepository.OptimalSearch();
            }
            else 
            {
                Console.Clear();
                
            }
        }
    }
}
