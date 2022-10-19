using MediatR;

namespace Test.Ms.Http.Application.Order.Commands.CreateOrders
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
