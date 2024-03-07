using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Exstensios;
using TaskManager.Application.Abstracts.Auth;
using TaskManager.Application.Abstracts.Repositories;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Auth;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var configuration = builder.Configuration;
var securityConfigs = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("secrets/settings.json")
    .Build();


services.Configure<JwtOptions>(securityConfigs.GetSection(nameof(JwtOptions)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApiAuthentication(securityConfigs);
services.AddAutoMapper(typeof(MapperProfile));
services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Database"));
}, ServiceLifetime.Singleton);

services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IJwtProvider, JwtProvider>();

services.AddSingleton<IUserRepository, UserRepository>();
services.AddSingleton<IIssueRepository, IssueRepository>();
services.AddSingleton<IBoardRepository, BoardRepository>();

services.AddScoped<AccountServices>();
services.AddScoped<IssueServices>();
services.AddScoped<BoardServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
