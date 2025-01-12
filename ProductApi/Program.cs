using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductService, ProductService>(); 

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 25))));
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();        
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
