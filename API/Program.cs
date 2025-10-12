using System.IO.Compression;
using System.Text;
using API.Data;
using API.Entity;
using API.interfaces;
using API.Middlewares;
using API.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("defaultconnection");

    options.UseSqlite(connectionString);
});

builder.Services.AddCors();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DataContext>();
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireDigit = false;

    option.User.RequireUniqueEmail = true;
    option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidIssuer = "berkaydagitan.com",
                        ValidateAudience = false,
                        ValidAudience = "abc",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSecurity:SecretKey"]!)),
                        ValidateLifetime = true
                    };
                });

builder.Services.AddControllers();
builder.Services.AddScoped<ICartServices, CartServices>();
// Learn more about configuring  OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandling>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demp API");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4444");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await SeedDatabase.InitializeAsync(app);

app.Run();
