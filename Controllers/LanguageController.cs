using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models;
using nopCommerceApi.Services;

namespace nopCommerceApi.Controllers
{
    [Route("api/language")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User,Viewer")]
        public ActionResult<LanguageDto> GetAll()
        {
            var languageDtos = _languageService.GetAll();
            return Ok(languageDtos);
        }
    }
}
