﻿using Newtonsoft.Json;
using System;
using System.Collections;
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
    internal class StudentRepository : IStudentRepository
    {
        public IList<Student> GetAllstudents()
        {
            string json = File.ReadAllText(Constants.StudentDbPath);
            return JsonConvert.DeserializeObject<IList<Student>>(json);

        }


        public void WriteAllStudents(IList<Student> students)
        {
            string jsonStudents = JsonConvert.SerializeObject(students);
            File.WriteAllText(Constants.StudentDbPath, jsonStudents);
        }
        public Student CreateStudent()
        {
            Console.Clear();
            Console.WriteLine("O'quvchi MAlumotlarni Kiriting ");
            var students = GetAllstudents();
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

            Start:
            Console.WriteLine("Phone Number : ");
            student.PhoneNum = Console.ReadLine().Trim();

            Console.WriteLine("Email : ");
            student.Email = Console.ReadLine().Trim();

            foreach (Student studentt in students)
            {
                if (studentt.PhoneNum == student.PhoneNum || studentt.Email == student.Email)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Siz kiritgan Telefon yoki Email band qilingan boshqa telefon yoki email kiriting !");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Start;


                }
            }
            students.Add(student);


            WriteAllStudents(students);

            return new Student();
        }

         


        public bool DeleteStudent()
        {
            
            var students = GetAllstudents();
            Console.WriteLine("PhoneNumber : ");
            string phonenum = Console.ReadLine().Trim();



            Console.WriteLine("Email : ");
            string email = Console.ReadLine().Trim();


             
            foreach (Student student in students)
            {
                if (student.PhoneNum == phonenum && student.Email == email)
                { students.Remove(student); 
                    WriteAllStudents(students);
                    return  true;
                }
            }
             
            return false;
        }



        public bool UpdateStudent()
        {
            Console.Clear();
            Console.WriteLine("\tTasdiqlash uchun Telefon nomeringizni va Emailingizni Kiriting \n");
            Console.WriteLine("PhoneNum : ");
            string phone = Console.ReadLine().Trim();

            Console.WriteLine("Email : ");
            string email = Console.ReadLine().Trim();
            var existStudents = GetAllstudents();
            foreach (Student student in existStudents)
            {
                if (student.PhoneNum.Equals(phone) && student.Email.Equals(email))
                {
                    CreateStudent();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This returns the count of the students 
        /// </summary>
        /// <returns></returns>
        public int GetCountOfStudents()
        {
            GetAllstudents();
            return GetAllstudents().Count();
        }
        
        public bool GetAllStudentsList()
        {
            var allStudents = GetAllstudents();

            IEnumerable sortedStudents = allStudents.OrderBy(student => student.FirstName).ThenBy(x => x.PhoneNum);

            if (sortedStudents.ToString().Length != 0)
            {
                Console.Clear();
                Console.WriteLine("\tBazadagi o'quvchilar \n");
                foreach (Student student in sortedStudents)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Id : {student.Id} FirstName : {student.FirstName} LastName : {student.LastName} Age : {student.Age} Email : {student.Email} PhoneNumber : {student.PhoneNum}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                return true;
            }
            return false ;
        }

         

        public void OptimalSearch()
        {
            Console.WriteLine("Qidirmoqchi bo'lgan student parametrini kiriting : ");
            string optimalSearch = Console.ReadLine().Trim();
            var searchStudents = GetAllstudents();

           IList<Student> seachedStudents =  searchStudents.Where(student => student.Email.Equals(searchStudents) || student.FirstName.Equals(optimalSearch)
            || student.LastName.Equals(optimalSearch) || student.Age.ToString().Equals(optimalSearch) || student.PhoneNum.Equals(optimalSearch)
            || student.Course.ToString().Equals(optimalSearch)).ToList();

            if (seachedStudents.ToString().Length != 0)
            {
                Console.Clear();
                Console.WriteLine("\tSiz Qidirgan parameter bo'yicha o'quvchi yoki o'quvchilar ");
                foreach (Student student in seachedStudents)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Id : {student.Id} FirstName : {student.FirstName} LastName : {student.LastName} Age : {student.Age} Email : {student.Email} PhoneNumber : {student.PhoneNum}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        



    }
}
