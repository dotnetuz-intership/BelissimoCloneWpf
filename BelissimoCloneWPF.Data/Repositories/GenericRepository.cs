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
        private readonly BelissimoDbContext _dbContext;     
        public GenericRepository(BelissimoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask<T> CreateAsync(T entity)
        {
            return (await _dbContext.Set<T>().AddAsync(entity)).Entity;
            SaveChangesAsync();
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
            if(entity==null)
            {
                return false;
            }
            else
            {
                _dbContext.Set<T>().Remove(entity);
                SaveChangesAsync();
                return true;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public T Update(T entity)
        {
            return (_dbContext.Set<T>().Update(entity)).Entity;
            SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
