using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class PortfolioManager : IPortfolioService
	{
		private readonly IPortfolioDal _portfolioDal;

		public PortfolioManager(IPortfolioDal portfolioDal)
		{
			_portfolioDal = portfolioDal;
		}

		public void Delete(Project t)
		{
			_portfolioDal.Delete(t);
		}

		public List<Project> GetAll()
		{
			return _portfolioDal.GetList();
		}

		public Project GetById(int id)
		{
			return _portfolioDal.GetById(id);
		}

		public void TAdd(Project t)
		{
			_portfolioDal.Insert(t);
		}

		public void Update(Project t)
		{
			_portfolioDal.Update(t);
		}
	}
}
