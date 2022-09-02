using Newtonsoft.Json.Linq;
using System;
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
            new Contact { Id = 3, FirstName = "Bruce", LastName = "Banner" },
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
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> contactList = contacts.ToList<Contact>();
            newContact.Id = contactList.Count() + 1;
            contactList.Add(newContact);
            contacts = contactList.ToArray();

            return contacts;
        }

        // PUT: api/Contact/5
        public IHttpActionResult Put(int id, [FromBody]Contact value)
        {
            Contact contactInDb = contacts.FirstOrDefault(c => c.Id == id);
            int index = Array.IndexOf(contacts, contactInDb);

            if (contactInDb == null)
            {
                return NotFound();
            }

            contactInDb.FirstName = value.FirstName;
            contactInDb.LastName = value.LastName;

            contacts[index] = contactInDb;

            return Ok(contacts);
        }

        // DELETE: api/Contact/5
        public IHttpActionResult Delete(int id)
        {
            Contact contactInDb = contacts.FirstOrDefault(c => c.Id == id);

            if (contactInDb == null)
            {
                return NotFound();
            }

            contacts = contacts.Where(i => i.Id != id).ToArray();

            return Ok(contacts);
        }
    }
}
