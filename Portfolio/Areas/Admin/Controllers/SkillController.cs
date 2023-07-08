﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
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
			_skillService.TAdd(skill);
			_context.SaveChanges();
			return RedirectToAction("Index");
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
