using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ProjectValidator:AbstractValidator<Project>
	{
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("This field cannot be left blank");
        }
    }
}
