using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.DataAccessLayer.Repositories;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot();
//builder.Services.AddDbContext<TableContext>(s => s.UseNpgsql("Server=127.0.0.1;Port=5432;Database=DirectoryApp;User Id=postgres;Password=Qasx7865"));
//builder.Services.AddScoped<IRepository<Member>, MemberRepository>();
//builder.Services.AddScoped<IRepository<MemberContact>, MemberContactRepository>();

builder.WebHost.ConfigureAppConfiguration((host, config) => {
    config.AddJsonFile("ocelot.json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot();

app.Run();
