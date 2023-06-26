using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Education:BaseEntity
	{
        public DateTime Date { get; set; }
        public string University { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string?  Description { get; set; }
    }
}
