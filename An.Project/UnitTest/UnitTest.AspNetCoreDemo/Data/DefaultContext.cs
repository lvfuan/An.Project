using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.AspNetCoreDemo.Models;
using System.Configuration;

namespace UnitTest.AspNetCoreDemo.Data
{
    public class DefaultContext:DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options):base(options) { }
        public DbSet<BlogModel> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogModel>().ToTable("Blogs");
            base.OnModelCreating(modelBuilder);
        }

    }
}
