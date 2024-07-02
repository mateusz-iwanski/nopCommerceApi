using Microsoft.AspNetCore.Http.Json;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Configure JSON options to handle circular references
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.SerializerOptions.MaxDepth = 128;
});


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<nopCommerceDbContext>();

builder.Services.AddDbContext<NopCommerceContext>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
