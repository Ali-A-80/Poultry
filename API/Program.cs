using Endpoint.API.DependencyInjection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Handlers;
using Poultry.Application.Validators.Chickens;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configs

#region DB
builder.Services.AddDbContext<DatabaseContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

#endregion

#region Identity

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = false;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;

}).AddEntityFrameworkStores<DatabaseContext>()
.AddDefaultTokenProviders();

#endregion

#region JWT

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Key"]));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
    ).AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
#endregion

#region MedaitR

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ListChickenHandler).Assembly));

builder.Services.AddServicesWithTheirLifetimes(depsConfig =>
{
    depsConfig.AssemblyNames = new string[] { "Poultry" };
});
#endregion

#region FluentValidation

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(DeleteChickenValidator).Assembly,
    includeInternalTypes: true);

#endregion

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.Map("/",
            () =>
                $"{Assembly.GetExecutingAssembly().GetName().Name} Vesrion {Assembly.GetExecutingAssembly().GetName().Version} is ready ({app.Environment.EnvironmentName})");

app.MapControllers();

app.Run();
