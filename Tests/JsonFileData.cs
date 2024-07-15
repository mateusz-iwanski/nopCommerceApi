using Newtonsoft.Json;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization.DataContracts;
using Xunit.Sdk;

namespace Tests
{
    /// <summary>
    /// Represents a custom data attribute for reading data from a JSON file.
    /// 
    /// <example>
    /// For example
    /// <code>
    /// 
    /// [Theory]
    /// [JsonFileData("Data/AddressControllerData.json", typeof(CreatePolishEnterpriseAddressDto))]
    /// public void CreateWithNipPl_ValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
    /// {...}
    /// 
    /// </code>
    /// 
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly Type _dtoType;

        public JsonFileDataAttribute(string filePath, Type dtoType)
        {
            // Check if the provided type implements IBaseDto
            if (!typeof(IBaseDto).IsAssignableFrom(dtoType))
            {
                throw new ArgumentException($"The type {dtoType.Name} does not implement the required IBaseDto interface.", nameof(dtoType));
            }

            _filePath = filePath;
            _dtoType = dtoType;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // Ensure the type is a valid IBaseDto
            if (!typeof(IBaseDto).IsAssignableFrom(_dtoType))
            {
                throw new ArgumentException($"{_dtoType.Name} does not implement IBaseDto");
            }

            var jsonData = File.ReadAllText(_filePath);

            // Use reflection to deserialize
            var listType = typeof(List<>).MakeGenericType(new[] { _dtoType });
            var deserializedList = JsonConvert.DeserializeObject(jsonData, listType);

            var data = new List<object[]>();
            foreach (var item in (IEnumerable)deserializedList) 
            {
                data.Add(new object[] { item }); // Add each DTO as an object array
            }

            return data;
        }
    }
}
