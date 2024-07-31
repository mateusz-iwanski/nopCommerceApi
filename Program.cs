using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using NLog.Web;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;
using nopCommerceApi.Validations;
using System.Text.Json.Serialization;
using nopCommerceApi.Middleware;
using nopCommerceApi.Controllers;
using nopCommerceApi.Services.User;
using nopCommerceApi.Config;
using Config.Net;
using Microsoft.AspNetCore.Identity;
using nopCommerceApi.Models.User;
using nopCommerceApi;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using nopCommerceApi.Services.Customer;
using nopCommerceApi.Seeder;
using nopCommerceApi.Services.Product;
using nopCommerceApi.Entities;
using System.Reflection;


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

// Load IMySettings configuration
var settings = new ConfigurationBuilder<IMySettings>()
                .UseIniFile("appsettings.ini")
                .Build();



// Register IMySettings - custom settings
builder.Services.AddSingleton<IMySettings>(settings);

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
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRoleService, CustomerRoleService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTagService, ProductTagService>();
builder.Services.AddScoped<IProductTemplateService, ProductTemplateService>();
builder.Services.AddScoped<IProductAvailabilityRangeService, ProductAvailabilityRangeService>();


// Configure services for api user controllers
builder.Services.AddScoped<IApiUserAccountService, ApiUserAccountService>();
builder.Services.AddScoped<IApiUserService, ApiUserService>();

// Register Seeder
builder.Services.AddScoped<TaxCategorySeeder>();
builder.Services.AddScoped<AdminApiUserSeeder>();
builder.Services.AddScoped<CustomerRolesSeeder>();
builder.Services.AddScoped<TaxRateSeeder>();

// Password hasher for users accounts
builder.Services.AddScoped<IPasswordHasher<ApiUserDto>, PasswordHasher<ApiUserDto>>();


// Authentication settings
var authenticationSettings = new AuthenticationSettings();
/// from appsettings.json
ConfigurationBinder.Bind(builder.Configuration.GetSection("Authentication"), authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

// Add Own Middleware to the container.
builder.Services.AddScoped<ErrorHandlingMiddleware>();

// Configure custom validators
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressCreatePolishEnterpriseDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressUpdatePolishEnterpriseDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressUpdateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBaseCustomerPLDtoValidator>());
// Product
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductCreateMinimalValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateReviewsDtoValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateInformationDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PruductUpdateSeoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateRatingDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateGiftCardDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateDownloadDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateRecurringDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateRentalPriceDtoValidatior>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateShippingDtoValidator>());

#region Product
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateProductTagValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductTagValidator>());
#endregion



//Configure bearer to Authorize client
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "nopApiCommerce", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);


    // Define the Bearer security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Get token from /api/account/login and write like this: \"Bearer copied_token\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    // Use the Bearer scheme globally
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                BearerFormat = "JWT", // Set the default bearer format to JWT
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Run seeders
using (var scope = app.Services.CreateScope())
{
    var taxCategorySeeder = scope.ServiceProvider.GetRequiredService<TaxCategorySeeder>();
    taxCategorySeeder.SeedPL();
}

using (var scope = app.Services.CreateScope())
{
    var adminAccount = scope.ServiceProvider.GetRequiredService<AdminApiUserSeeder>();
    adminAccount.Seed();
}

using (var scope = app.Services.CreateScope())
{
    var adminAccount = scope.ServiceProvider.GetRequiredService<CustomerRolesSeeder>();
    adminAccount.SeedBasic();
}

using (var scope = app.Services.CreateScope())
{
    var adminAccount = scope.ServiceProvider.GetRequiredService<TaxRateSeeder>();
    adminAccount.Seed();
}



// Register the ErrorHandlingMiddleware
app.UseMiddleware<ErrorHandlingMiddleware>();


app.UseAuthentication();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


// Use Swagger
app.UseSwagger();
app.UseSwaggerUI(app =>
{
    app.SwaggerEndpoint("/swagger/v1/swagger.json", "nopCommerceApi v1");
});

// Authorize users
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }