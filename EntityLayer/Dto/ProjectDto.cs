using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
	public class ProjectDto
	{
        public int Id { get; set; }
        public string? FileName { get; set; }
		public string ProjectName { get; set; } = null!;
		public string? Description { get; set; }
		public string? PictureUrl { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
