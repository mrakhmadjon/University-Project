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
      bool DeleteStudent();
      
      bool UpdateStudent();
      
      int GetCountOfStudents();
        
      bool GetAllStudentsList();
         
      bool OptimalSearch();
        
    }
}
