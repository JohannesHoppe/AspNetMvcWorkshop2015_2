using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CustomerManager.Models;
using FluentAssertions;
using Machine.Specifications;
using NSubstitute;

namespace CustomerManagerTests
{
    [Subject(typeof (CustomersController))]
    public class When_calling_customers_controller
    {
        static CustomersController controller;
        static IQueryable<Customer> result;

        Establish context = () =>  {
            
            var data = new List<Customer> 
            { 
                new Customer { FirstName = "Test1" }, 
                new Customer { FirstName = "Test2" } 
            }.AsQueryable();
            
            var mockSet = Substitute.For<IDbSet<Customer>, DbSet<Customer>>();
            mockSet.Provider.Returns(data.Provider);
            mockSet.Expression.Returns(data.Expression);
            mockSet.ElementType.Returns(data.ElementType);
            mockSet.GetEnumerator().Returns(data.GetEnumerator());

            var mockContext = Substitute.For<DataContext>();
            mockContext.Customers.Returns(mockSet);

            controller = new CustomersController(mockContext);
        };

        Because of = () => result = controller.GetCustomers();

        It should_return_all_customers_without_any_filtering = () => result.Count().Should().Be(2);

    }
}
