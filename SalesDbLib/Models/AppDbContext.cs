using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDbLib.Models
{
    public class AppDbContext : DbContext
    {
        //DbSets go here (once create classes)
        public virtual DbSet<Customer> Customers { get; set; } //if forget to put class in here you will notice (DbSet is generic class, used for EF)
            
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(e => //have to specify which entity (all things using fluid API will use this phrasing)
            {
                e.HasIndex(p => p.Code).IsUnique(true); //first part is operation only, second part tells sql that column is unique
                e.Property(p => p.Name).HasMaxLength(30).IsRequired(true); //Fluid API version of max length and not null instead of attributes
            
            });
        }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if(!builder.IsConfigured)
            {
                var connStr = "server=localhost\\sqlexpress;database=EfSalesDb;trusted_connection=true;"; //same conn string, diff DB
                builder.UseSqlServer(connStr);
            }
        }
    }
}
