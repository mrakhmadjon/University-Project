using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Models;

namespace University.IRepositories
{
    public interface IUserRepository
    {
        User Signup (User user);

        void Login (bool isLogged);

         
    }
}
