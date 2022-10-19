using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ms.Http.Product.Application.Product.Commands.CreateProducts
{
    public class CreateProductsCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
