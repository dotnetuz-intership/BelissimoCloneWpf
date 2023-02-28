using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Interfaces.Foods
{
    public interface IFoodService
    {
        ValueTask<FoodForViewDTO> CreateAsync(FoodForCreationDTO foodForCreationDTO);

        ValueTask<FoodForViewDTO> UpdateAsync(int id, FoodForCreationDTO foodForCreattionDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<IEnumerable<FoodForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Food, bool>> expression = null);

        ValueTask<FoodForViewDTO> GetAsync(Expression<Func<Food, bool>> expression);
    }
}
