using System.Web.Http;
using System.Web.Http.Results;
using CustomerManager.Controllers;
using CustomerManager.Models;
using FluentAssertions;
using Machine.Specifications;
using NSubstitute;

namespace CustomerManagerTests
{
    [Subject(typeof(CustomersController))]
    public class When_requesting_an_existing_customer
    {
        static CustomersController controller;
        static IHttpActionResult result; 

        Establish context = () =>
            {
                ICustomerRepository repository = Substitute.For<ICustomerRepository>();
                repository.GetCustomer(Arg.Any<int>()).Returns(new Customer());
                controller = new CustomersController(repository);
            };

        Because of = () => result = controller.GetCustomer(-1);

        It should_respond_with_status_code_ok =
            () => result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
    }
}
                