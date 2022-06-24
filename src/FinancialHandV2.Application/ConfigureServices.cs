using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FinancialHandV2.Application.Common.Behavior;
using FluentValidation;

namespace FinancialHandV2.Application;

public static class ConfigureServices
{
  
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddMediatR(Assembly.GetExecutingAssembly());

    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

    return services;
  }
}