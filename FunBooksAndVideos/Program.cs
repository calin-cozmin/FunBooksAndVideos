using FunBooksAndVideos.Context;
using FunBooksAndVideos.Repositories;
using FunBooksAndVideos.Repositories.Interfaces;
using FunBooksAndVideos.Services;
using FunBooksAndVideos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FunBooksAndVideosDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FunBooksAndVideosDb;Trusted_Connection=True;"));

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductStockRepository, ProductStockRepository>();
builder.Services.AddTransient(typeof(Lazy<>));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
