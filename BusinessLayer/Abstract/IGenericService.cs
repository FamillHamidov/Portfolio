using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void TAdd(T t);
		void Update(T t);
		void Delete(T t);
		List<T> GetAll();
		T GetById(int id);
	}
}
