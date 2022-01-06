using Newtonsoft.Json;
using System;
using University.Extension;
using University.Menus;
using University.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace University
{
    internal class Program 
    {
       
        static void Main(string[] args)
        {
            
        Start:
            int EntryMenu = MainEntryMenu.RoleMenu();
            bool isLogged = false;

            UserRepository userRepo = new UserRepository();
            int studentmenu=0;

            if (EntryMenu == 1)
            {  userRepo.Signup();
               studentmenu = StudentMenu.StudentEntryMenu();
            }
            else
            {
                isLogged = userRepo.Login();
                if (!isLogged)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t   Invalid login or Password\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    goto Start;
                }
                else
                {                    
                    studentmenu = StudentMenu.StudentEntryMenu();
                }
            }

        Student_menu:
        
            // Taking An object From StudentRepository.It include Function such as create delete etc

            StudentRepository studentRepository = new StudentRepository();
            if (studentmenu == 1)
            {
                Console.Clear();
                var newStudent = studentRepository.CreateStudent();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{newStudent.FirstName} bazaga qo'shildii\n");
                Console.ForegroundColor = ConsoleColor.White;
                studentmenu = StudentMenu.StudentEntryMenu();
                goto Student_menu;
            }
            else if (studentmenu == 2)
            { bool isdeleted = studentRepository.DeleteStudent(); 
                if (isdeleted)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O'quvchi bazadan o'chirildi \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();
                    goto Student_menu;
                }
            }
            else if(studentmenu == 3)
            {
                bool isUpdated = studentRepository.UpdateStudent();
                if (isUpdated)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O'quvchi Muvaffaqiyatli Yangilandi");
                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
                else
                {
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bunday o'quvchi bazada yo'q yoki siz notog'ri tasdiqlash kiritdingiz!!!");

                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }

            }
            else if(studentmenu==4)
            {
                int studentCount = studentRepository.GetCountOfStudents();
                if (studentCount > 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\tBazada {studentCount} ta o'quvchi bor\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
                else
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bazada birorta ham  o'quvchi yo'q");
                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
                }
            else if (studentmenu == 5)
            {
                bool printedAllStudents = studentRepository.GetAllStudentsList();
                if (printedAllStudents)
                {
                    Console.WriteLine();
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
                else
                {
                    Console.WriteLine("Bazada Oq'uvchilar yo'q");
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
            }
            else if (studentmenu == 6)
            {
                bool isStudentSearchWorked = studentRepository.OptimalSearch();
                if (isStudentSearchWorked)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tSiz Qidirgan parameter bo'yicha o'quvchi yoki o'quvchilar ");

                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bazada bunday parameterdagi o'quvchi yo'q...");
                    Console.ForegroundColor = ConsoleColor.White;
                    studentmenu = StudentMenu.StudentEntryMenu();

                    goto Student_menu;
                }
            }
            else if (studentmenu == 7)
            {
                Console.WriteLine("\tXIZMATIMIZDAN FOYDALANGANINGIZDAN MAMNINMIZ!!!");
                Environment.Exit(0);
            }




            /*
            string word = "SALOM";
            Console.WriteLine(word.Cap());

            Console.WriteLine(word.ArrToString());
            */
        }


    }
}
