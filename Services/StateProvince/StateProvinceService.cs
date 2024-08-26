using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.State;

namespace nopCommerceApi.Services.StateProvince
{
    public interface IStateProvinceService
    {
        Task<IEnumerable<StateProvinceDto>> GetAllAsync();
    }

    public class StateProvinceService : BaseService, IStateProvinceService
    {
        public StateProvinceService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        /// <summary>
        /// Get all state provinces with details asynchronously
        /// </summary>
        public async Task<IEnumerable<StateProvinceDto>> GetAllAsync()
        {
            var stateProvince = await _context
                .StateProvinces
                .Include(c => c.Country)
                .ToListAsync();

            var stateProvinceDtos = _mapper.Map<List<StateProvinceDto>>(stateProvince);

            return stateProvinceDtos;
        }
    }
}
