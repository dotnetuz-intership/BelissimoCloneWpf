using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO)
        {
            var alreadyCategory = await categoryRepository.GetAsync(c =>
                c.Content == categoryForCreationDTO.Content);

            if (alreadyCategory != null)
                throw new BelissimoCloneWPFException(400, "Category with such categoryname already exist");

            var category = await categoryRepository.CreateAsync(mapper.Map<Category>(categoryForCreationDTO));
            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await categoryRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Category Not found");

            await categoryRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(
            PaginationParams @params, Expression<Func<Category, bool>> expression)
        {
            var categories = categoryRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<IEnumerable<CategoryForViewDTO>>(
                await categories.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await categoryRepository.GetAsync(expression);

            if (category == null)
                throw new BelissimoCloneWPFException(404, "Category Not found");

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForCreationDTO categoryForCreationDTO)
        {
            var categoryData = await categoryRepository.GetAsync(c => c.Id == id);

            if (categoryData == null)
                throw new BelissimoCloneWPFException(404, "Category Not found");

            categoryData = categoryRepository.Update(mapper.Map(categoryForCreationDTO, categoryData));
            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(categoryData);
        }
    }
}
