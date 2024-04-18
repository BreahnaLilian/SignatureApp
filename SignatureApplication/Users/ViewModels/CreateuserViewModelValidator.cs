using FluentValidation;

namespace SignatureApplication.Users.ViewModels
{
    public class CreateuserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        const string emailRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";
        const string idnpRegex = "^[0-9]";
        const string phoneNrRegex = "^[0-9]";
        public CreateuserViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotNull()
                .MaximumLength(50)
                .Matches(emailRegex);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .MaximumLength(8)
                .Matches(phoneNrRegex);

            RuleFor(x => x.IDNP)
                .NotNull()
                .MaximumLength(13)
                .Matches(idnpRegex);

            RuleFor(x => x.Address)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.DateOfBirth)
                .NotNull();

            RuleFor(x => x.Gender)
                .NotNull();

            RuleFor(x => x.Status)
                .NotNull();
        }
    }
}
