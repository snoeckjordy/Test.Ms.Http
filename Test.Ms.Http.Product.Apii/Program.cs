using MediatR;
using Test.Ms.Http.Product.Application;
using Test.Ms.Http.Product.Application.Product.Commands.CreateProducts;
using Test.Ms.Http.Product.Application.Product.Dtos;
using Test.Ms.Http.Product.Application.Product.Queries.GetProducts;
using Test.Ms.Http.Product.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastrucure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Products", async (IMediator mediator) =>
{
    return await mediator.Send(new GetProductsQuery(), default);
})
    .WithName("GetNewProducts");

app.MapPost("/Products", async (IMediator mediator, CreateProductDto create) =>
{
    return await mediator.Send(new CreateProductsCommand { Name = create.Name, Price = create.Price });
})
    .WithName("CreateTodo");

app.Run();
