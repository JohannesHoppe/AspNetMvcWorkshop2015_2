using System.Linq;

namespace CustomerManager.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            return _dataContext.Customers.Find(id);
        }

        public IQueryable<Customer> GetCustomers()
        {
            // OData - bugfix to support counting, (which is not supported by Effort!)
            return _dataContext.Customers.ToList().AsQueryable();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _dataContext.Customers.Find(customer.Id);
            if (existingCustomer == null) { return; }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Mail = customer.Mail;
            _dataContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            Customer existingCustomer = _dataContext.Customers.Find(id);
            if (existingCustomer == null) { return; }

            _dataContext.Customers.Remove(existingCustomer);
            _dataContext.SaveChanges();
        }
    }
}