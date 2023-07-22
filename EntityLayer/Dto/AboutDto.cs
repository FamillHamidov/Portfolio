using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
	public class AboutDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Summary { get; set; } = null!;
		public int Age { get; set; }
		public string? From { get; set; }
		public string? LivesIn { get; set; }
		public string? Gender { get; set; }
		public string? PictureUrl { get; set; }
		public IFormFile? Picture{ get; set; }

	}
}
