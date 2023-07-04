using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.ViewComponents.About
{
	public class AboutList : ViewComponent
	{
		private readonly IAboutDal _aboutDal;

		public AboutList(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}
		public async Task<IViewComponentResult> Invoke()
		{
			var values =await _aboutDal.GetList();
			return View(values);
		}
	}
}
