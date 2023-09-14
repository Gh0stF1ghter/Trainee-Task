using FluentValidation;
using Warehouse_Trainee_Task.Resources;

namespace Warehouse_Trainee_Task.Validators
{
    public class SaveWorkerResourceValidator : AbstractValidator<SaveWorkerResource>
    {
        public SaveWorkerResourceValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(a => a.LastName)
                .MinimumLength(2)
                .MaximumLength(20);
        }
    }
}
