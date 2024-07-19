using FluentValidation;

namespace SignatureApplication.Auth.ViewModels
{
    public class AuthViewModelValidator : AbstractValidator<AuthViewModel>
    {
        public AuthViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
