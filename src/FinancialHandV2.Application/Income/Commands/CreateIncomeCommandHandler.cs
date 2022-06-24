using FinancialHandV2.Domain.Entities;
using MediatR;

namespace FinancialHandV2.Application.Income.Commands;

public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
{
  public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
  {
    var transaction = new Transaction
    {
      Id = 0,
      Description = request.Description,
      Amount = request.Amount,
      Date = request.Date
    };

    return transaction.Id;
  }
}