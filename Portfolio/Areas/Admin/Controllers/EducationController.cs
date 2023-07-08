using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EducationController : Controller
	{
		private readonly IEducationService _educationService;
		private readonly Context _context;

		public EducationController(IEducationService educationService, Context context)
		{
			_educationService = educationService;
			_context = context;
		}
		public IActionResult Index()
		{
			var edu = _educationService.GetAll();
			return View(edu);
		}
		[HttpGet]
		public IActionResult AddEdu()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddEdu(Education education)
		{
			_educationService.TAdd(education);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var edu=_educationService.GetById(id);
			_educationService.Delete(edu);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult GetEduInfo(int id)
		{
			var edu = _educationService.GetById(id);
			return View(edu);
		}
		[HttpPost]
		public IActionResult Update(Education education)
		{
			_educationService.Update(education);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
