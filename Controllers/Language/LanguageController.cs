using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.Language;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers.Language
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        /// <summary>
        /// Get all languages 
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Admin,User,Viewer")]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetAll()
        {
            var languageDtos = await _languageService.GetAllAsync();
            return Ok(languageDtos);
        }
    }
}
