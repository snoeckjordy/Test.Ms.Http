using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Ms.Http.Application.Common.Interfaces;
using Test.Ms.Http.Application.Order.Dtos;

namespace Test.Ms.Http.Application.Order.Queries.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, OrderDto[]>
    {
        private readonly IOrderDbContext dbContext;

        public GetOrdersHandler(IOrderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OrderDto[]> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Orders
                .Where(t => t.Status == request.OrderStatus)
                .Select(t => new OrderDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    OrderDate = t.OrderDate,
                }).ToArrayAsync();
        }
    }
}
