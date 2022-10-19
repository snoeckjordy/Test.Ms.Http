using MediatR;
using Test.Ms.Http.Application;
using Test.Ms.Http.Application.Order.Commands.CreateOrders;
using Test.Ms.Http.Application.Order.Dtos;
using Test.Ms.Http.Application.Order.Queries.GetOrders;
using Test.Ms.Http.Order.Domain;
using Test.Ms.Http.Order.Infrastructure;

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


app.MapGet("/Orders/{status}", async (IMediator mediator, OrderStatus status) =>
{
    return await mediator.Send(new GetOrdersQuery { OrderStatus = status }, default);
})
    .WithName("GetNewOrders");


app.MapPost("/Orders/{status}", async (IMediator mediator, CreateOrderDto create) =>
{
    return await mediator.Send(new CreateOrderCommand { Name = create.Name , OrderDate = create.OrderDate });
})
    .WithName("CreateOrder");


app.Run();
