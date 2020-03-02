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
using AutoMapper;
using StudentsEnrollmentsDemo.Models;
using StudentsEnrollmentsDemo.Models.DTOs;

namespace StudentsEnrollmentsDemo.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private StudentsEnrollmentsDemoContext db = new StudentsEnrollmentsDemoContext();

        [HttpGet]
        [Route("get-student")]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student student = await db.Students.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<StudentDto>(student));
        }

        [HttpGet]
        [Route("all-students")]
        public async Task<IHttpActionResult> GetAllStudents()
        {
            List<Student> lst = await db.Students.Include(s => s.Enrollments).ToListAsync();

            return Json(Mapper.Map<List<StudentDto>>(lst));
        }

        [HttpPost]
        [Route("update-student")]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentID))
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
        [Route("add-student")]
        public async Task<IHttpActionResult> AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        [HttpGet]
        [Route("delete-student")]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<StudentDto>(student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}