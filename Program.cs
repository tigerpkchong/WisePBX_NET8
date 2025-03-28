using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using WisePBX.NET8.Models.SConnector;
using WisePBX.NET8.Models.SConnector_SP;
using WisePBX.NET8.Models.Wise;
using WisePBX.NET8.Models.Wise_SP;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddDbContext<SConnectorEntities>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("SconnConnectionString")));
builder.Services.AddDbContext<SConnectorSPEntities>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("SconnConnectionString")));
builder.Services.AddDbContext<WiseEntities>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("WiseConnectionString")));
builder.Services.AddDbContext<WiseSPEntities>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("WiseConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline. test 3
app.UseCors(configurePolicy: policy =>
{
    policy.SetIsOriginAllowed(origin =>
    {
        var host = new Uri(origin).Host;
        var ipAddresses = Dns.GetHostAddresses(host);
        return ipAddresses.Any(s => s.ToString().StartsWith("172.17."));
        
    })
    //policy.AllowAnyOrigin()
    //policy.WithOrigins("http://172.17.*.*")
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
