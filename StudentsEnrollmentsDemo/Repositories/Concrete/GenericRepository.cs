using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace StudentsEnrollmentsDemo.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext dBContext = null;
        private DbSet<T> table = null;

        public GenericRepository(DbContext dbc)
        {
            dBContext = dbc;
            table = dBContext.Set<T>();
        }

        public async void Delete(int id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<T>> GetByPredicate(Expression<Func<T, bool>> predicate, string[] includes)
        {
            IQueryable<T> query = table;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(includes != null && includes.Length > 0)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public void Insert(T obj)
        {
            table.Add(obj); 
        }

        public void Update(T obj)
        {
            dBContext.Entry(obj).State = EntityState.Modified;
        }
    }
}