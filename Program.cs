using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


var app = builder.Build();

// Configure the HTTP request pipeline. test
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

app.Run();
