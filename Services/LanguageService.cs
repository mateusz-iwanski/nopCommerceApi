using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface ILanguageService
    {
        IEnumerable<LanguageDto> GetAll();
    }

    public class LanguageService : ILanguageService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public LanguageService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LanguageDto> GetAll()
        {
            var languages = _context.Languages.ToList();
            var languageDtos = _mapper.Map<List<LanguageDto>>(languages);

            return languageDtos;
        }
    }
}
