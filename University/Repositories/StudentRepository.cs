using Newtonsoft.Json;
using System;
using System.Collections;
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
    internal class StudentRepository : IStudentRepository
    {
        public static IList<Student> GetAllstudents()
        {
            string json = File.ReadAllText(Constants.StudentDbPath);
            return JsonConvert.DeserializeObject<IList<Student>>(json);

        }


        public void WriteAllStudents(IList<Student> students)
        {
            string jsonStudents = JsonConvert.SerializeObject(students);
            File.WriteAllText(Constants.StudentDbPath, jsonStudents);
        }

        public Student CreateStudent(Student student)
        {
            
            var students = GetAllstudents();
            
            students.Add(student);


            WriteAllStudents(students);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student Bazaga Muvaffaqiyatli Qo'shildi");
            Console.ForegroundColor = ConsoleColor.White;
            StudentMenu.StudentEntryMenu();
            return new Student();
        }

         


        public bool DeleteStudent()
        {
            
            var students = GetAllstudents();
            Console.WriteLine("PhoneNumber : ");
            string phonenum = Console.ReadLine().Trim();

                      
             
            foreach (Student student in students)
            {
                if (student.PhoneNum == phonenum)
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

            
            var existStudents = GetAllstudents();
            foreach (Student student in existStudents)
            {
                if (student.PhoneNum.Equals(phone))
                {
                    
                    existStudents.Remove(student);
                    
                    WriteAllStudents(existStudents);
                    CreateStudent(GetInfoFromUser.GetInfoOfStudent());

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

         

        public bool OptimalSearch()
        {
            Console.WriteLine("Qidirmoqchi bo'lgan student parametrini kiriting : ");
            string optimalSearch = Console.ReadLine().Trim();
            var searchStudents = GetAllstudents();

            IList<Student> seachedStudents = searchStudents.Where(student => student.Email.Equals(searchStudents) || student.FirstName.Equals(optimalSearch)
            || student.LastName.Contains(optimalSearch) || student.Age.ToString().Equals(optimalSearch) || student.PhoneNum.Equals(optimalSearch)
            || student.Course.ToString().Equals(optimalSearch)).ToList();

            if (seachedStudents.ToList().Count != 0)
            {
                Console.Clear();
                foreach (Student student in seachedStudents)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Id : {student.Id} FirstName : {student.FirstName} LastName : {student.LastName} Age : {student.Age} Email : {student.Email} PhoneNumber : {student.PhoneNum}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                return true;
            }
            return false;
        }


        



    }
}
