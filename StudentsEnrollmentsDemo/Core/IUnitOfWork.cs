using StudentsEnrollmentsDemo.Repositories;
using StudentsEnrollmentsDemo.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsEnrollmentsDemo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IEnrollmentRepository Enrollments { get; }
        Task<int> Save();
    }
}
