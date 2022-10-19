using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ms.Http.Order.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
