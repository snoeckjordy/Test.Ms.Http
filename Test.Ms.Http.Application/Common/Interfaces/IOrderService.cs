using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Application.Order.Dtos;
using Test.Ms.Http.Order.Domain;

namespace Test.Ms.Http.Application.Common.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto[]> GetNewOrdersAsync(OrderStatus status);
    }
}
