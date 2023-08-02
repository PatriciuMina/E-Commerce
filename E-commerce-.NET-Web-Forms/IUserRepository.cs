using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_commerce
{
    interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User AddUser(User user);
        void DeleteUser(int id);
        bool UpdateUser(User user);
    }
}
