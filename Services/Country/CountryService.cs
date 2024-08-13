using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Country;

namespace nopCommerceApi.Services.Country
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }

    public class CountryService : BaseService, ICountryService
    {
        public CountryService(
            NopCommerceContext context, IMapper mapper, ILogger<CountryService> logger
            ) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            var countryDtos = _mapper.Map<List<CountryDto>>(countries);

            return countryDtos;
        }
    }
}
