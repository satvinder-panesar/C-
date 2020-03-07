using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace StudentsEnrollmentsDemo.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> GetByPredicate(Expression<Func<T, bool>> predicate, string[] includes);
        Task<T> GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}