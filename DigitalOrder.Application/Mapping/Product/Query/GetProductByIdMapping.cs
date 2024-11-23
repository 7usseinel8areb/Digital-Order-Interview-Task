using DigitalOrder.Application.Features.Product.Query.Results;
using Entities = DigitalOrder.Core.Entities;

namespace DigitalOrder.Application.Mapping.Product
{
    public partial class ProductProfile
    {
        public void GetProductByIdMapping()
        {
            CreateMap<Entities.Product, GetSingleProductResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductDetails, opt => opt.MapFrom(src => src.Details));
        }
    }
}
