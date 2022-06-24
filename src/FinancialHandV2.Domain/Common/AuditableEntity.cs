namespace FinancialHandV2.Domain.Common;

public abstract class AuditableEntity<TId>
{
  public TId Id { get; set; } = default!;
  public string? CreatedBy { get; set; }
  public DateTime CreatedDate { get; set; }
  public string? UpdatedBy { get; set; }
  public DateTime UpdatedDate { get; set; }
}