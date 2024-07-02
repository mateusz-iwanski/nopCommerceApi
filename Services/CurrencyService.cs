using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    public interface ICurrencyService
    {
        IEnumerable<CurrencyDto> GetAll();
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public CurrencyService(NopCommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CurrencyDto> GetAll()
        {
            var currencies = _context.Currencies.ToList();
            var currencyDtos = _mapper.Map<List<CurrencyDto>>(currencies);

            return currencyDtos;
        }
    }
}
