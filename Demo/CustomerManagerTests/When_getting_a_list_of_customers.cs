using System.Data.Common;
using System.Linq;
using CustomerManager.Models;
using FluentAssertions;
using Machine.Specifications;

namespace CustomerManagerTests
{
    public class SetupDb
    {
        public static CustomerRepository repository;

        public static Establish SetupDatabase(int amountOfCustomer = 2)
        {
            return () =>
            {
                DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
                DataContext context = new DataContext(connection);

                for (int i = 1; i < amountOfCustomer + 1; i++)
                {
                    context.Customers.Add(new Customer { FirstName = "Test" + i });
                }
                context.SaveChanges();

                repository = new CustomerRepository(context);
            };
        } 
    }

    [Subject(typeof(CustomerRepository))]
    public class When_getting_a_list_of_customers : SetupDb
    {
        static IQueryable<Customer> result;

        Establish context = SetupDatabase(amountOfCustomer: 2);
        Because of = () => result = repository.GetCustomers();
        It should_return_all_customers = () => result.Should().HaveCount(2);
    }

    [Subject(typeof(CustomerRepository))]
    public class When_getting_one_customer : SetupDb
    {
        static Customer result;

        Establish context = SetupDatabase(3);
        Because of = () => result = repository.GetCustomer(3);

        It should_return_the_customer_with_the_same_id = () => result.Id.Should().Be(3);
        It should_return_a_customer_with_the_expected_name = () => result.FirstName.Should().Be("Test3");
    }
}
