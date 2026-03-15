using EmployeeService.Application;
using EmployeeService.Infrastructure;
using EmployeeService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Kernel.Security;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Controllers (bắt buộc cho Ardalis)
// --------------------
builder.Services.AddControllers();

// --------------------
// Application & Infrastructure
// --------------------
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// --------------------
// Swagger
// --------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});
builder.Services.AddJWTAuthenticationScheme(builder.Configuration);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    db.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
      {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });
}
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Unhandled Exception: {ex}");
    throw;
}
