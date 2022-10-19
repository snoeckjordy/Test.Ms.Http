using MediatR;
using Test.Ms.Http.Application.Common.Interfaces;

namespace Test.Ms.Http.Application.Order.Commands.CreateOrders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderDbContext dbContext;
        public CreateOrderHandler(IOrderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("Create Order dto should not be null");

            var newOrder = new Http.Order.Domain.Order
            {
                Name = request.Name,
                OrderDate = request.OrderDate,
                Status = Http.Order.Domain.OrderStatus.New
            };

            await dbContext.Orders.AddAsync(newOrder);
            await dbContext.SaveChangesAsync(default);

            return newOrder.Id;
        }
    }
}
