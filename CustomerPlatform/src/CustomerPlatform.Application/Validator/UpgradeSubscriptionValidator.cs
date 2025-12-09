using CustomerPlatform.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPlatform.Application.Validator
{
    public class UpgradeSubscriptionValidator : AbstractValidator<UpgradeSubscriptionCommand>
    {
        public UpgradeSubscriptionValidator()
        {
            RuleFor(x => x.CustomerId)
              .NotEmpty().WithMessage("CustomerId cannot be empty.");
            RuleFor(x => x.NewPlanId).GreaterThan(0);
        }
    }
}
