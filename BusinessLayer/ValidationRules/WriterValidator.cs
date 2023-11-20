using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("This field is not empty");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("This field is not empty");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("This field is not empty");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Writer Name must be minimum 2 character ");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Writer Name must be maximum 50 character ");
        }
    }
}
