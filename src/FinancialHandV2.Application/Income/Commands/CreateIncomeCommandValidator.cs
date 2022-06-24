using FluentValidation;

namespace FinancialHandV2.Application.Income.Commands;

public class CreateIncomeCommandValidator : AbstractValidator<CreateIncomeCommand>
{
  public CreateIncomeCommandValidator()
  {
    RuleFor(v => v.Description)
      .NotEmpty();
    RuleFor(v => v.Amount)
      .NotEmpty();
    RuleFor(v => v.Date)
      .NotEmpty();
  }
}