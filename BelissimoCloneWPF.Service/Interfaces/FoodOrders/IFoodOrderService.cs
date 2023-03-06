using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Interfaces.FoodOrders
{
    public interface IFoodOrderService
    {
        ValueTask<FoodOrderForViewDTO> CreateAsync(FoodOrderForCreationDTO foodOrderForCreationDTO);

        ValueTask<FoodOrderForViewDTO> UpdateAsync(int id, FoodOrderForUpdateDTO foodOrderForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<IEnumerable<FoodOrderForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<FoodOrder, bool>> expression = null);

        ValueTask<FoodOrderForViewDTO> GetAsync(Expression<Func<FoodOrder, bool>> expression);
    }
}
