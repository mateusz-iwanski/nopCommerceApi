using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.UrlRecord;
using nopCommerceApi.Services.UrlRecord;

namespace nopCommerceApi.Controllers.UrlRecord
{
    /// <summary>
    /// UrlRecord is used to store SEO-friendly URLs for entities with an SEO category.
    /// </summary>
    [Route("api/url-records")]
    [ApiController]
    public class UrlRecordController : ControllerBase
    {
        private readonly IUrlRecordService _urlRecordService;

        public UrlRecordController(IUrlRecordService urlRecordService)
        {
            _urlRecordService = urlRecordService;
        }

        /// <summary>
        /// Get all url records
        /// </summary>
        /// <remarks>
        /// UrlRecord is used to store SEO-friendly URLs for entities with an SEO category.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var urlRecords = await _urlRecordService.GetAllAsync();
            return Ok(urlRecords);
        }

        /// <summary>
        /// Get url record by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var urlRecord = await _urlRecordService.GetByIdAsync(id);
            return Ok(urlRecord);
        }

        /// <summary>
        /// Create url record
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UrlRecordCreateDto urlRecordCreateDto)
        {
            var urlRecord = await _urlRecordService.CreateAsync(urlRecordCreateDto);
            return Created("url-records", urlRecord);
        }


        /// <summary>
        /// Update url record
        /// </summary>
        [HttpPut("update/product/{entityId}/entity-name/{entityName}")]
        public async Task<IActionResult> Update([FromBody] UrlRecordUpdateDto urlRecordUpdateDto)
        {
            await _urlRecordService.UpdateAsync(urlRecordUpdateDto);

            return Ok(urlRecordUpdateDto);
        }

        /// <summary>
        /// Delete url record
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _urlRecordService.DeleteAsync(id);
            return Ok();
        }

    }
}
