using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Dto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Admin.Models;

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
		[HttpGet]
		public IActionResult Image(int id)
		{
			var info = _aboutService.GetById(id);
			AboutDto dto = new AboutDto
			{
				Id = info.Id,
				Name = info.Name,
				Title = info.Title,
				Summary = info.Summary,
				Age = info.Age,
				From = info.From,
				LivesIn = info.LivesIn,
				Gender = info.Gender,
				PictureUrl = info.PictureUrl
			};
			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> Image(AboutDto dto, About about)
		{

			if (dto.Picture != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(dto.Picture.FileName);
				var imageName = Guid.NewGuid() + extension;
				var saveLocation = resource + "/wwwroot/adminimage/" + imageName;
				var stream = new FileStream(saveLocation, FileMode.Create);
				await dto.Picture.CopyToAsync(stream);
				about.PictureUrl = "/adminimage/" + imageName;
			}
			about.Name = dto.Name;
			about.Title = dto.Title;
			about.Summary = dto.Summary;
			about.Age = dto.Age;
			about.From = dto.From;
			about.LivesIn = dto.LivesIn;
			about.Gender = dto.Gender;
			_aboutService.Update(about);
			_context.SaveChanges();
			return View();
		}
	}
}
