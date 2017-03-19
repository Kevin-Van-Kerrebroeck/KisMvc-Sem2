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
using Project_WerkenMetDatabase.Models.DataTransferObjects;

namespace Project_WerkenMetDatabase.ApiControllers
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categories
        [Route("api/Categories")]
        public IEnumerable<Category> GetCategories()
        {
            var data = db.Categories.ToList();
            return data;
        }

        // GET: api/CategoriesWithNominees
        [Route("api/CategoriesWithNominees")]
        public IEnumerable<CategoryDTO> GetCategoriesWithNominees()
        {
            var data = db.Categories.Select(c => new CategoryDTO()
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                NomineeDTOs = c.Nominees.Select(n => new NomineeDTO()
                {
                    Id = n.Id,
                    OscarYear = n.OscarYear,
                    CategoryId = n.CategoryId,
                    Winner = n.Winner,
                    NomineeName = n.NomineeName,
                    FromTheMovie = n.FromTheMovie
                }).ToList()
            });
            return data;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}