using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplicationWithWebApiService.Models;

namespace WebApplicationWithWebApiService.Controllers
{
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[]
        {
            new Contact { Id = 1, FirstName = "Peter", LastName = "Parker" },
            new Contact { Id = 2, FirstName = "Bruce", LastName = "Wayne" },
            new Contact { Id = 3, FirstName = "Bruce", LastName = "Banne" },
        };

        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
