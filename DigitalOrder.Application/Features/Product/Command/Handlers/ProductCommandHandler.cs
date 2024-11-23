using AutoMapper;
using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.Product.Command.Models;
using DigitalOrder.Service.Abstracts;
using MediatR;
using Entities = DigitalOrder.Core.Entities;

namespace DigitalOrder.Application.Features.Product.Command.Handlers
{
    public class ProductCommandHandler : ResponseHandler
        , IRequestHandler<AddProductCommand, Response<string>>
        , IRequestHandler<DeleteProductCommand, Response<string>>
        , IRequestHandler<EditProductCommand, Response<string>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductCommandHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = MapProduct(request);

            if (product is null)
                return BadRequest<string>();

            var result = await _productService.AddProductAsync(product);

            return result ? Created<string>("Product was added successfully") : BadRequest<string>("Can't add this product");
        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            int productId = request.Id;

            var product = await _productService.GetProductByIdAsync(productId);

            if (product is null)
                return NotFound<string>($"Product with Id: {productId} was not found");

            var result = await _productService.DeleteProductAsync(product);

            return result ? Delete<string>("Product was deleted successfully") : BadRequest<string>("Delete failed");
        }

        public async Task<Response<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            int productId = request.Id;

            var product = await _productService.GetProductByIdAsync(productId);

            if (product is null)
                return NotFound<string>("Product with Id: {productId} was not found");

            var productMapper = MapProduct(request);

            var result = await _productService.EditProductAsync(productMapper);

            return result ? Success($"Edits for product with id: {productId} has been done successfully") : BadRequest<string>("Update failed");
        }

        private Entities.Product? MapProduct<T>(T request)
        {
            return _mapper.Map<Entities.Product>(request);
        }
    }
}
