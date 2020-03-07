using StudentsEnrollmentsDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext dbcontext) : base(dbcontext)
        {

        }
    }
}