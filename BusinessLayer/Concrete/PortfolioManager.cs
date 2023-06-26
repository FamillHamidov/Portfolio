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

		public void Delete(Portfolio t)
		{
			_portfolioDal.Delete(t);
		}

		public List<Portfolio> GetAll()
		{
			return _portfolioDal.GetList();
		}

		public Portfolio GetById(int id)
		{
			return _portfolioDal.GetById(id);
		}

		public void TAdd(Portfolio t)
		{
			_portfolioDal.Insert(t);
		}

		public void Update(Portfolio t)
		{
			_portfolioDal.Update(t);
		}
	}
}
