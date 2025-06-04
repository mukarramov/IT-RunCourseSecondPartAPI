using FluentValidation;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Validations;

public class UserCreateValidation : AbstractValidator<UserCreate>
{
    public UserCreateValidation()
    {
        RuleFor(c => c.Email).NotEmpty().MinimumLength(5).MaximumLength(50).EmailAddress();

        RuleFor(c => c.Password).NotEmpty().NotNull().MinimumLength(4).MaximumLength(16);
    }
}