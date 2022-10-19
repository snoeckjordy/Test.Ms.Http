using Microsoft.EntityFrameworkCore;
using Test.Ms.Http.Product.Application.Common.Interfaces;
using Test.Ms.Http.Product.Application.Product.Dtos;

namespace Test.Ms.Http.Product.Application.Product
{
    public class ProductService
    {
        public class OrderService : IProductService
        {
            private readonly IProductDbContext dbContext;

            public OrderService(IProductDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<ProductDto[]> GetNewProductsAsync()
            {
                return await dbContext.Products
                    .Select(t => new ProductDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Price = t.Price
                    }).ToArrayAsync();
            }
        }
    }
}
