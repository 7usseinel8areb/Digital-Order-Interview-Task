using AutoMapper;

namespace DigitalOrder.Application.Mapping.Product
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            GetProductByIdMapping();
            GetAllProductsMapping();
            AddProductMapping();
            EditProductMapping();
        }
    }
}
