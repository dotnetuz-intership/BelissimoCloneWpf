using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Service.DTOs.Branches;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace BelissimoCloneWPF.Service.Interfaces.Branches
{
    public interface IBranchService
    {
        ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO);

        ValueTask<BranchForViewDTO> UpdateAsync(int id, BranchForCreationDTO branchForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Branch, bool>> expression = null);

        ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression);
    }
}
