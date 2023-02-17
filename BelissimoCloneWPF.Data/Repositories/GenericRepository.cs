using BelissimoCloneWPF.Data.Contexts;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private readonly BelissimoDbContext dbContext;     
        public GenericRepository(BelissimoDbContext dbContext)
        {
           this.dbContext = dbContext;
        }
        public async ValueTask<T> CreateAsync(T entity)
        {
            return (await dbContext.Set<T>().AddAsync(entity)).Entity;          
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbContext.Set<T>().FirstOrDefaultAsync(expression);
            if(entity==null)
            {
                return false;
            }
            else
            {
                dbContext.Set<T>().Remove(entity);             
                return true;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public T Update(T entity)
        {
            return (dbContext.Set<T>().Update(entity)).Entity;         
        }
        public async ValueTask SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
