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
        [Route("api/Contact")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        [Route("api/Contact/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        //GET: api/Contact?name={name}
        [Route("api/Contact/{name}")]
        [HttpGet]
        public IEnumerable<Contact> FindContactByName(string name) //If the method name starts different from Get, specify HttpGet
        {
            Contact[] contactArray = contacts.Where<Contact>(c => c.FirstName.Contains(name)).ToArray<Contact>();
            return contactArray;
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
        public IEnumerable<Contact> Put(int id, [FromBody]Contact changedContact)
        {
            Contact contactInDb = contacts.FirstOrDefault(c => c.Id == id);
            int index = Array.IndexOf(contacts, contactInDb);

            if (contactInDb != null)
            {
                contactInDb.FirstName = changedContact.FirstName;
                contactInDb.LastName = changedContact.LastName;
            }

            return contacts;
        }

        // DELETE: api/Contact/5
        public IEnumerable<Contact> Delete(int id)
        {
            contacts = contacts.Where<Contact>(i => i.Id != id).ToArray<Contact>();
            return contacts;
        }
    }
}
