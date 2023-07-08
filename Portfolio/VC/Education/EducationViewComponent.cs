using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.VC.Education
{
	public class EducationViewComponent:ViewComponent
	{
		private readonly IEducationDal _educationDal;

		public EducationViewComponent(IEducationDal educationDal)
		{
			_educationDal = educationDal;
		}
		public Task<IViewComponentResult> InvokeAsync()
		{
			var education = _educationDal.GetList();
			return Task.FromResult<IViewComponentResult>(View(education));
		}
	}
}
