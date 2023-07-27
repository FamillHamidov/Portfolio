using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SkillValidator:AbstractValidator<Skill>
	{
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("This field cannot be left blank");
            RuleFor(x => x.Value).GreaterThan(0);
        }
    }
}
