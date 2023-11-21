using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(a => a.BlogTitle).NotEmpty().WithMessage("This field must not be empty");
            RuleFor(a => a.BlogContent).NotEmpty().WithMessage("This field must not be empty");
            RuleFor(a => a.BlogImage).NotEmpty().WithMessage("This field must not be empty");
            RuleFor(a => a.BlogTitle).MaximumLength(150).WithMessage("Title must be maximum 150 character");
            RuleFor(a => a.BlogTitle).MinimumLength(5).WithMessage("Title must be minimum 5 character");
            RuleFor(a => a.BlogContent).MinimumLength(10).WithMessage("Title must be minimum 10 character");
        }
    }
}
