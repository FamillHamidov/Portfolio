using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ExperienceValidator:AbstractValidator<Experience>
	{
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Title).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.BeginDate).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("This field cannot be left blank");
			RuleFor(x => x.EndDate).GreaterThan(x => x.BeginDate).WithMessage("EndDate to must be after BeginDate from");
		}
	}
}
