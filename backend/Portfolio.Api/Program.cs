using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers en Swagger.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// De connectionstring uit de configuratie lezen.
var connectionString = builder.Configuration
    .GetConnectionString("PortfolioDatabase")
    ?? throw new InvalidOperationException(
        "Connectionstring PortfolioDatabase ontbreekt."
    );

// EF Core registreren met de SQL Server-provider.
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<BlogpostService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();