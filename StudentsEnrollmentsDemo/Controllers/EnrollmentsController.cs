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
using StudentsEnrollmentsDemo.Models.RequestCriterias;

namespace StudentsEnrollmentsDemo.Controllers
{
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsController : ApiController
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new StudentsEnrollmentsDemoContext());

        [HttpGet]
        [Route("get-enrollment")]
        public async Task<IHttpActionResult> GetEnrollment(int id)
        {
            Enrollment enrollment = await unitOfWork.Enrollments.GetById(id, null, null);
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
            List<Enrollment> lst = await unitOfWork.Enrollments.GetByPredicate(null, null);

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

            unitOfWork.Enrollments.Update(enrollment);
            await unitOfWork.Save();
            return Ok();

        }

        [HttpPost]
        [Route("add-enrollment")]
        public async Task<IHttpActionResult> AddEnrollment(AddEnrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Enrollments.Insert(Mapper.Map<Enrollment>(enrollment));
            await unitOfWork.Save();

            return Ok();
        }

        [HttpGet]
        [Route("delete-enrollment")]
        public async Task<IHttpActionResult> DeleteEnrollment(int id)
        {
            Enrollment existing = await unitOfWork.Enrollments.GetById(id, null, null);
            if (existing == null)
            {
                return NotFound();
            }

            unitOfWork.Enrollments.Delete(id);
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