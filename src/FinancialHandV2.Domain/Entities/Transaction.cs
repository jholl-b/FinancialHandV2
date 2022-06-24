using FinancialHandV2.Domain.Common;

namespace FinancialHandV2.Domain.Entities;

public class Transaction : AuditableEntity<int>
{
  public string? Description { get; set; }
  public decimal Amount { get; set; }
  public DateTime Date { get; set; }
}