using ApiSln.Persistence;
using ApiSln.Application;
using ApiSln.Mapper;
using ApiSln.Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var environment = builder.Environment;
builder.Configuration.SetBasePath(environment.ContentRootPath).AddJsonFile("appsettings.json", optional: false).AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
