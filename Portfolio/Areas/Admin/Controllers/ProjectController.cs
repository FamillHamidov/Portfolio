using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using EntityLayer.Entities;
using FluentValidation.Results;
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
			ProjectValidator validations = new ProjectValidator();
			ValidationResult result=validations.Validate(project);
			if (result.IsValid)
			{
				_portfolioService.TAdd(project);
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
		[HttpGet]
		public IActionResult Image(int id)
		{
			var info = _portfolioService.GetById(id);
			ProjectDto dto = new ProjectDto
			{
				Id = info.Id,
				ProjectName = info.ProjectName,
				FileName = info.FileName,
				Description = info.Description,
				PictureUrl = info.PictureUrl,
				ProjectUrl = info.ProjectUrl,
			};
			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> Image(ProjectDto dto, Project project )
		{
			if (dto.Picture != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(dto.Picture.FileName);
				var imageName = Guid.NewGuid() + extension;
				var saveLocation = resource + "/wwwroot/adminimage/" + imageName;
				var stream = new FileStream(saveLocation, FileMode.Create);
				await dto.Picture.CopyToAsync(stream);
				project.PictureUrl = "/adminimage/" + imageName;
			}
			project.ProjectName = dto.ProjectName;
			project.FileName = dto.FileName;
			project.Description = dto.Description;
			project.ProjectName = dto.ProjectName;
			project.ProjectUrl= dto.ProjectUrl;
			_portfolioService.Update(project);
			_context.SaveChanges();
			return View();
		}
	}
}
