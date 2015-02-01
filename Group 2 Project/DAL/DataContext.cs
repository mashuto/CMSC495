using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Group_2_Project.Models;

namespace Group_2_Project.DAL
{
    class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            Database.SetInitializer<DataContext>(new DataInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> Passwords { get; set; }
        public DbSet<UserInformation> Information { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
