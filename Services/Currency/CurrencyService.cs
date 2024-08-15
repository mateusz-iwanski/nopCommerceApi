using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services.Currency
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetAllAsync();
    }

    public class CurrencyService : BaseService, ICurrencyService
    {
        public CurrencyService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllAsync()
        {
            var currencies = await _context.Currencies
                .AsNoTracking()
                .ToListAsync();

            var currencyDtos = _mapper.Map<List<CurrencyDto>>(currencies);

            return currencyDtos;
        }
    }
}
