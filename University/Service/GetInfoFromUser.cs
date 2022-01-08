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

        public static Student GetInfoOfStudent()
        {
            Console.Clear();
            Console.WriteLine("O'quvchi MAlumotlarni Kiriting ");
            var students = StudentRepository.GetAllstudents();
            Student student = new Student();

            Console.WriteLine("FirstName : ");
            student.FirstName = Console.ReadLine().Trim().Cap();

            Console.WriteLine("LastName : ");
            student.LastName = Console.ReadLine().Trim().Cap();

        AgeGoto:
            Console.WriteLine("Age : ");
            string age = Console.ReadLine().Trim();

            if (MethodService.IsNumeric(age) && age.Length != 0)
            {

                student.Age = int.Parse(age);

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Age ni to'gri formatda kiriting ...");
                Console.ForegroundColor = ConsoleColor.White;
                goto AgeGoto;
            }
            Console.WriteLine("Course : ");
            student.Course = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Email : ");
            student.Email = Console.ReadLine().Trim();

        Start:
            Console.WriteLine("Phone Number : ");
            student.PhoneNum = Console.ReadLine().Trim();


            

            foreach (Student studentt in students)
            {
                if (studentt.PhoneNum == student.PhoneNum)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Siz kiritgan Telefon nomer band qilingan boshqa telefon kiriting !");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Start;


                }
            }

            return student;
        }















    }
}
