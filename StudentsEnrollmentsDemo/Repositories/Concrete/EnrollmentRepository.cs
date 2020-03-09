using StudentsEnrollmentsDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Repositories.Concrete
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(DbContext dbcontext) : base(dbcontext)
        {

        }
    }
}