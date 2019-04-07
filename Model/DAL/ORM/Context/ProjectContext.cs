using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Model.DAL.ORM.Entity;

namespace TelephoneDirectory.Model.DAL.ORM.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-360Q214\\SQLSERVER2017EXP;Database=TelephoneDirectory;UID=mrv;PWD=123456;";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
