using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Infrastructure
{
    public class DbInitializerWork : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
        }
    }
}