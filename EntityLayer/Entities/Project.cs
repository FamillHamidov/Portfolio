﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Project:BaseEntity
	{
        public string? FileName { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public string? ProjectUrl { get; set; }
    }
}
