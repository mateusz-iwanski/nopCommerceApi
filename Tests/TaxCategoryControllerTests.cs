using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using nopCommerceApi.Controllers.Customer;
using nopCommerceApi.Services.Customer;

namespace Tests
{
    public class TaxCategoryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly CustomerController _controller;

        public TaxCategoryControllerTests(WebApplicationFactory<Program> factory)
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


    }
}
