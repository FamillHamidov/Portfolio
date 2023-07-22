using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Admin.Models;

namespace Portfolio.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		private readonly UserManager<AdminUser> _userManager;
		private readonly SignInManager<AdminUser> _signInManager;

        public LoginController(UserManager<AdminUser> userManager, SignInManager<AdminUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(AdminRegisterViewModel model)
		{
			AdminUser viewModel = new AdminUser()
			{
				Email=model.Email,
				Name = model.Name,
				Surname = model.Surname,
				UserName=model.Username,
				PictureUrl=model.ImageUrl
			};
			var result=await _userManager.CreateAsync(viewModel,model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(AdminLoginViewModel model)
		{
			var admin = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
			if (admin.Succeeded) 
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
	}
}
