global using dapTest.Data;
global using Microsoft.EntityFrameworkCore;
using dapTest.Data;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

ConfigureServices(
    builder.Services,
    builder.Configuration
    );

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("appDb"));
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

void ConfigureServices(IServiceCollection services, ConfigurationManager configManager)
{
    services.AddDbContext<DataContext>(
        opts =>
        {
            opts.UseMySql(configManager.GetConnectionString("appDb"), new MySqlServerVersion(new Version()));
        }, ServiceLifetime.Transient);
}