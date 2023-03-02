using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Service.DTOs.Branches;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Branches;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.BranchServices
{
    internal class BranchService : IBranchService
    {
        private readonly IGenericRepository<Branch> branchRepository;
        private readonly IMapper mapper;
        public BranchService(IGenericRepository<Branch> branchRepository, IMapper mapper)
        {
            this.branchRepository = branchRepository;
            this.mapper = mapper;
        }

        public async ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO)
        {
            var branch = await branchRepository.CreateAsync(mapper.Map<Branch>(branchForCreationDTO));
            await branchRepository.SaveChangesAsync();

            return mapper.Map<BranchForViewDTO>(branch);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await branchRepository.DeleteAsync(b => b.Id == id);
            await branchRepository.SaveChangesAsync();

            if (!isDeleted)
                throw new BelissimoCloneWPFException(404, "Branch not found");

            return true;
        }

        public async ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync
            (PaginationParams @params, Expression<Func<Branch, bool>> expression = null)
        {
            var branch = branchRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<BranchForViewDTO>>(await branch.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression)
        {
            var branch = await branchRepository.GetAsync(expression);

            if (branch is null)
                throw new BelissimoCloneWPFException(404, "Branch not found");

            return mapper.Map<BranchForViewDTO>(branch);
        }

        public async ValueTask<BranchForViewDTO> UpdateAsync(int id, BranchForCreationDTO branchForCreationDTO)
        {
            var existBranch = await branchRepository.GetAsync(u => u.Id == id);

            if (existBranch == null)
                throw new BelissimoCloneWPFException(404, "Branch not found");

            existBranch.UpdatedAt = DateTime.UtcNow;
            existBranch = branchRepository.Update(mapper.Map(branchForCreationDTO, existBranch));
            await branchRepository.SaveChangesAsync();

            return mapper.Map<BranchForViewDTO>(existBranch);
        }
    }
}