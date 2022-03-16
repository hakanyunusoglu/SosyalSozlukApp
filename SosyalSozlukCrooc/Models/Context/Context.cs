using SosyalSozlukCrooc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SosyalSozlukCrooc.Models.Context
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Comment model builder
            modelBuilder.Entity<Comment>().HasRequired<User>(x => x.User).WithMany().WillCascadeOnDelete(false);
            
        }

        public Context()
        {
            Database.Connection.ConnectionString = "Data Source=.;Database=DBCrooc;trusted_connection=true";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Crooc> Croocs { get; set; }
        public DbSet<Story> Storys { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Poll> Polls { get; set; }

        public DbSet<Comment> comments { get; set; }
    }
}