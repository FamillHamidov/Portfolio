﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ServiceManager : IServiceService
	{
		private readonly IServiceDal _serviceDal;

		public ServiceManager(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

		public void Delete(Service t)
		{
			_serviceDal.Delete(t);
		}

		public List<Service> GetAll()
		{
			return _serviceDal.GetList();
		}

		public Service GetById(int id)
		{
			return _serviceDal.GetById(id);
		}

		public void TAdd(Service t)
		{
			_serviceDal.Insert(t);
		}

		public void Update(Service t)
		{
			_serviceDal.Update(t);
		}
	}
}
