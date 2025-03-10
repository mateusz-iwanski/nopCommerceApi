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
using nopCommerceApi.Services.Category;
using nopCommerceApi.Validations.Category;
using nopCommerceApi.Validations.ProductAttribute;
using nopCommerceApi.Validations.ProductCategory;
using nopCommerceApi.Validations.Manufacturer;
using nopCommerceApi.Services.Manufacturer;
using nopCommerceApi.Validations.ProductManufacturer;
using nopCommerceApi.Services.UrlRecord;
using nopCommerceApi.Validations.UrlRecord;
using nopCommerceApi.Validations.Picture;
using nopCommerceApi.Services.Picture;
using nopCommerceApi.Validations.ProductPicture;
using nopCommerceApi.Validations.SpecificationAttribute;
using nopCommerceApi.Validations.SpecificationAttributeGroup;
using nopCommerceApi.Services.SpecificationAttribute;
using nopCommerceApi.Validations.SpecificationAttributeOption;
using nopCommerceApi.Validations.ProductSpecificationAttributeMapping;
using nopCommerceApi.Services.Video;
using nopCommerceApi.Validations.ProductVideo;
using nopCommerceApi.Validations.Address;
using nopCommerceApi.Services.Country;
using nopCommerceApi.Services.StateProvince;
using nopCommerceApi.Validations.ProductAttributeValue;
using nopCommerceApi.Validations.ProductAttributeMapping;
using nopCommerceApi.Validations.ProductAvailabilityRange;
using nopCommerceApi.Validations.Customer;
using nopCommerceApi.Validations.ProductTag;
using nopCommerceApi.Services.TierPrice;
using nopCommerceApi.Services.Currency;
using nopCommerceApi.Services.Tax;
using nopCommerceApi.Services.DeliveryDayte;


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

// Load configuration from Docker secret
var secretPath = "/run/secrets/appsettings_json";
if (File.Exists(secretPath))
{
    builder.Configuration.AddJsonFile(secretPath, optional: false, reloadOnChange: true);
}

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
builder.Services.AddScoped<ITaxRateService, TaxRateService>();
builder.Services.AddScoped<ITierPriceService, TierPriceService>();
builder.Services.AddScoped<IAddressAttributeService, AddressAttributeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRoleService, CustomerRoleService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTagService, ProductTagService>();
builder.Services.AddScoped<IProductTemplateService, ProductTemplateService>();
builder.Services.AddScoped<IProductAvailabilityRangeService, ProductAvailabilityRangeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductCategoryMappingService, ProductCategoryMappingService>();
builder.Services.AddScoped<IProductAttributeValueService, ProductAttributeValueService>();
builder.Services.AddScoped<IProductAttributeService, ProductAttributeService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IProductManufaturerMappingService, ProductManufaturerMappingService>();
builder.Services.AddScoped<IUrlRecordService, UrlRecordService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IProductPictureMappingService, ProductPictureMappingService>();
builder.Services.AddScoped<ISpecificationAttributeService, SpecificationAttributeService>();
builder.Services.AddScoped<ISpecificationAttributeGroupService, SpecificationAttributeGroupService>();
builder.Services.AddScoped<ISpecificationAttributeOptionService, SpecificationAttributeOptionService>();
builder.Services.AddScoped<IProductSpecificationAttributeMappingService, ProductSpecificationAttributeMappingService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IProductVideoService, ProductVideoService>();
builder.Services.AddScoped<IPictureBinaryService, PictureBinaryService>();
builder.Services.AddScoped<IDeliveryDateService, DeliveryDateService>();


// Configure services for api user controllers
builder.Services.AddScoped<IApiUserAccountService, ApiUserAccountService>();
builder.Services.AddScoped<IApiUserService, ApiUserService>();

//// Register Seeder
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

// Address
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressCreatePolishEnterpriseDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressUpdatePolishEnterpriseDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressUpdateDtoValidator>());

// Customer
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerPLCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerPLUpdateDtoValidator>());


// Product
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductCreateMinimalValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockReviewsDtoValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockInformationDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PruductUpdateBlockSeoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockRatingDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockGiftCardDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockDownloadDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockRecurringDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockRentalPriceDtoValidatior>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockShippingDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockInventoryDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockAttributeDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductUpdateBlockPriceDtoValidator>());

// Product-Category-Mapping
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductCategoryMappingCreateDtoValidator>());

// Product-Attribute-Value
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAttributeValueCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAttributeValueUpdateDtoValidator>());

// Product-Attribute
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAttributeCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAttributeUpdateDtoValidator>());

// Product-Attribute-Mapping
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductProductAttributeMappingCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductProductAttributeMappingUpdateDtoValidator>());

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAttributeWithMappingCreateDtoValidator>());

// ProductAvailabilityRange
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductAvailabilityRangeCreateDtoValidator>());


// Category
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CategoryUpdateDtoValidator>());


// Manufacturer
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ManufacturerCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ManufacturerUpdateDtoValidator>());

// ProductManufacturerMapping
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductManufacturerMappingCreateValidator>());

// UrlRecord
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UrlRecordCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UrlRecordUpdateDtoValidator>());

// PictureService
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PictureCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PictureUpdateDtoValidator>());

// PitureBinaryService
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PictureBinaryCreateDtoValidator>());

// ProductPictureMapping
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductPictureMappingCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductPictureMappingUpdateDtoValidator>());

// SpecificationAttribute
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeCreateValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeUpdateValidator>());

// SpecificationAttributeGroup
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeGroupCreateValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeGroupUpdateValidator>());

// SpecificationAttributeOption
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeOptionCreateValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SpecificationAttributeOptionUpdateValidator>());

//ProductSpecificationAttributeMapping
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductSpecificationAttributeMappingCreateDtoValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductSpecificationAttributeMappingUpdateDtoValidator>());

//ProductVideo
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductVideoCreateValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductVideoUpdateValidator>());

// ProductTag
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductTagCreateValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductTagUpdateValidator>());



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

//Run seeders
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
    app.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Collapse all controllers by default
});

// Authorize users
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }