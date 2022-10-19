using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Application.Common.Interfaces;
using Test.Ms.Http.Application.Order.Dtos;
using Test.Ms.Http.Order.Domain;

namespace Test.Ms.Http.Application.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDbContext dbContext;

        public OrderService(IOrderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<OrderDto[]> GetNewOrdersAsync(OrderStatus status)
        {
            return await dbContext.Orders
                .Where(t => t.Status == status)
                .Select(t => new OrderDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    OrderDate = t.OrderDate,
                }).ToArrayAsync();
        }
    }
}
