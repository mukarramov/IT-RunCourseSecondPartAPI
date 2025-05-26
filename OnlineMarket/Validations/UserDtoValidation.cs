using FluentValidation;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Validations;

public class UserDtoValidation : AbstractValidator<User>
{
    public UserDtoValidation()
    {
        RuleFor(c => c.Email).NotEmpty().MinimumLength(5).MaximumLength(50).EmailAddress();

        RuleFor(c => c.Password).NotEmpty().NotNull();
    }
}