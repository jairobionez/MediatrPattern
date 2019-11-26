using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MediatrPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrPattern.Pipelines
{
    public class ValidationFailurePipeLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationFailurePipeLineBehavior(IEnumerable<IValidator<TRequest>> validators) => this._validators = validators;        

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = this._validators.Select(v => v.Validate(request));
            var errors = failures.SelectMany(result => result.Errors).Where(f => f != null);
            return failures.Any() ? Errors(errors) : next();
        }

        public static Task<TResponse> Errors(IEnumerable<ValidationFailure> validations)
        {
            var response = new Response(validations);

            return Task.FromResult(response as TResponse);
        }
    }
}
