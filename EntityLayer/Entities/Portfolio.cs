using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Portfolio:BaseEntity
	{
        public string? FileName { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
