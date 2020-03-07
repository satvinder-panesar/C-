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
using StudentsEnrollmentsDemo.Core;
using StudentsEnrollmentsDemo.Core.Concrete;
using StudentsEnrollmentsDemo.Models;
using StudentsEnrollmentsDemo.Models.DTOs;
using StudentsEnrollmentsDemo.Models.RequestCriterias;

namespace StudentsEnrollmentsDemo.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new StudentsEnrollmentsDemoContext());

        [HttpGet]
        [Route("get-student")]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student student = await unitOfWork.Students.GetById(id);
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
            List<Student> lst = await unitOfWork.Students.GetByPredicate(s => s.StudentID > -1, new string[1] { "Enrollments" });

            return Json(Mapper.Map<List<StudentDto>>(lst));
        }

        [HttpPost]
        [Route("update-student")]
        public async Task<IHttpActionResult> UpdateStudent(UpdateStudent student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Students.Update(Mapper.Map<Student>(student));
            await unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        [Route("add-student")]
        public async Task<IHttpActionResult> AddStudent(AddStudent student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Students.Insert(Mapper.Map<Student>(student));
            await unitOfWork.Save();

            return Ok();
        }

        [HttpGet]
        [Route("delete-student")]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student existing = await unitOfWork.Students.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            unitOfWork.Students.Delete(id);
            await unitOfWork.Save();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}