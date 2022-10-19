using MediatR;
using Test.Ms.Http.Product.Application.Common.Interfaces;

namespace Test.Ms.Http.Product.Application.Product.Commands.CreateProducts
{
    public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, int>
    {
        private readonly IProductDbContext dbContext;
        public CreateProductsHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<int> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("Create product dto should not be null");


            var newProduct = new Domain.Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await dbContext.Products.AddAsync(newProduct);
            await dbContext.SaveChangesAsync(default);

            return newProduct.Id;

        }
    }
}
