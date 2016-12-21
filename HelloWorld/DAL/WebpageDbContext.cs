using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloWorld.DAL
{
    public class WebpageDbContext : DbContext
    {
        public WebpageDbContext()
            : base("MyStuff")
        {
        }
        public DbSet<Webpage> Persons { get; set; }

        public System.Data.Entity.DbSet<HelloWorld.Models.LearningPlan> LearningPlans { get; set; }
    }
}