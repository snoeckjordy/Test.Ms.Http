using Microsoft.EntityFrameworkCore;
using Test.Ms.Http.Product.Domain;

namespace Test.Ms.Http.Product.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Domain.Product> Products { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
