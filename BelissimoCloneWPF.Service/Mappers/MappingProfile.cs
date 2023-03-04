using AutoMapper;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Service.DTOs.Attachment;
using BelissimoCloneWPF.Service.DTOs.Branches;
using BelissimoCloneWPF.Service.DTOs.Foods;
using BelissimoCloneWPF.Service.DTOs.Orders;
using BelissimoCloneWPF.Service.DTOs.Users;
using System.Net.Mail;

namespace BelissimoCloneWPF.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //User
            CreateMap<User, UserForCreationDTO>().ReverseMap();

            //Order
            CreateMap<Order, OrderForCreationDTO>().ReverseMap();

            //Food
            CreateMap<Food, FoodForCreationDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryForCreationDTO>().ReverseMap();

            //FoodOrder
            CreateMap<FoodOrder, FoodOrderForCreationDTO>().ReverseMap();

            //Branch
            CreateMap<Branch, BranchForCreationDTO>().ReverseMap();

            //Basket
            CreateMap<Basket, BasketForCreationDTO>().ReverseMap();

            //Attachment
            CreateMap<Attachment, AttachmentForCreationDTO>().ReverseMap();

        }
    }
}
