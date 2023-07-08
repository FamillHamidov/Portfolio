using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.VC.Skill
{
	public class SkillViewComponent:ViewComponent
	{
		private readonly ISkillDal _skillDal;

		public SkillViewComponent(ISkillDal skillDal)
		{
			_skillDal = skillDal;
		}
		public Task<IViewComponentResult> InvokeAsync()
		{
			var skills = _skillDal.GetList();
			return Task.FromResult<IViewComponentResult>(View(skills));
		}
	}
}
