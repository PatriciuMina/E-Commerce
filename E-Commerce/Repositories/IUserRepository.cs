using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_commerce
{
    interface IUserRepository
    {
        IEnumerable<IdentityUser> GetUsers();
        IdentityUser GetUser(int id);
        IdentityUser AddUser(IdentityUser user);
        void DeleteUser(int id);
        bool UpdateUser(IdentityUser user);
    }
}
