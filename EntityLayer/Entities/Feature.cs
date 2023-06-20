using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Feature:BaseEntity
	{
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
	}
}
