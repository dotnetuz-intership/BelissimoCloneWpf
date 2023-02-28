using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Service.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Interfaces.Categories
{
    public interface ICategoryService
    {
        ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForCreationDTO categoryForCreatiponDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression);

        ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Category, bool>> expression);
    }
}
