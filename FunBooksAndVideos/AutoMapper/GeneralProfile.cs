using AutoMapper;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.AutoMapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>()
                    .ForMember(m => m.UserMemberships, opt => opt.Ignore())
                    .ReverseMap();
                
                cfg.CreateMap<ProductModel, Product>().ReverseMap();
                
                cfg.CreateMap<OrderItemModel, OrderItem>().ReverseMap();
                
                cfg.CreateMap<ProductCategoryModel, ProductCategory>().ReverseMap();
                
                cfg.CreateMap<ProductStockModel, ProductStock>().ReverseMap();
                
                cfg.CreateMap<OrderModel, Order>().ReverseMap();
                
                cfg.CreateMap<PaymentTypeModel, PaymentType>().ReverseMap();
            });

            configuration.CreateMapper();
        }
    }
}
