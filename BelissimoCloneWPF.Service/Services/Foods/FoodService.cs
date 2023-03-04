using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Foods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IGenericRepository<Food> foodRepository;
        private readonly IMapper mapper;
        public FoodService(IGenericRepository<Food> foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        public async ValueTask<FoodForViewDTO> CreateAsync(FoodForCreationDTO foodForCreationDTO)
        {
            var food = await foodRepository.CreateAsync(mapper.Map<Food>(foodForCreationDTO));
            await foodRepository.SaveChangesAsync();

            return mapper.Map<FoodForViewDTO>(food);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var remove = await foodRepository.DeleteAsync(i => i.Id == id);
            await foodRepository.SaveChangesAsync();

            if (!remove)
                throw new BelissimoCloneWPFException(404, "Food not found");

            return true;
        }

        public async ValueTask<IEnumerable<FoodForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Food, bool>> expression = null)
        {
            var foods = foodRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<FoodForViewDTO>>(await foods.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<FoodForViewDTO> GetAsync(Expression<Func<Food, bool>> expression)
        {
            var foods = await foodRepository.GetAsync(expression);

            if (foods is null)
                throw new BelissimoCloneWPFException(404, "Food not found");

            return mapper.Map<FoodForViewDTO>(foods);
        }

        public async ValueTask<FoodForViewDTO> UpdateAsync(int id, FoodForCreationDTO foodForCreattionDTO)
        {
            var isExists = await foodRepository.GetAsync(i => i.Id == id);

            if (isExists == null)
                throw new BelissimoCloneWPFException(404, "Food not found");

            isExists.UpdatedAt = DateTime.UtcNow;
            isExists = foodRepository.Update(mapper.Map(foodForCreattionDTO, isExists));

            return mapper.Map<FoodForViewDTO>(isExists);
        }
    }
}
