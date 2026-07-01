using System.Text;
using EazyTrade.ConfigurationModels;
using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Repository;
using EazyTrade.Service;
using EazyTrade.Utility.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
    });
});

// Add CORS policy -> to allow request from frontend
builder.Services.AddCors(options =>
 {
     options.AddDefaultPolicy(policy =>
     {
         policy.WithOrigins("http://localhost:3000") // Allow specific origin  
             .WithMethods("GET", "POST", "PUT", "DELETE")     // Allow specific methods  
             .WithHeaders("Content-Type", "Authorization"); // Allow specific headers  
     }
     );
 });

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
builder.Services.AddScoped<IImageFileRepository, ImageFileRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreAccountRepository, StoreAccountRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//service scope added
builder.Services.AddScoped<ICommodityService, CommodityService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStoreAccountService, StoreAccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStorageService, StorageService>();

// map setting from appsettings.json to Configuration model
builder.Services.Configure<AwsS3Configuration>(builder.Configuration.GetSection(AwsS3Configuration.Section));
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

app.UseCors(); // Uses the default policy  

// Security checkpoints
app.UseAuthentication();
app.UseAuthorization();

// Execute code to controller (match HTTPS request to the controller, also bind model)
app.MapControllers();
#endregion

await app.RunAsync();


