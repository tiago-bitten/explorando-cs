using Microsoft.EntityFrameworkCore;
using UploadImage.Data;
using UploadImage.Repositories;
using UploadImage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// controllers
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductImagesRepository>();

// services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductImagesService>();
builder.Services.AddScoped<GoogleDriveService>();

builder.Services.AddDbContext<UploadImageDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
