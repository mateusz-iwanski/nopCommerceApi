using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.State;

namespace nopCommerceApi.Services
{
    public interface IStateProvinceService
    {
        IEnumerable<StateProvinceDto> GetAll();
    }

    public class StateProvinceService : BaseService, IStateProvinceService
    {
        private readonly NopCommerceContext _context;
        private readonly IMapper _mapper;

        public StateProvinceService(NopCommerceContext context, IMapper mapper, ILogger<AddressAttributeService> logger
            ) : base(context, mapper, logger)
        {
        }

        /// <summary>
        /// Get all state provinces with details
        /// </summary>
        public IEnumerable<StateProvinceDto> GetAll()
        {
            var stateProvince = _context
                .StateProvinces
                .Include(c => c.Country)
                .ToList();

            var stateProvinceDtos = _mapper.Map<List<StateProvinceDto>>(stateProvince);

            return stateProvinceDtos;
        }
    }
}
