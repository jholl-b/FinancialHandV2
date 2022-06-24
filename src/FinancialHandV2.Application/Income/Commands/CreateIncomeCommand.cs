using MediatR;

namespace FinancialHandV2.Application.Income.Commands;

public record CreateIncomeCommand : IRequest<int>
{
  public string? Description { get; init; }
  public decimal Amount { get; init; }
  public DateTime Date { get; init; }
}