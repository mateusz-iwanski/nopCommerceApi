﻿using FluentAssertions;
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
using Tests.Helpers;

namespace Tests
{
    public class AddressControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly Mock<IAddressService> _addressServiceMock;
        private readonly AddressController _controller;
        private UpdatePolishEnterpriseAddressDto test = new UpdatePolishEnterpriseAddressDto();

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

        #region GetAll
        [Fact]
        public async Task GetAll_WithoutParamater_ReturnsOkResult()
        {
            // Act
            var response = await _client.GetAsync("/api/address");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        #endregion

        #region GetById
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
        public async Task GetById_WithParamater_ReturnsNotFound(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("%20")] // URL encoded space, also invalid
        [InlineData("1' OR '1'='1")] // SQL Injection attempt, should be handled gracefully
        [InlineData("2147483648")] // Max int value + 1, boundary condition if ID is an int
        [InlineData("abc")] // Non-numeric string, should be invalid if ID is expected to be numeric        
        public async Task GetById_WithParamater_ReturnsBadRequest(string queryParams)
        {
            // Act
            var response = await _client.GetAsync($"/api/address/{queryParams}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        #endregion

        #region CreateWithNipPl
        [Theory]
        [JsonFileData("Data/AddressWithNipPL_Valid_Create_ControllerTests.json", typeof(CreatePolishEnterpriseAddressDto))]
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
        [JsonFileData("Data/AddressWithNipPL_InValid_Create_ControllerTests.json", typeof(CreatePolishEnterpriseAddressDto))]
        public async Task CreateWithNipPl_InValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
        {
            // Arrange
            var httpContent = addressDto.ToJsonHttpContent();

            // Act
            var response = await _client.PostAsync("/api/address/add-with-nip", httpContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        #endregion

        #region UpdateWithNip
        [Theory]
        [JsonFileData("Data/AddressWithNipPL_Invalid_Update_ControllerTests.json", typeof(UpdatePolishEnterpriseAddressDto))]
        public async Task UpdateWithNipPl_InvalidData_ReturnsBadRequest(UpdatePolishEnterpriseAddressDto updateAddressDto)
        {
            // Arrange
            var httpContent = JsonSerializer.Serialize(updateAddressDto);
            var stringContent = new StringContent(httpContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"/api/address/update-with-nip/{updateAddressDto.Id}", stringContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [JsonFileData("Data/AddressWithNipPL_Valid_Update_ControllerTests.json", typeof(UpdatePolishEnterpriseAddressDto))]
        public async Task UpdateWithNipPl_ValidData_ReturnsOkRequest(UpdatePolishEnterpriseAddressDto updateAddressDto)
        {
            // Arrange
            var httpContent = JsonSerializer.Serialize(updateAddressDto);
            var stringContent = new StringContent(httpContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"/api/address/update-with-nip/{updateAddressDto.Id}", stringContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        #endregion

    }
}
