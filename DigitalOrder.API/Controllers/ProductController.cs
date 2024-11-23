using DigitalOrder.API.Base;
using DigitalOrder.Application.Features.Product.Command.Models;
using DigitalOrder.Application.Features.Product.Query.Models;
using DigitalOrder.Core.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOrder.API.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpGet(Router.ProductRoutes.GetById)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return NewResult(product);
        }

        [HttpGet(Router.ProductRoutes.List)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return NewResult(products);
        }

        [HttpPost(Router.ProductRoutes.Create)]
        public async Task<IActionResult> AddProduct(AddProductCommand productCommand)
        {
            var response = await _mediator.Send(productCommand);

            return NewResult(response);
        }

        [HttpDelete(Router.ProductRoutes.Delete)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }

        [HttpPut(Router.ProductRoutes.Edit)]
        public async Task<IActionResult> EditProduct(EditProductCommand productCommand)
        {
            var response = await _mediator.Send(productCommand);
            return NewResult(response);
        }
    }
}
