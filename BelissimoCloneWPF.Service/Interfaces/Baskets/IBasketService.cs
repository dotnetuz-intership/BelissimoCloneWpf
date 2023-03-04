using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Baskets;
using BelissimoCloneWPF.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Interfaces.Baskets
{
    public interface IBasketService
    {
        ValueTask<BasketForViewDTO> CreateAsync(BasketForCreationDTO basketForCreationDTO);

        ValueTask<BasketForViewDTO> UpdateAsync(int id, BasketForUpdateDTO basketForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<IEnumerable<BasketForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Basket, bool>> expression = null);

        ValueTask<BasketForViewDTO> GetAsync(Expression<Func<Basket, bool>> expression);
    }
}
