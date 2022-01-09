using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.IRepositories
{
    internal interface IStudentRepository
    {
      Student CreateStudent(Student student);
      void DeleteStudent(string phonenum);
      
      void UpdateStudent(string phoneNum);
      
      void GetCountOfStudents();
        
      void GetAllStudentsList();
         
      void OptimalSearch();
        
    }
}
