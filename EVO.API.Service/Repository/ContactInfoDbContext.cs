using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using EVO.API.Service.Models;

namespace EVO.API.Service.Repository
{
    public class ContactInfoDbContext : DbContext
    {
        public ContactInfoDbContext()
            : base("name=ContactsContext")
        {
        }
        public DbSet<ContactInformation> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContactInfoDbContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}