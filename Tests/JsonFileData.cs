using Newtonsoft.Json;
using nopCommerceApi.Models.Address;
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
    /// [JsonFileData("Data/AddressControllerData.json")]
    /// public void CreateWithNipPl_ValidData_ReturnsCreatedResult(CreatePolishEnterpriseAddressDto addressDto)
    /// {...}
    /// 
    /// </code>
    /// 
    /// </example>
    /// </summary>
    public class JsonFileData : DataAttribute
    {
        private readonly string _filePath;
        public JsonFileData(string filePath)
        {
            _filePath = filePath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var currentDirectory = Directory.GetCurrentDirectory();
            var file = Path.Combine(currentDirectory, _filePath);
            if (!File.Exists(file))
            {
                throw new ArgumentException($"Could not find file at path: {_filePath}");
            }


            var jsonData = File.ReadAllText(file);
            var dtoList = JsonConvert.DeserializeObject<List<CreatePolishEnterpriseAddressDto>>(jsonData);

            var data = new List<object[]>();
            foreach (var dto in dtoList)
            {
                data.Add(new object[] { dto });
            }

            return data;
        }
    }
}
