using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerManager.Models;

namespace CustomerManager.Controllers
{
    //public class CustomersController : ODataController
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _customerRep;

        public CustomersController(ICustomerRepository customerRep)
        {
            _customerRep = customerRep;
        }

        //[EnableQuery]
        public IQueryable<Customer> GetCustomers()
        {
            return _customerRep.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _customerRep.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customer.Id == 0)
            {
                return BadRequest();
            }

            _customerRep.UpdateCustomer(customer);

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            _customerRep.CreateCustomer(customer);
            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            _customerRep.DeleteCustomer(id);
            return StatusCode(HttpStatusCode.OK);
        }
    }
}