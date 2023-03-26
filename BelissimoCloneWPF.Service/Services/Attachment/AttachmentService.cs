using AutoMapper;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Configurations;
using BelissimoCloneWPF.Domain.Entities.Attachment;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Service.DTOs.Attachment;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Extentions;
using BelissimoCloneWPF.Service.Interfaces.Attachment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Services.Attachment
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IGenericRepository<Attachments> attachmentRepository;
        private readonly IMapper mapper;
        public AttachmentService(IGenericRepository<Attachments> attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async ValueTask<Attachments> CreateAsync(AttachmentForCreationDTO attachemntForCreationDTO)
        {
            FileStream fileStream = attachemntForCreationDTO.File as FileStream;
            string fileName = fileStream.Name;

            var filePath = Path.Combine(attachemntForCreationDTO.FullPath, "wwwroot", fileName);

            using (var newFileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.CopyTo(newFileStream);
            }

            var attachmentCreation = await attachmentRepository.CreateAsync(mapper.Map<Attachments>(attachemntForCreationDTO));
            await attachmentRepository.SaveChangesAsync();
            
            if(attachmentCreation != null)
            {
                throw new BelissimoCloneWPFException(404, "Attachment creation faild!");
            }
            return attachmentCreation;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var attachment = await attachmentRepository.GetAsync(x => x.Id == id);
            
            if (attachment == null)
                 throw new BelissimoCloneWPFException(404, "Attachment not found!");
            
            File.Delete(attachment.FullPath);

            await attachmentRepository.DeleteAsync(x => x.Id == id);
            await attachmentRepository.SaveChangesAsync();
            return true;

        }

        public async ValueTask<IEnumerable<Attachments>> GetAllAsync(PaginationParams @params, Expression<Func<Attachments, bool>> expression = null)
        {
            var attachments = attachmentRepository.GetAll(expression: expression, isTracking: false);
            if (attachments == null)
                throw new BelissimoCloneWPFException(404, "Attachments not found!");
            return await attachments.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Attachments> GetAsync(Expression<Func<Attachments, bool>> expression)
        {
            var attachment = await attachmentRepository.GetAsync(expression);
            if(attachment == null)
            {
                throw new BelissimoCloneWPFException(404, "Attachment not found!");
            }
            return attachment;

        }

        public async ValueTask<Attachments> UpdateAsync(int id, AttachmentForCreationDTO attachemntForUpdateDTO)
        {
            var existingAttachment = await attachmentRepository.GetAsync(x => x.Id == id);
            if (existingAttachment == null)
                throw new BelissimoCloneWPFException(404, "Attachment not found!");
            
            FileStream fileStream = attachemntForUpdateDTO.File as FileStream;
            string fileName = fileStream.Name;
            
            existingAttachment.UpdatedAt = DateTime.UtcNow;

            var newFilePath = Path.Combine(attachemntForUpdateDTO.FullPath, fileName);

            using (var file = new FileStream(newFilePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(file);
            }

            existingAttachment = attachmentRepository.Update(mapper.Map<Attachments>(attachemntForUpdateDTO));
            await attachmentRepository.SaveChangesAsync();
            return existingAttachment;

        }
    }
}
