using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Service;

namespace University.Models
{
    internal class Student
    {
        public string Id { get; set; }  = MethodService.generateID();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Course { get; set; }
        
        public string PhoneNum { get; set; }

        public string Email { get; set; }
    }
}
