using Microsoft.EntityFrameworkCore;
using Trackerr.Application;
using Trackerr.Infrastructure;
using Trackerr.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var dbPath = builder.Configuration["Database:Path"]!;

if (dbPath.StartsWith("~/"))
{
    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    dbPath = Path.Combine(home, dbPath[2..]);
}

builder.Services.AddDbContext<TrackerrDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();