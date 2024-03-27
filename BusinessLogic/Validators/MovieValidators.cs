using DataAccess.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class MovieValidators : AbstractValidator<Movie>
    {
        public MovieValidators()
        {
            RuleFor(m => m.Title).NotEmpty()
                .MaximumLength(180)
                .MinimumLength(2);

            RuleFor(m => m.Year).NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(0)
                .WithMessage($"Year can't be less then {DateTime.Now.Year} or greater then 0");
        }
    }
}
