using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Service:BaseEntity
	{
        public string ServiceName { get; set; } = null!;    
        public string? Description { get; set; }
    }
}
