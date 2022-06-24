using FluentValidation;
using MediatR;

namespace FinancialHandV2.Application.Common.Behavior;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
  where TRequest : IRequest<TResponse>
{
  private readonly IEnumerable<IValidator<TRequest>> _validators;

  public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
  {
    _validators = validators;
  }

  public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
  {
    if(_validators.Any())
    {
      var context = new ValidationContext<TRequest>(request);

      var validationResult = await Task.WhenAll(
        _validators.Select(v => v.ValidateAsync(context, cancellationToken))
      );

      var failures = validationResult
        .Where(r => r.Errors.Any())
        .SelectMany(r => r.Errors)
        .ToList();

      if (failures.Any())
        throw new Exception(failures.Select(x => x.ErrorMessage).First());
    }

    return await next();
  }
}