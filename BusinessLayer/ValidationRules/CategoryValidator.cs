using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("This field is not empty");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("This field is not empty");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("This field must be maximum 50 character");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("This field must be minimum 2 character");
        }
    }
}
