using FluentValidation;

namespace MediatrPattern.Domain.Users.Commands.Insert
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(p => p.Email)
                .EmailAddress();

            RuleFor(p => p.Name)
                .MaximumLength(50).WithMessage("Maxímo de caracteres permitidos {MaxLength}");
        }
    }
}
