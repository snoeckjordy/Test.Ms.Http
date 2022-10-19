using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Product.Application.Common.Interfaces;

namespace Test.Ms.Http.Product.Infrastructure.Persistence
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public DbSet<Domain.Product> Products => Set<Domain.Product>();

        public ProductDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Domain.Product>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Domain.Product>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Domain.Product>()
                .HasData(new Domain.Product
                {
                    Id = 1,
                    Name = "TestProduct",
                    Price = 100      
                });
        }
    }
}
