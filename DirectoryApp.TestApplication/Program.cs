using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.DataAccessLayer.Repositories;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => {
        services.AddDbContext<TableContext>(s => s.UseNpgsql("Server=127.0.0.1;Port=5432;Database=DirectoryApp;User Id=postgres;Password=Qasx7865"));
        services.AddScoped<IRepository<Member>, MemberRepository>();
    })
    .Build();

var memberRepository = host.Services.GetService<IRepository<Member>>();

memberRepository.Create(new Member {
    UUID = Guid.NewGuid().ToString(),
    Company = "COMPANY",
    FullName = "FULLNAME"
});

memberRepository.SaveChanges();

host.Run();



//var ctx = new TableContext();

//ctx.Members.Add(new Member {
//    UUID = Guid.NewGuid().ToString(),
//    Company = "COMPANY",
//    FullName = "FULLNAME" 
//});

//ctx.SaveChanges();

Console.ReadLine();