using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjeContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebProgramlamaProje;Trusted_Connection=true", 
                b => b.MigrationsAssembly("DataAccess"));
            //base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<RentDeal> RentDeals { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
