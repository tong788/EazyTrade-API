using EazyTrade.Data;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Repository;
using EazyTrade.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// repository scope added
builder.Services.AddScoped<ICommodityRepository, CommodityRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//service scope added
builder.Services.AddScoped<ICommodityService, CommodityService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
await app.RunAsync();


