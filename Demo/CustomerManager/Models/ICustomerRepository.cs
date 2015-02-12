using System.Linq;

namespace CustomerManager.Models
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomer(int id);
        IQueryable<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}