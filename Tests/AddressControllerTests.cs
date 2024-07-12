using FluentAssertions;
using FluentAssertions.Specialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Identity.Client;
using Moq;
using nopCommerceApi.Controllers;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Services;
using System.Net;
using Xunit;
using FluentValidation;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization.Policy;

namespace Tests
{
    public class AddressControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<IAddressService> _addressServiceMock;
        private readonly AddressController _controller;

        public AddressControllerTests(WebApplicationFactory<Program> factory)
        {
            // Arrange

            // Register authorization and authentication for the service for web application
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // when a query requires authorization it will be delegated to FakePolicyEvaluator
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });
            })
            .CreateClient();

            _addressServiceMock = new Mock<IAddressService>();
            _controller = new AddressController(_addressServiceMock.Object);
        }

        private IEnumerable<CreatePolishEnterpriseAddressDto> PolishEnterpriseAddressDto()
        {
            var dto = new List<CreatePolishEnterpriseAddressDto>
            {
                
                new CreatePolishEnterpriseAddressDto()
                { 
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "api@api.com",
                    Company = "API Company",
                    County = "małopolska",
                    City = "Kraków",
                    Address1 = "ul. API",
                    Address2 = "API 2",
                    ZipPostalCode = "30-000",
                    PhoneNumber = "123456789",
                    Nip = "7343216884"
                },
            };
            
            return dto;
        }

        [Fact]
        public async Task GetAll_WithoutParamater_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/address");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("1")] // Assuming 1 is a valid ID and exists
        [InlineData("")] // Empty string, shoud return GetAll data        [InlineData("")] // Empty string, shoud return GetAll data
        [InlineData(null)] // Null, should return GetAll data
        public async Task GetById_WithParamater_ReturnsOkResult(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("999")] // Assuming 999 is a valid ID but does not exist
        [InlineData("-1")] // Negative ID, likely invalid if ID is expected to be positive
        [InlineData("0")] // Zero ID, might be considered invalid depending on the API
        [InlineData("abc")] // Non-numeric string, should be invalid if ID is expected to be numeric
        [InlineData("%20")] // URL encoded space, also invalid
        [InlineData("2147483648")] // Max int value + 1, boundary condition if ID is an int
        [InlineData("1' OR '1'='1")] // SQL Injection attempt, should be handled gracefully        
        public async Task GetById_WithParamater_ReturnsNotFound(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [JsonFileData("Data/AddressWithNipPLValidControllerTests.json")]
        public void CreateWithNipPl_ValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
        {
            _addressServiceMock.Setup(x => x.CreateWithNip(It.IsAny<CreatePolishEnterpriseAddressDto>()))
                               .Returns(new Address { Id = 1 });

            // Act
            var result = _controller.CreateWithNipPl(addressDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            createdResult.Location.Should().Be("/api/address/1");
        }

        [Theory]
        [JsonFileData("Data/AddressWithNipPLInValidControllerTests.json")]
        public void CreateWithNipPl_InValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
        {
            // Arrange
            _addressServiceMock.Setup(x => x.CreateWithNip(It.IsAny<CreatePolishEnterpriseAddressDto>()))
                               .Throws(new ValidationException("FluentValidation invalid")); // Simulate FluentValidation failure

            // Act
            var result = _controller.CreateWithNipPl(addressDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            createdResult.Should().BeOfType<BadRequestObjectResult>();
        }

        //[Theory]
        //[JsonFileData("Data/AddressWithNipPLInValidControllerTests.json")]
        //public void CreateWithNipPl_InValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
        //{
        //    // Arrange
        //    _addressServiceMock.Setup(x => x.CreateWithNip(It.IsAny<CreatePolishEnterpriseAddressDto>()))
        //                       .Throws(new ValidationException("FluentValidation invalid")); // Simulate FluentValidation failure

        //    // Act
        //    var result = _controller.CreateWithNipPl(addressDto);

        //    // Assert
        //    var createdResult = Assert.IsType<CreatedResult>(result);
        //    createdResult.Should().BeOfType<BadRequestObjectResult>();
        //}

    }
}
