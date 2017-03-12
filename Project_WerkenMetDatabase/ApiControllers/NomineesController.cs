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
using Project_WerkenMetDatabase.Models;

namespace Project_WerkenMetDatabase.ApiControllers
{
    public class NomineesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Nominees
        public IQueryable<Nominee> GetNominees()
        {
            return db.Nominees;
        }

        // GET: api/Nominees/5
        [ResponseType(typeof(Nominee))]
        public IHttpActionResult GetNominee(int id)
        {
            Nominee nominee = db.Nominees.Find(id);
            if (nominee == null)
            {
                return NotFound();
            }

            return Ok(nominee);
        }

        // PUT: api/Nominees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNominee(int id, Nominee nominee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nominee.Id)
            {
                return BadRequest();
            }

            db.Entry(nominee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomineeExists(id))
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

        // POST: api/Nominees
        [ResponseType(typeof(Nominee))]
        public IHttpActionResult PostNominee(Nominee nominee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nominees.Add(nominee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nominee.Id }, nominee);
        }

        // DELETE: api/Nominees/5
        [ResponseType(typeof(Nominee))]
        public IHttpActionResult DeleteNominee(int id)
        {
            Nominee nominee = db.Nominees.Find(id);
            if (nominee == null)
            {
                return NotFound();
            }

            db.Nominees.Remove(nominee);
            db.SaveChanges();

            return Ok(nominee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NomineeExists(int id)
        {
            return db.Nominees.Count(e => e.Id == id) > 0;
        }
    }
}