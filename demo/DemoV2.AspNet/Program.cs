
using Caffoa;
using DemoV2.AspNet;
using DemoV2.AspNet.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCaffoaFactory<IDemoV2AspNetUserService, UserServiceFactory>();
builder.Services.AddCaffoaFactory<IDemoV2AspNetMaintainanceService, MaintainanceServiceFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
