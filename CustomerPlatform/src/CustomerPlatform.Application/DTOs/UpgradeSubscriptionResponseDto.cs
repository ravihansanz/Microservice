using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPlatform.Application.DTOs
{
    public class UpgradeSubscriptionResponseDto
    {
        public Guid CustomerId { get; set; }
        public Guid OldPlanId { get; set; }
        public Guid NewPlanId { get; set; }
        public Guid OrderId { get; set; }
        public string Status { get; set; } = "Upgraded";
    }
}
