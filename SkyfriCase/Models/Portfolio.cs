using System.ComponentModel.DataAnnotations;

namespace SkyfriCase.Models
{
    public class Portfolio
    {
        [Key] public Guid PortfolioId { get; set; }
        [Required] public Guid TenantId { get; set; }
        public string? PortfolioName { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
