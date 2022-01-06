using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }


        public override string ToString()
        {
            return $"{Id}\n{FirstName}\n{LastName}\n{Login}\n{Password}";
        }


    }
}
