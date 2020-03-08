using AfroHackReact.Model;
using FluentValidation;

namespace AfroHackReact.Validator
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(f => f.Email).NotEmpty();
            RuleFor(f => f.Email).EmailAddress();
            RuleFor(f => f.Senha).NotEmpty();
        }
    }
}