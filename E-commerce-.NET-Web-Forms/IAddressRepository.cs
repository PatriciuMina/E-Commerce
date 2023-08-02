using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_commerce
{
    interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddress(int id);
        Address AddAddress(Address address);
        void DeleteAddress(int id);
        bool UpdateAddress(Address address);
    }
}
