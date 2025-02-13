using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Manufacturer;
using nopCommerceApi.Models.ProductManufacturer;
using nopCommerceApi.Services.Manufacturer;

namespace nopCommerceApi.Controllers.Manufacturer
{
    [Route("api/manufacturer")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;        

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manufacturers = await _manufacturerService.GetAllAsync();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var manufacturer = await _manufacturerService.GetByIdAsync(id);
            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ManufacturerCreateDto manufacturerDto)
        {
            var manufacturer = await _manufacturerService.CreateAsync(manufacturerDto);
            return Created($"api/manufacturer/{manufacturer.Id}", manufacturer);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ManufacturerUpdateDto manufacturerDto)
        {
            var manufacturer = await _manufacturerService.UpdateAsync(manufacturerDto);
            return Ok(manufacturer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manufacturerService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get manufacturer by product id
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var manufacturer = await _manufacturerService.GetByProductIdAsync(productId);
            return Ok(manufacturer);
        }


    }
}
