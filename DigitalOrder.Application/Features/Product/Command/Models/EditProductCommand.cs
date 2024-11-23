﻿using DigitalOrder.Application.Bases;
using DigitalOrder.Core.Enums;
using MediatR;

namespace DigitalOrder.Application.Features.Product.Command.Models
{
    public class EditProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDetails { get; set; }

        public ProductType ProductType { get; set; }

        public decimal ProductPrice { get; set; }

    }
}