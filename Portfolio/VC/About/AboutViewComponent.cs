using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.VC.About
{
	public class AboutViewComponent:ViewComponent
    { 

        private readonly IAboutDal _aboutDal;

		public AboutViewComponent(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}
		public Task<IViewComponentResult> InvokeAsync()
		{
			var values = _aboutDal.GetList();
			return Task.FromResult<IViewComponentResult>(View(values));
		}
	}
}
