using Microsoft.EntityFrameworkCore;
using Test.Ms.Http.Application.Common.Interfaces;

namespace Test.Ms.Http.Order.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Domain.Order> Orders => Set<Domain.Order>();

        public OrderDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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
                .Entity<Domain.Order>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Domain.Order>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Domain.Order>()
                .HasData(new Domain.Order
                {
                    Id = 1,
                    Name = "First order",
                    OrderDate = DateTime.Now,
                    Status = Domain.OrderStatus.New
                });
        }
    }
}
