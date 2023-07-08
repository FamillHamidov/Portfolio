using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Experience:BaseEntity
	{
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description{ get; set; } 
    }
}
