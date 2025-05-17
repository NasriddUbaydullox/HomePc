using System.Security.Claims;
using Metro.Database;
using Metro.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<Context>()
    .AddApiEndpoints();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql("Server=localhost;Port=5432;Database=Metro;User Id=postgres;Password=postgres;");
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}
app.MapGet("users/me", async (ClaimsPrincipal claims, Context context) =>
{
    string userId = claims.Claims.First(c=>c.Type == ClaimTypes.NameIdentifier).Value;

    return await context.Users.FindAsync(userId);
});

app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
