using DigitalOrder.Application.Features.Product.Command.Models;
using Entities = DigitalOrder.Core.Entities;

namespace DigitalOrder.Application.Mapping.Product
{
    public partial class ProductProfile
    {
        public void AddProductMapping()
        {
            CreateMap<Entities.Product, AddProductCommand>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductDetails, opt => opt.MapFrom(src => src.Details));

            // Define the reverse mapping
            CreateMap<AddProductCommand, Entities.Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ProductType))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ProductDetails));
        }
    }
}
