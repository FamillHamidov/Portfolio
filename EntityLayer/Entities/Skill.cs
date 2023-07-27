using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Skill : BaseEntity
	{
		public string SkillName { get; set; } = null!;
		
		public int Value { get; set; }

	}
}
