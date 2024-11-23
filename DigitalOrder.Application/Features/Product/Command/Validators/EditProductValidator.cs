using DigitalOrder.Application.Features.Product.Command.Models;
using DigitalOrder.Service.Abstracts;
using FluentValidation;

namespace DigitalOrder.Application.Features.Product.Command.Validators
{
    public class EditProductValidator : AbstractValidator<EditProductCommand>
    {
        private readonly IProductService _productService;
        public EditProductValidator(IProductService productService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _productService = productService;
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .NotNull().WithMessage("Product Name cannot be null.")
                .MaximumLength(150).WithMessage("Product Name must not exceed 150 characters.");

            RuleFor(x => x.ProductDetails)
                .NotEmpty().WithMessage("Product Details are required.")
                .NotNull().WithMessage("Product Details cannot be null.")
                .MaximumLength(500).WithMessage("Product Details must not exceed 500 characters.");

            RuleFor(x => x.ProductType)
                .NotEmpty().WithMessage("Product Type is required.")
                .NotNull().WithMessage("Product Type cannot be null.")
                .IsInEnum().WithMessage("Invalid Product Type value.");


            RuleFor(x => x.ProductPrice)
                .GreaterThan(0).WithMessage("Product Price must be greater than 0.")
                .NotEmpty().WithMessage("Product Price is required.")
                .NotNull().WithMessage("Product Price cannot be null.");
        }

        private void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ProductName)
                .MustAsync(async (model, Key, CancellationToken) => !await _productService.IsProductNameExists(Key, model.Id))
                .WithMessage("The Name already exists");
        }
    }
}
