using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Experience:BaseEntity
	{
        public DateTime Date { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description{ get; set; } 
    }
}
