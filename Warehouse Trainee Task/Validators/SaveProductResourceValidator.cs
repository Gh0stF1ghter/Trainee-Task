using FluentValidation;
using Warehouse_Trainee_Task.Resources;

namespace Warehouse_Trainee_Task.Validators
{
    public class SaveProductResourceValidator : AbstractValidator<SaveProductResource>
    {
        public SaveProductResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(a => a.DepartmentId)
                .NotEmpty()
                .WithMessage("Department Id cannot be 0");
        }
    }
}
