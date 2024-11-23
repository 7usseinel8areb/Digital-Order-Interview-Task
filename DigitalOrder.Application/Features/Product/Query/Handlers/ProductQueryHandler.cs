using AutoMapper;
using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.Product.Query.Models;
using DigitalOrder.Application.Features.Product.Query.Results;
using DigitalOrder.Service.Abstracts;
using MediatR;

namespace DigitalOrder.Application.Features.Product.Query.Handlers
{
    public class ProductQueryHandler : ResponseHandler
        , IRequestHandler<GetProductByIdQuery, Response<GetSingleProductResponse>>
        , IRequestHandler<GetAllProductsQuery, Response<List<GetSingleProductResponse>>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<Response<GetSingleProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            int productId = request.Id;

            var product = await _productService.GetProductByIdAsync(productId);

            if (product is null)
                return NotFound<GetSingleProductResponse>($"The product with Id: {productId} was not found!");

            var productMapper = _mapper.Map<GetSingleProductResponse>(product);

            return Success(productMapper);
        }

        public async Task<Response<List<GetSingleProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();

            var productListMapper = _mapper.Map<List<GetSingleProductResponse>>(products);

            return Success(productListMapper);
        }
    }
}
