using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICustomerRepository:IDisposable
    {
        IEnumerable<Customer> AllCustomers();

        Customer CustomerById(int ID);

        string CreateCustomer(string Title, string PhoneNumber, string Logo);

        string EditCustomer(int ID, string Title, string PhoneNumber, string Logo);

        string RemoveCustomer(int ID);

        void Save();
    }
}
