using hotel_booking_service.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string dbHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
string dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");
string dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
string dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
string dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

//string connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};";
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();