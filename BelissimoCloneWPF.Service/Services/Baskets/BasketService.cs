using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Baskets;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.DTOs.Orders;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly IGenericRepository<Basket> _basketRepository;
        private readonly IMapper mapper;

        public BasketService(IGenericRepository<Basket> basketRepository,IMapper mapper) 
        {
            this._basketRepository = basketRepository;
            this.mapper = mapper;
        }
        public async ValueTask<BasketForViewDTO> CreateAsync(BasketForCreationDTO basketForCreationDTO)
        {
            var Basket = await _basketRepository.CreateAsync(mapper.Map<Basket>(basketForCreationDTO));
            await _basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(Basket);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await _basketRepository.DeleteAsync(b => b.Id == id);
            await _basketRepository.SaveChangesAsync();

            if (!isDeleted)
                throw new BelissimoCloneWPFException(404, "Basket not found");

            return true;
        }

        public async ValueTask<IEnumerable<BasketForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Basket, bool>> expression = null)
        {
            var baskets = _basketRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<BasketForViewDTO>>(await baskets.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<BasketForViewDTO> GetAsync(Expression<Func<Basket, bool>> expression)
        {
            var basket = await _basketRepository.GetAsync(expression);

            if (basket is null)
                throw new BelissimoCloneWPFException(404, "Basket not found");

            return mapper.Map<BasketForViewDTO>(basket);
        }

        public async ValueTask<BasketForViewDTO> UpdateAsync(int id, BasketForUpdateDTO basketForUpdateDTO)
        {
            var existingBasket = await _basketRepository.GetAsync(u => u.Id == id);

            if (existingBasket == null)
                throw new BelissimoCloneWPFException(404, "FoodOrder not found");

            existingBasket.UpdatedAt = DateTime.UtcNow;
            existingBasket = _basketRepository.Update(mapper.Map(basketForUpdateDTO, existingBasket));
            await _basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(existingBasket);
        }
    }
}
