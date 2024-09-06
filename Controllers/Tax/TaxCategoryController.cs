

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.TaxCategory;
using nopCommerceApi.Services;
//using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers.TaxCategory
{
    /// <summary>
    /// Controller for tax category operations
    /// </summary>
    [Route("api/taxcategory")]
    [ApiController]
    public class TaxCategoryController : ControllerBase
    {
        private readonly ITaxCategoryService _taxCategoryService;
        public TaxCategoryController(ITaxCategoryService taxCategoryService)
        {
            _taxCategoryService = taxCategoryService;
        }

        /// <summary>
        /// Get all tax categories
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<IEnumerable<TaxCategoryDto>>> GetAll()
        {
            var taxCategories = await _taxCategoryService.GetAll();

            return Ok(taxCategories);
        }

        /// <summary>
        /// Get tax category by name
        /// </summary>
        [HttpGet("{name}")]
        public async Task<ActionResult<TaxCategoryDto>> GetByName(string name)
        {
            var taxCategory = await _taxCategoryService.GetByNameAsync(name);
            return Ok(taxCategory);
        }



    }
}
