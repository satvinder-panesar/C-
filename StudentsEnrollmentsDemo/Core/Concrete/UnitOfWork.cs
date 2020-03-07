using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using StudentsEnrollmentsDemo.Repositories.Concrete;

namespace StudentsEnrollmentsDemo.Core.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        public UnitOfWork(DbContext dbc)
        {
            dbContext = dbc;
            Students = new StudentRepository(dbc);
        }
        public IStudentRepository Students { get; private set; }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task<int> Save()
        {
            return await dbContext.SaveChangesAsync();
        }

    }
}