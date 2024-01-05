using Microsoft.OpenApi.Models;
using servartur;
using servartur.Entities;
using servartur.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Servartur API",
        Description = "An ASP.NET Core Web API for managing server side of Fluttartur - a local multiplayer game based on \"The Resistance: Avalon\"",
    });
});
builder.Services.AddDbContext<GameDbContext>();
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IMatchupService, MatchupService>();

var app = builder.Build();

// Call services
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
seeder.Seed();


// Configure the HTTP request pipeline. //middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
