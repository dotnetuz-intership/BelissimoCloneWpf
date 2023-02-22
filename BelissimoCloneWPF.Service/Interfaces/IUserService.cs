using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Service.DTOs.Users;
using System.Linq.Expressions;

namespace BelissimoCloneWPF.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<User> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<User> UpdateAsync(int id, User userForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<IEnumerable<User>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<User, bool>> expression = null);

        ValueTask<User> GetAsync(Expression<Func<User, bool>> expression);
    }
}
