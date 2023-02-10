using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ECard.Models;

namespace ECard.DAL
{
    public class DataEntities : DbContext
    {
        public DataEntities() : base("name=DataEntities") { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ConfigSite> ConfigSites { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}