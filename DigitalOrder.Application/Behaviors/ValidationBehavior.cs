﻿using FluentValidation;
using MediatR;

namespace DigitalOrder.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failuers = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failuers.Any())
                {
                    var message = failuers.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").FirstOrDefault();

                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }
}
