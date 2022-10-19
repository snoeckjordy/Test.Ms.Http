using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Application.Order.Dtos;
using Test.Ms.Http.Order.Domain;

namespace Test.Ms.Http.Application.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<OrderDto[]>
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
