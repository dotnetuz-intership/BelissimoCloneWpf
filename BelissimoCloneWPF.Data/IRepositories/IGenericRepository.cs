using System.Linq.Expressions;

namespace BelissimoCloneWPF.Data.IRepositories
{
    public interface IGenericRepository<Auditable> where Auditable : class
    {
        ValueTask<Auditable> CreateAsync(Auditable entity);
        Auditable Update(Auditable entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Auditable, bool>> expression);
        ValueTask<Auditable> GetAsync(Expression<Func<Auditable, bool>> expression, string[] includes = null);
        IQueryable<Auditable> GetAll(Expression<Func<Auditable, bool>> expression,
            string[] includes = null,
            bool isTracking = true);
    }
}
