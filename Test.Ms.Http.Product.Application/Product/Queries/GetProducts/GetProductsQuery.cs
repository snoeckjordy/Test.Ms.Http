using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Product.Application.Product.Dtos;

namespace Test.Ms.Http.Product.Application.Product.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductDto[]>
    {
    }
}
