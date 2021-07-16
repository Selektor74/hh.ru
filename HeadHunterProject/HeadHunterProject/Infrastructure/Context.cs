using HeadHunterProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Infrastructure
{
    public class Context:DbContext
    {
        public Context() : base("Business")
        { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
}