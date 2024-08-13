using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Country;

namespace nopCommerceApi.Services.Country
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAll();
    }

    public class CountryService : BaseService, ICountryService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CountryService(
            NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public IEnumerable<CountryDto> GetAll()
        {
            var countries = _context.Countries.ToList();
            var countryDtos = _mapper.Map<List<CountryDto>>(countries);

            return countryDtos;
        }
    }
}
