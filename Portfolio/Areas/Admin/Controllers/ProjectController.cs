using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProjectController : Controller
	{
		private readonly IPortfolioService _portfolioService;
		private readonly Context _context;

		public ProjectController(IPortfolioService portfolioService, Context context)
		{
			_portfolioService = portfolioService;
			_context = context;
		}
		public IActionResult Index()
		{
			var projects = _portfolioService.GetAll();
			return View(projects);
		}
		[HttpGet]
		public IActionResult AddProject()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddProject(Project project)
		{
			_portfolioService.TAdd(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult GetProjectInfo(int id)
		{
			var project =_portfolioService.GetById(id);
			return View(project);
		}
		[HttpPost]
		public IActionResult Update(Project project)
		{
			_portfolioService.Update(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		} 
		public IActionResult Delete(int id)
		{
			var project = _portfolioService.GetById(id);
			_portfolioService.Delete(project);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
