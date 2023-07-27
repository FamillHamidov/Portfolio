using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SkillController : Controller
	{
		private readonly ISkillService _skillService;
		private readonly Context _context;
		public SkillController(ISkillService skillService, Context context)
		{
			_skillService = skillService;
			_context = context;
		}

		public IActionResult Index()
		{
			var skills=_skillService.GetAll();
			return View(skills);
		}
		[HttpGet]
		public IActionResult AddSkill()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddSkill(Skill skill)
		{
			SkillValidator validations = new SkillValidator();
			ValidationResult result = validations.Validate(skill);
			if (result.IsValid)
			{
				_skillService.TAdd(skill);
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
		public IActionResult GetSkillInfo(int id) 
		{
			var skill = _skillService.GetById(id);
			return View(skill);
		}
		[HttpPost]
		public IActionResult UpdateSkill(Skill skill)
		{
			_skillService.Update(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult DeleteSkill(int id)
		{
			var skill=_skillService.GetById(id);
			_skillService.Delete(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
