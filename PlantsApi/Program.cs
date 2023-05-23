using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Plants.Api.Services;
using Plants.Infrastructure.DBSettings;
using Plants.Services.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "AnotherPolicy";



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("ConnectionString"))
);
builder.Services.Configure<PlantsDatabaseSettings>(builder.Configuration.GetSection("PlantsDatabaseSettings"));

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IPlantRecordService, PlantRecordService>();
builder.Services.AddScoped<IUtilsService, UtilsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
  options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
      );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
