using BelissimoCloneWPF.Domain.Entities.Attachment;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Service.DTOs.Attachment;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Orders;
using System.Collections.Generic;

namespace BelissimoCloneWPF.Service.Interfaces.Attachment
{
    public interface IAttachmentService
    {
        ValueTask<Attachments> CreateAsync(AttachmentForCreationDTO attachemntForCreationDTO);
        ValueTask<Attachments> UpdateAsync(int id, int foodId, AttachmentForCreationDTO attachemntForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Attachments> GetAsync(Expression<Func<Attachments, bool>> expression);
        ValueTask<IEnumerable<Attachments>> GetAllAsync(PaginationParams @params,
            Expression<Func<Attachments, bool>> expression = null);
    }
}
