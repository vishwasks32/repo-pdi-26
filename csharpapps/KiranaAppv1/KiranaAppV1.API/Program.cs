using FluentValidation;
using FluentValidation.AspNetCore;
using KiranaAppV1.Core.DTOs.Validators;
using KiranaAppV1.Core.Interfaces;
using KiranaAppV1.Infrastructure.Data;
using KiranaAppV1.Infrastructure.Repositories;
using KiranaAppV1.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KiranaAppDbContext>(options=>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddValidatorsFromAssemblyContaining<ProductRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=>
    {
        options.SwaggerEndpoint("/openapi/v1.json","KiranaApp API");
    });
}

app.UseHttpsRedirection();
app.Run();