using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.DelivaeryDate;
using nopCommerceApi.Services.DeliveryDayte;

namespace nopCommerceApi.Controllers.DeliveryDate
{

    [ApiController]
    [Route("api/delivery-date")]
    public class DeliveryDateController : ControllerBase
    {
        private readonly IDeliveryDateService _deliveryDateService;

        public DeliveryDateController(IDeliveryDateService deliveryDateService)
        {
            _deliveryDateService = deliveryDateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deliveryDates = await _deliveryDateService.GetAllAsync();
            return Ok(deliveryDates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deliveryDate = await _deliveryDateService.GetByIdAsync(id);
            if (deliveryDate == null)
                return NotFound();

            return Ok(deliveryDate);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeliveryDateCreateDto createDeliveryDateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deliveryDate = await _deliveryDateService.CreateAsync(createDeliveryDateDto);
            return CreatedAtAction(nameof(GetById), new { id = deliveryDate.Id }, deliveryDate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DeliveryDateUpdateDto updateDeliveryDateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != updateDeliveryDateDto.Id)
                return BadRequest("ID mismatch");

            var updatedDeliveryDate = await _deliveryDateService.UpdateAsync(updateDeliveryDateDto);
            if (updatedDeliveryDate == null)
                return NotFound();

            return Ok(updatedDeliveryDate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deliveryDateService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
