using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private ArvinContext db;
        public CustomerRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<Customer> AllCustomers()
        {
            return db.customers;
        }

        public string CreateCustomer(string Title, string PhoneNumber, string Logo)
        {
            try
            {
                Customer customer = new Customer();
                customer.Title = Title;
                customer.PhoneNumber = PhoneNumber;
                customer.Logo = Logo;
                db.customers.Add(customer);
                Save();
                return "true";
            }
            catch (Exception ex)
            {

                return "Erorr :" + ex.Message;
            }
        }

        public Customer CustomerById(int ID)
        {
            return db.customers.Find(ID);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public string EditCustomer(int ID, string Title, string PhoneNumber, string Logo)
        {
            try
            {
                Customer customer = CustomerById(ID);
                if (Logo == "")
                {
                    customer.Title = Title;
                    customer.PhoneNumber = PhoneNumber;
                    Save();
                    return "true";
                }
                else
                {
                    customer.Title = Title;
                    customer.PhoneNumber = PhoneNumber;
                    customer.Logo = Logo;
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string RemoveCustomer(int ID)
        {
            db.customers.Remove(CustomerById(ID));
            Save();
            return "true";
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
