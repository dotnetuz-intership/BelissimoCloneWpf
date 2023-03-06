using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Baskets;
using BelissimoCloneWPF.Service.DTOs.Orders;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Baskets;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BelissimoCloneWPF.Service.Services.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly IGenericRepository<Basket> basketRepository;
        private readonly IMapper mapper;

        public BasketService(IGenericRepository<Basket> basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async ValueTask<BasketForViewDTO> CreateAsync(BasketForCreationDTO basketForCreationDTO)
        {
            var basket = await basketRepository.CreateAsync(mapper.Map<Basket>(basketForCreationDTO));
            await basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(basket);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await basketRepository.DeleteAsync(b => b.Id == id);
            await basketRepository.SaveChangesAsync();

            if (!isDeleted)
                throw new BelissimoCloneWPFException(404, "Basket not found");

            return true;
        }

        public async ValueTask<IEnumerable<BasketForViewDTO>> GetAllAsync(PaginationParams @params,
            Expression<Func<Basket,
            bool>> expression = null)
        {
            var baskets = basketRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<BasketForViewDTO>>(await baskets.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<BasketForViewDTO> GetAsync(Expression<Func<Basket, bool>> expression)
        {
            var basket = await basketRepository.GetAsync(expression);

            if (basket is null)
                throw new BelissimoCloneWPFException(404, "Basket not found");

            return mapper.Map<BasketForViewDTO>(basket);
        }

        public async ValueTask<BasketForViewDTO> UpdateAsync(int id, BasketForUpdateDTO basketForUpdateDTO)
        {
            var existingBasket = await basketRepository.GetAsync(u => u.Id == id);

            if (existingBasket == null)
                throw new BelissimoCloneWPFException(404, "Basket not found");

            existingBasket.UpdatedAt = DateTime.UtcNow;
            existingBasket = basketRepository.Update(mapper.Map(basketForUpdateDTO, existingBasket));
            await basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(existingBasket);
        }
    }
}
