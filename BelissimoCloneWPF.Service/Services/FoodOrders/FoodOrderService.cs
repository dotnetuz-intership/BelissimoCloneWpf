using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.FoodOrders;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.FoodOrders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BelissimoCloneWPF.Service.Services.FoodOrders
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly IGenericRepository<FoodOrder> foodOrderRepository;
        private readonly IMapper mapper;
        public FoodOrderService(IGenericRepository<FoodOrder> foodOrderRepository, IMapper mapper)
        {
            this.foodOrderRepository = foodOrderRepository;
            this.mapper = mapper;
        }

        public async ValueTask<FoodOrderForViewDTO> CreateAsync(FoodOrderForCreationDTO foodOrderForCreationDTO)
        {
            var foodOrder = await foodOrderRepository.CreateAsync(mapper.Map<FoodOrder>(foodOrderForCreationDTO));
            await foodOrderRepository.SaveChangesAsync();

            return mapper.Map<FoodOrderForViewDTO>(foodOrder);

        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await foodOrderRepository.DeleteAsync(f => f.Id == id);
            await foodOrderRepository.SaveChangesAsync();

            if (!isDeleted)
                throw new BelissimoCloneWPFException(404, "FoodOrder not found");

            return true;
        }

        public async ValueTask<IEnumerable<FoodOrderForViewDTO>> GetAllAsync(PaginationParams @params,
            Expression<Func<FoodOrder, bool>> expression = null)
        {
            var foodOrders = foodOrderRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<FoodOrderForViewDTO>>(await foodOrders.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<FoodOrderForViewDTO> GetAsync(Expression<Func<FoodOrder, bool>> expression)
        {
            var foodOrder = await foodOrderRepository.GetAsync(expression);

            if (foodOrder is null)
                throw new BelissimoCloneWPFException(404, "FoodOrder not found");

            return mapper.Map<FoodOrderForViewDTO>(foodOrder);
        }

        public async ValueTask<FoodOrderForViewDTO> UpdateAsync(int id, FoodOrderForUpdateDTO foodOrderForUpdateDTO)
        {
            var existFoodOrder = await foodOrderRepository.GetAsync(u => u.Id == id);

            if (existFoodOrder == null)
                throw new BelissimoCloneWPFException(404, "FoodOrder not found");

            existFoodOrder.UpdatedAt = DateTime.UtcNow;
            existFoodOrder = foodOrderRepository.Update(mapper.Map(foodOrderForUpdateDTO, existFoodOrder));
            await foodOrderRepository.SaveChangesAsync();

            return mapper.Map<FoodOrderForViewDTO>(existFoodOrder);
        }
    }
}
