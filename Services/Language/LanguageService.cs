using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Language;

namespace nopCommerceApi.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageDto>> GetAllAsync();
    }

    public class LanguageService : BaseService, ILanguageService
    {
        public LanguageService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<LanguageDto>> GetAllAsync()
        {
            var languages = await _context.Languages
                .AsNoTracking()
                .ToListAsync();

            var languageDtos = _mapper.Map<List<LanguageDto>>(languages);

            return languageDtos;
        }
    }
}
