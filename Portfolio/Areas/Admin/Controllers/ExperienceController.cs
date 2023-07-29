using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation.Results;
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
			ExperienceValidator validations = new ExperienceValidator();
			ValidationResult result=validations.Validate(experience);
			if (result.IsValid) 
			{
				_experienceService.TAdd(experience);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
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
