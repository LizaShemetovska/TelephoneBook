using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TelephoneBook.Models;

namespace TelephoneBook.Controllers
{
    [RoutePrefix("Api/People")]
    public class PeopleController : ApiController
    {
        /// <summary>
        /// API CRUD controller forPerson
        /// </summary>
        private PhoneContext db = new PhoneContext();

        // GET: api/People
        /// <summary>
        /// Get info about all Person in DB
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("ReadAllPeopleInfo")]
        public IQueryable<Person> GetPeople()
        {
            return db.People;
        }

        // GET: api/People/5
        /// <summary>
        ///  Get Person by known Id
        /// </summary>
        /// <param name="id">  Person Id to find</param>
        /// <returns></returns>
        /// 
        [ResponseType(typeof(Person))]
        [HttpGet]
       
        [Route("ReadPeopleById/{id}")]
        public IHttpActionResult GetPerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        /// <summary>
        /// Put info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdatePeople/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        /// <summary>
        /// Post info
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePeople")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete]
        [Route("DeletePeopleById/{id}")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.People.Count(e => e.Id == id) > 0;
        }
    }
}