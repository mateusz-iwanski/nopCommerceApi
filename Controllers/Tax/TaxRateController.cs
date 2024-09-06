using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Tax;
using nopCommerceApi.Services.Tax;

namespace nopCommerceApi.Controllers.Tax
{
    /// <summary>
    /// Controller for tax rate operations
    /// </summary>
    [Route("api/taxrate")]
    [ApiController]
    public class TaxRateController : ControllerBase
    {
        private readonly ITaxRateService _taxRateService;

        public TaxRateController(ITaxRateService taxRateService)
        {
            _taxRateService = taxRateService;
        }

        /// <summary>
        /// Get all tax rates
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxRateDto>>> GetAll()
        {
            var taxRates = await _taxRateService.GetAllAsync();
            return Ok(taxRates);
        }

        /// <summary>
        /// Get tax rate by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxRateDto>> GetById(int id)
        {
            var taxRate = await _taxRateService.GetByIdAsync(id);
            return Ok(taxRate);
        }

        /// <summary>
        /// Get tax rate by percentage
        /// </summary>
        [HttpGet("percentage/{percentage}")]
        public async Task<ActionResult<IEnumerable<TaxRateDto>>> GetByPercentage(decimal percentage)
        {
            var taxRate = await _taxRateService.GetByPercentageAsync(percentage);
            return Ok(taxRate);
        }

        //GetByTaxCategoryIdAsync
        [HttpGet("taxcategory/{taxCategoryId}")]
        public async Task<ActionResult<IEnumerable<TaxRateDto>>> GetByTaxCategoryId(int taxCategoryId)
        {
            var taxRate = await _taxRateService.GetByTaxCategoryIdAsync(taxCategoryId);
            return Ok(taxRate);
        }

    }
}
