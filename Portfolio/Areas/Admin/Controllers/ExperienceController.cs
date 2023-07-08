using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ExperienceController : Controller
	{
		private readonly IExperienceService _experienceService;
		private readonly Context _context;

		public ExperienceController(IExperienceService experienceService, Context context)
		{
			_experienceService = experienceService;
			_context = context;
		}

		public IActionResult Index()
		{
			var exp = _experienceService.GetAll();
			return View(exp);
		}
		[HttpGet]
		public IActionResult AddExp() 
		{
			return View();		
  		}
		[HttpPost]
		public IActionResult AddExp(Experience experience)
		{
			_experienceService.TAdd(experience);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult GetExpInfo(int id)
		{
			var exp=_experienceService.GetById(id);
			return View(exp);
		}
		[HttpPost]
		public IActionResult Update(Experience experience)
		{
			_experienceService.Update(experience);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var exp=_experienceService.GetById(id);
			_experienceService.Delete(exp);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
