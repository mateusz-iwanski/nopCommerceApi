using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace Tests
{
    public class AddressControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AddressControllerTests(WebApplicationFactory<Program> factory)
        {
            // Arrange
            _client = factory.CreateClient();
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
        [InlineData("")] // Empty string, shoud return GetAll data
        public async Task GetById_WithParamater_ReturnsOkResult(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("999")] // Assuming 999 is a valid ID but does not exist
        [InlineData("-1")] // Negative ID, likely invalid
        [InlineData("0")] // Zero ID, might be considered invalid depending on the API
        [InlineData("abc")] // Non-numeric string, should be invalid if ID is expected to be numeric
        [InlineData("%20")] // URL encoded space, also invalid
        [InlineData("2147483647")] // Max int value, boundary condition if ID is an int
        [InlineData("1' OR '1'='1")] // SQL Injection attempt, should be handled gracefully
        public async Task GetById_WithParamater_ReturnsNotFound(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
