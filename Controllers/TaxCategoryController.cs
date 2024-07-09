

using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;
using nopCommerceApi.Services;
//using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/taxcategory")]
    public class TaxCategoryController : ControllerBase
    {
        private readonly ITaxCategoryService _taxCategoryService;
        public TaxCategoryController(ITaxCategoryService taxCategoryService)
        {
            _taxCategoryService = taxCategoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.TaxCategoryDto>> GetAll()
        {
            var taxCategories = _taxCategoryService.GetAll();

            return Ok(taxCategories);
        }
    }
}
