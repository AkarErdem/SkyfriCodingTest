using System.ComponentModel.DataAnnotations;

namespace SkyfriCase.Models
{
    public class PortfolioDTO
    {
        public string? PortfolioName { get; set; }
        [Required] public Guid TenantId { get; set; }
    }
}
