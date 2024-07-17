using FluentAssertions;
using FluentAssertions.Specialized;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Identity.Client;
using Moq;
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
using Tests.Helpers;
using nopCommerceApi.Controllers.Address;
using nopCommerceApi.Services.Customer;
using nopCommerceApi.Controllers.Customer;
using nopCommerceApi.Models.Customer;


namespace Tests
{
    public class CustomerControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly CustomerController _controller;

        public CustomerControllerTests(WebApplicationFactory<Program> factory)
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

            _customerServiceMock = new Mock<ICustomerService>();
            _controller = new CustomerController(_customerServiceMock.Object);

        }

        [Fact]
        public async Task GetAll_WithoutParamater_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/customer");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #region CreateWithNipPl
        [Theory]
        [JsonFileData("Data/CustomerBasePLWith23_Valid_Create_ControllerTest.json", typeof(CreateBaseCustomerPLDto))]
        public void CreateBasePL_ValidData_ReturnsCreatedResult(CreateBaseCustomerPLDto addressDto)
        {
            _customerServiceMock.Setup(x => x.CreateBasePL(It.IsAny<CreateBaseCustomerPLDto>()))
                               .Returns(JsonSerializer.Serialize(new Customer { Id = 1 }));

            // Act
            var result = _controller.CreateBasePLWith23Vat(addressDto);

            // Assert
            var createdResult = Assert.IsType<OkObjectResult>(result);
            createdResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion
    }
}
