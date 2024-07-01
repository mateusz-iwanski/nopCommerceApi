

using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
//using nopCommerceApi.Models;

namespace nopCommerceApi.Controllers
{
    [Route("api/taxcategory")]
    public class TaxCategoryController : ControllerBase
    {
        private readonly NopCommerceContext _context;
        public TaxCategoryController(NopCommerceContext context)
        {
           _context = context;
        }

        public ActionResult<IEnumerable<TaxCategory>> GetAll()
        {
            var taxCategories = _context.TaxCategories.ToList();
            return Ok(taxCategories);
        }
    }
}
