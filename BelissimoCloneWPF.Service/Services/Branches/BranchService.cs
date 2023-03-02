using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Service.DTOs.Branches;
using BelissimoCloneWPF.Service.Interfaces.Branches;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.Branches
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

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync
            (PaginationParams @params, Expression<Func<Branch, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<BranchForViewDTO> UpdateAsync(int id, BranchForUpdateDTO branchForUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
