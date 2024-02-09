using DapperProject.Context;
using DapperProject.Contracts;
using DapperProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();



var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
