using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reporting.Data;
using Reporting.Middleware;
using Reporting.Repositories;
using Reporting.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:7163");

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var jwtSetting = builder.Configuration.GetSection("jwtSettings");
var secret = Environment.GetEnvironmentVariable("SECRET");


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddScoped<IReporting , ReportingService>();

builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option => {
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secret)),
        ValidIssuer = jwtSetting["Issuer"]
    };
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
