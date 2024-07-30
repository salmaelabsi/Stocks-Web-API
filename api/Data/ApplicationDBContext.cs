using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApplication1.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser> //inherit from dbcontext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) //base allow us to pass dbContextOptions to DbContext
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);  //must be open for Identity db migrations
        //    modelBuilder.Entity<Stock>().ToTable("Stock");
        //    modelBuilder.Entity<Comment>().ToTable("Comments");
        //}

        //adding tables; wrap it in DbSet to be able to access tables
        public DbSet<Stock> Stocks { get; set; } //i'll grab data from db and u need to do sth with it; returns data in desired form [deferred execution]. using dbset=manipulating the entire table

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        //user roles declaration: reg users and admins
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId })); //foreign keys declaration

            builder.Entity<Portfolio>()  //connecting into the table
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}