using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StudentsEnrollmentsDemo.Models;

namespace StudentsEnrollmentsDemo.Controllers
{
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsController : ApiController
    {
        private StudentsEnrollmentsDemoContext db = new StudentsEnrollmentsDemoContext();

        [HttpGet]
        [Route("get-enrollment")]
        public async Task<IHttpActionResult> GetEnrollment(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        [HttpGet]
        [Route("all-enrollments")]
        public async Task<IHttpActionResult> GetAllEnrollments()
        {
            List<Enrollment> lst = await db.Enrollments.ToListAsync();

            return Json(lst);
        }

        [HttpPost]
        [Route("update-enrollment")]
        public async Task<IHttpActionResult> UpdateEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(enrollment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.EnrollmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        [HttpPost]
        [Route("add-enrollment")]
        public async Task<IHttpActionResult> AddEnrollment(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();

            return Ok(enrollment);
        }

        [HttpGet]
        [Route("delete-enrollment")]
        public async Task<IHttpActionResult> DeleteEnrollment(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            db.Enrollments.Remove(enrollment);
            await db.SaveChangesAsync();

            return Ok(enrollment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(int id)
        {
            return db.Enrollments.Count(e => e.EnrollmentID == id) > 0;
        }
    }
}