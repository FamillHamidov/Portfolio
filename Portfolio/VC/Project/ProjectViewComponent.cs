using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.VC.Project
{
	public class ProjectViewComponent:ViewComponent
	{
		private readonly IPortfolioDal _portfolioDal;

		public ProjectViewComponent(IPortfolioDal portfolioDal)
		{
			_portfolioDal = portfolioDal;
		}
		public Task<IViewComponentResult> InvokeAsync()
		{
			var projects = _portfolioDal.GetList();
			return Task.FromResult<IViewComponentResult>(View(projects));
		}
	}
}
