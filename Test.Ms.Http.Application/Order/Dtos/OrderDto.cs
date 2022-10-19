using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ms.Http.Application.Order.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime OrderDate { get; set; }

    }
}
