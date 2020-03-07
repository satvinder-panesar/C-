using StudentsEnrollmentsDemo.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsEnrollmentsDemo.Core
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        Task<int> Save();
    }
}
