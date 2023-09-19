
using Caffoa;
using DemoV2.AspNetNewtonSoft;
using DemoV2.AspNetNewtonSoft.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCaffoaFactory<IDemoV2AspNetNewtonSoftUserService, UserServiceFactory>();
builder.Services.AddCaffoaFactory<IDemoV2AspNetNewtonSoftMaintainanceService, MaintainanceServiceFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
