using AfroHackReact.Model;
using FluentValidation;

namespace AfroHackReact.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(f => f.NomeUsuario).NotEmpty();
            RuleFor(f => f.Email).NotEmpty();
            RuleFor(f => f.CodigoTipoUsuario).NotEmpty();
            RuleFor(f => f.DataNascimento).NotEmpty();
            RuleFor(f => f.Senha).NotEmpty();
            RuleFor(f => f.CodigoAreaInteresse).NotEmpty();
        }
    }
}