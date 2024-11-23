using DigitalOrder.Application.Features.Product.Command.Models;
using Entities = DigitalOrder.Core.Entities;

namespace DigitalOrder.Application.Mapping.Product
{
    public partial class ProductProfile
    {
        public void EditProductMapping()
        {
            CreateMap<EditProductCommand, Entities.Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ProductType))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ProductDetails));

        }
    }
}
