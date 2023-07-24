using Aspekt.Application.Repositories;
using Aspekt.Application.Services;
using Aspekt.Application.Services.Implementation;
using Aspekt.Domain.Models;
using Aspekt.Infrastructure;
using Aspekt.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Company>, BaseRepository<Company>>();
builder.Services.AddScoped<IRepository<Contact>, BaseRepository<Contact>>();
builder.Services.AddScoped<IRepository<Country>, BaseRepository<Country>>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddDbContext<ApplicationDbContext>(ops =>
    ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

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
