

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;
//using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
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
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<IEnumerable<Models.TaxCategoryDto>> GetAll()
        {
            var taxCategories = _taxCategoryService.GetAll();

            return Ok(taxCategories);
        }
    }
}
