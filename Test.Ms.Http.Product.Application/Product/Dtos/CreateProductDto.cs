using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ms.Http.Product.Application.Product.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
