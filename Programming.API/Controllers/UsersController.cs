using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Programming.API.Controllers
{
    public class UsersController : ApiController
    {
        private PersonelEntities1 db = new PersonelEntities1();


        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        [ResponseType(typeof(Users))]

        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [ResponseType(typeof(void))]


        public IHttpActionResult PutUsers(int id,Users users)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != users.Userid)
            {
                return BadRequest();
            }
            db.Entry(users).State = EntityState.Modified;

            try 
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(System.Net.HttpStatusCode.NoContent);

        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Userid }, users);
        }


        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if(users == null)
            {
                return NotFound();
            }
            db.Users.Remove(users);
            db.SaveChanges();
            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Userid == id) > 0;
        }

    }
}