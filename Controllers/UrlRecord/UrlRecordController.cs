using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.UrlRecord;
using nopCommerceApi.Services.UrlRecord;

namespace nopCommerceApi.Controllers.UrlRecord
{
    [Route("url-records")]
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var urlRecords = _urlRecordService.GetAll();
            return Ok(urlRecords);
        }

        /// <summary>
        /// Get url record by id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var urlRecord = _urlRecordService.GetById(id);
            return Ok(urlRecord);
        }

        /// <summary>
        /// Create url record
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] UrlRecordCreateDto urlRecordCreateDto)
        {
            var urlRecord = _urlRecordService.Create(urlRecordCreateDto);
            return Created("url-records", urlRecord);
        }


        /// <summary>
        /// Update url record
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UrlRecordUpdateDto urlRecordUpdateDto)
        {
            _urlRecordService.Update(id, urlRecordUpdateDto);
            
            return Ok(urlRecordUpdateDto);
        }

        /// <summary>
        /// Delete url record
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _urlRecordService.Delete(id);
            return Ok();
        }
        
    }
}
