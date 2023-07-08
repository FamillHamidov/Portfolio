using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.VC.Experience
{
	public class ExperienceViewComponent:ViewComponent
	{
		private readonly IExperienceDal _experienceDal;

		public ExperienceViewComponent(IExperienceDal experienceDal)
		{
			_experienceDal = experienceDal;
		}
		public Task<IViewComponentResult> InvokeAsync()
		{
			var experience = _experienceDal.GetList();
			return Task.FromResult<IViewComponentResult>(View(experience));
		}
	}
}
