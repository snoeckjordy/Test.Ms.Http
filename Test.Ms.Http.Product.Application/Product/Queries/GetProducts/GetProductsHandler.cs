using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Product.Application.Common.Interfaces;
using Test.Ms.Http.Product.Application.Product.Dtos;

namespace Test.Ms.Http.Product.Application.Product.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ProductDto[]>
    {
        private readonly IProductDbContext dbContext;

        public GetProductsHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductDto[]> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Products
                .Select(t => new ProductDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                }).ToArrayAsync();
        }
    }
}
