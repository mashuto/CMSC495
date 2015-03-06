/****************************************************************
 * DataContext.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/05/2015    Matthew Kocin       Updated to hopefully allow proper deployment
 * 3/06/2015    Matthew Kocin       Some updates to allow for proper deployment
*****************************************************************/

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
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            //Database.SetInitializer<DataContext>(null);
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Users\\Public\\");
            //This creates the database and adds the data
            Database.SetInitializer<DataContext>(new DataInitializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
