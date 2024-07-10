using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using NLog.Web;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;
using nopCommerceApi.Validations;
using System.Text.Json.Serialization;
using nopCommerceApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Initializes NLog
builder.Host.UseNLog(); 

// Configure JSON options to handle circular references
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.SerializerOptions.MaxDepth = 128;
});


// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddDbContext<NopCommerceContext>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configure services for controllers
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRoleService, CustomerRoleService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IStateProvinceService, StateProvinceService>();
builder.Services.AddScoped<ITaxCategoryService, TaxCategoryService>();
builder.Services.AddScoped<ITierPriceService, TierPriceService>();
builder.Services.AddScoped<IAddressAttributeService, AddressAttributeService>();

// Add Own Middleware to the container.
builder.Services.AddScoped<ErrorHandlingMiddleware>();

// Add Swagger
builder.Services.AddSwaggerGen();

// Configure custom validators
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAddressDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePolishEnterpriseAddressDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdatePolishEnterpriseAddressDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateAddressDtoValidator>());



var app = builder.Build();

// Register the ErrorHandlingMiddleware
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


// Use Swagger
app.UseSwagger();
app.UseSwaggerUI(app =>
{
    app.SwaggerEndpoint("/swagger/v1/swagger.json", "nopCommerceApi v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
