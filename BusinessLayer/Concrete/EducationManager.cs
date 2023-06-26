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
	public class EducationManager : IEducationService
	{
		private readonly IEducationDal _educationDal;

		public EducationManager(IEducationDal educationDal)
		{
			_educationDal = educationDal;
		}

		public void Delete(Education t)
		{
			_educationDal.Delete(t);
		}

		public List<Education> GetAll()
		{
			return _educationDal.GetList();
		}

		public Education GetById(int id)
		{
			return _educationDal.GetById(id);
		}

		public void TAdd(Education t)
		{
			_educationDal.Insert(t);
		}

		public void Update(Education t)
		{
			_educationDal.Update(t);
		}
	}
}
