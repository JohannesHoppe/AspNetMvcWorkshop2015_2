using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using AutoPoco;
using AutoPoco.DataSources;
using AutoPoco.Engine;
using CustomerManager.Models;

namespace CustomerManager.Controllers
{
    // Fehlende Nuget Pakete:  
    // PM> Install-Package AutoPocoBeta
    // PM> Install-Package AutoPoco.DataSources
    public class ResetController : ApiController
    {
        private readonly DataContext db;

        public ResetController(DataContext db)
        {
            this.db = db;
        }

        public HttpResponseMessage Get()
        {
            var demoData = GenerateDemoCustomers();

            db.Customers.RemoveRange(db.Customers.Select(c => c));
            db.Customers.AddRange(demoData);

            db.SaveChanges();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
                           {
                               Content = new StringContent("Demo Data was resetted!")
                           };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }

        private static IEnumerable<Customer> GenerateDemoCustomers()
        {
            IGenerationSessionFactory factory = AutoPocoContainer.Configure(x =>
            {
                x.Conventions(c => c.UseDefaultConventions());
                x.AddFromAssemblyContainingType<Customer>();

                Random rnd = new Random();

                x.Include<Customer>()
                    .Setup(c => c.FirstName).Use<FirstNameSource>()
                    .Setup(c => c.LastName).Use<LastNameSource>()
                    .Setup(c => c.Mail).Use<EmailAddressSource>()
                    //.Setup(c => c.DateOfBirth).Use<DateOfBirthSource>()
                    //.Setup(c => c.AmountOfOrders).Use<IntegerSource>(1, 100)
                    //.Setup(c => c.AmountOfInvoices).Use<SecondIntegerSource>(1, 100)
                    ;
            });

            IGenerationSession session = factory.CreateSession();
            return session.List<Customer>(100).Get();
        }


        public class SecondIntegerSource : DatasourceBase<int>
        {
            private readonly int _min;
            private readonly int _max;
            private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

            public SecondIntegerSource()
            {
                _min = int.MinValue;
                _max = int.MaxValue;
            }

            public SecondIntegerSource(int min, int max)
            {
                _min = min;
                _max = max;
            }

            public override int Next(IGenerationContext context)
            {
                return _random.Next(_min, _max);
            }
        }
    }
}
