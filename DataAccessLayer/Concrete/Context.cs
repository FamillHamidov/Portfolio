using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context:DbContext
	{
        public Context(DbContextOptions<Context> options):base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Fatures { get; set; }
        public DbSet<Project> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
