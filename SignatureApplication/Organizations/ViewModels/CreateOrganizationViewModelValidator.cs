using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApplication.Organizations.ViewModels
{
    public class CreateOrganizationViewModelValidator : AbstractValidator<CreateOrganizationViewModel>
    {
        const string idnpRegex = "^[0-9]";
        const string phoneNrRegex = "^[0-9]";

        public CreateOrganizationViewModelValidator()
        {
            RuleFor(x => x.CommercialName)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.JuridicalName)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .MaximumLength(8)
                .Matches(phoneNrRegex);

            RuleFor(x => x.IDNO)
                .NotNull()
                .MaximumLength(13)
                .Matches(idnpRegex);

            RuleFor(x => x.JuridicalAddress)
                .NotNull()
                .MaximumLength(50);
        }
    }
}
