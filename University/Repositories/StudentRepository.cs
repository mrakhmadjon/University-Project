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

         


        public void DeleteStudent(string phoneNum)
        {
            
            var students = GetAllstudents();
            bool isStudentDeleted = false;
            foreach (Student student in students)
            {
                if (student.PhoneNum == phoneNum)
                { students.Remove(student); 
                    WriteAllStudents(students);
                    isStudentDeleted = true;
                }
            }

            if (isStudentDeleted)
            {
                Console.Clear();
                Console.WriteLine("\t\tStudent Bazadan o'chirildi...");
                StudentMenu.StudentEntryMenu();
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Bazada bunday student yo'q");
                Console.ForegroundColor = ConsoleColor.White;
                StudentMenu.StudentEntryMenu();

            }
        }



        public void UpdateStudent(string phoneNum)
        {
            
            bool isStudentUpdated = false;
            var existStudents = GetAllstudents();
            foreach (Student student in existStudents)
            {
                if (student.PhoneNum.Equals(phoneNum))
                {
                    existStudents.Remove(student);
                    
                    WriteAllStudents(existStudents);
                    CreateStudent(GetInfoFromUser.GetInfoOfStudent());
                    isStudentUpdated = true;
                }
            }
            if (!isStudentUpdated)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bazada bunday student yo'q");
                Console.ForegroundColor = ConsoleColor.White;
                StudentMenu.StudentEntryMenu();
            }
        }

        /// <summary>
        /// This returns the count of the students 
        /// </summary>
        /// <returns></returns>
        public void GetCountOfStudents()
        {
            IList<Student> allStudents = GetAllstudents();
            if (allStudents.Count > 0)
            {
                Console.Clear();

                Console.WriteLine("\t\tBazada {0} ta o'quvchi bor\n", GetAllstudents().Count());
                StudentMenu.StudentEntryMenu();

            }
            else
            {
                Console.Clear();

                Console.WriteLine("\t\tBazada birorta ham o'quvchi yo'q\n");
                StudentMenu.StudentEntryMenu();
            }
        }
        
        public void GetAllStudentsList()
        {
            IList<Student> allStudents = GetAllstudents();
            if (allStudents.Count > 0)
            {
                IEnumerable sortedStudents = allStudents.OrderBy(student => student.FirstName).ThenBy(x => x.PhoneNum);

                Console.Clear();
                Console.WriteLine("\tBazadagi o'quvchilar \n");
                foreach (Student student in sortedStudents)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Id : {student.Id} FirstName : {student.FirstName} LastName : {student.LastName} Age : {student.Age} Email : {student.Email} PhoneNumber : {student.PhoneNum}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                StudentMenu.StudentEntryMenu();

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tBazada O'quvchilar malumotlari mavjud emas");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                StudentMenu.StudentEntryMenu();

            }
        }

         

        public void OptimalSearch()
        {
            Console.WriteLine("Qidirmoqchi bo'lgan student parametrini kiriting : ");
            string optimalSearch = Console.ReadLine().Trim();
            var searchStudents = GetAllstudents();

            IList<Student> seachedStudents = searchStudents.Where(student =>  student.FirstName.Contains(optimalSearch) || student.FirstName.Contains(optimalSearch.Cap()) || student.LastName.Contains(optimalSearch) || student.LastName.Contains(optimalSearch.Cap())).ToList() ;
            

            if (seachedStudents.ToList().Count != 0)
            {
                Console.Clear();
                foreach (Student student in seachedStudents)
                {

                    Console.WriteLine("\t\tSiz kiritgan Parameter boyicha o'quvchi yoki o'quvchilar ro'yxati\n");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Id : {student.Id} FirstName : {student.FirstName} LastName : {student.LastName} Age : {student.Age} Email : {student.Email} PhoneNumber : {student.PhoneNum}");
                    Console.ForegroundColor = ConsoleColor.White;
                    StudentMenu.StudentEntryMenu();

                }
                Console.WriteLine();
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tSiz kiritgan Parameter boyicha o'quvchi yo'q\n\n");
                Console.ForegroundColor = ConsoleColor.White;

                StudentMenu.StudentEntryMenu();
            }
        }


        



    }
}
