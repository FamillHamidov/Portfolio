using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class EducationValidator:AbstractValidator<Education>
	{
        public EducationValidator()
        {
            RuleFor(x => x.University).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Profession).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.BeginDate).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("This field cannot be left blank");
            
        }
    }
}
