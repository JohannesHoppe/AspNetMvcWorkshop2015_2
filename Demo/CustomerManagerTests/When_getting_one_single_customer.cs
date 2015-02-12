using CustomerManager.Models;
using FluentAssertions;
using Machine.Specifications;

namespace CustomerManagerTests
{
    [Subject(typeof (CustomerRepository))]
    public class When_getting_one_single_customer
    {
        static CustomerRepository controller;
        static Customer result;

        Establish context = () =>  {

            var context = new DataContext( Effort.DbConnectionFactory.CreateTransient());
            context.Customers.AddRange(new[] {
                new Customer {FirstName = "Test1"},
                new Customer {FirstName = "Test2"}
            });
            context.SaveChanges();

            controller = new CustomerRepository(context);
        };

        Because of = () => result = controller.GetCustomer(1);

        It should_return_the_correct_customer = () => result.Id.Should().Be(1);
    }
}
