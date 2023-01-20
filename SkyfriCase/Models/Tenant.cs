using System.ComponentModel.DataAnnotations;

namespace SkyfriCase.Models
{
    public class Tenant
    {
        [Key] public Guid TenantId { get; set; }
        public string? TenantName { get; set; }
    }
}
