namespace CustomerPlatform.Application.Plans;

public class PlanDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PlanType { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
}
