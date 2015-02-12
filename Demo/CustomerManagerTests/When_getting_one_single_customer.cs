using System.Web.Http;
using System.Web.Http.Results;
using CustomerManager.Models;
using FluentAssertions;
using Machine.Specifications;

namespace CustomerManagerTests
{
    [Subject(typeof (CustomersController))]
    public class When_getting_one_single_customer
    {
        static CustomersController controller;
        static IHttpActionResult result;

        Establish context = () =>  {

            var context = new DataContext( Effort.DbConnectionFactory.CreateTransient());
            context.Customers.AddRange(new[] {
                new Customer {FirstName = "Test1"},
                new Customer {FirstName = "Test2"}
            });
            context.SaveChanges();

            controller = new CustomersController(context);
        };

        Because of = () => result = controller.GetCustomer(1);

        It should_return_the_correct_customer = () => 
            ((OkNegotiatedContentResult<Customer>)result).Content.Id.Should().Be(1);

    }
}
