using FluentValidation;
using Warehouse_Trainee_Task.Resources;

namespace Warehouse_Trainee_Task.Validators
{
    public class SaveDepartmentResourceValidator : AbstractValidator<SaveDepartmentResource>
    {
        public SaveDepartmentResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(15);
        }
    }
}
