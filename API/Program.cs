using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Poultry.Application.Services.Chickens;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region MyConfigs

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

}).AddEntityFrameworkStores<DatabaseContext>();

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

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
#endregion

#endregion



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
//app.UseCors(x =>
//{
//    var allowedOrigins = app.Configuration.GetValue<string>("AllowedHosts");
//    if (allowedOrigins.Equals("*", StringComparison.InvariantCulture))
//        x.AllowAnyOrigin();
//    else
//        x.WithOrigins(allowedOrigins.Split(";", StringSplitOptions.RemoveEmptyEntries)).AllowCredentials();

//    x.AllowAnyMethod().AllowAnyHeader();
//});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
