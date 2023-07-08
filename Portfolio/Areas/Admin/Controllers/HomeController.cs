using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly Context _context;

		public HomeController(IAboutService aboutService, Context context)
		{
			_aboutService = aboutService;
			_context = context;
		}

		public IActionResult Index()
		{
			var info = _aboutService.GetAll();
			return View(info);
		}
		[HttpGet]
		public IActionResult GetAboutInfo(int id)
		{
			var info = _aboutService.GetById(id);
			return View(info);
		}
		[HttpPost]
		public IActionResult GetAboutInfo(About about)
		{
			_aboutService.Update(about);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
