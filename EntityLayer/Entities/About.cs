using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class About:BaseEntity
	{
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public int Age { get; set; } 
        public string? From { get; set; } 
        public string? LivesIn { get; set; } 
        public string? Gender { get; set; }
        public string? PictureUrl { get; set; }
    }
}
