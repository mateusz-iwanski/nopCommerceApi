using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public ActionResult<LanguageDto> GetAll()
        {
            var languageDtos = _languageService.GetAll();
            return Ok(languageDtos);
        }
    }
}
