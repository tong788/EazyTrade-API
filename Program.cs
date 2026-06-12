using System.Text;
using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Repository;
using EazyTrade.Service;
using EazyTrade.Utility.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SecretKey"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

// auth service scope added 
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Configure Mapping
MappingConfiguration.ConfigureMapping();

// repository scope added
builder.Services.AddScoped<ICommodityRepository, CommodityRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreAccountRepository, StoreAccountRepository>();

//service scope added
builder.Services.AddScoped<ICommodityService, CommodityService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStoreAccountService, StoreAccountService>();
#endregion

var app = builder.Build();

#region Middleware
// Enforce HTTPS first for all incoming traffic
app.UseHttpsRedirection();

// Serve API documentation only in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Security checkpoints
app.UseAuthentication();
app.UseAuthorization();

// Execute code to controller (match HTTPS request to the controller, also bind model)
app.MapControllers();
#endregion

await app.RunAsync();


