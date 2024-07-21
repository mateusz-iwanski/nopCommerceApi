using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Models;

namespace nopCommerceApi.Services
{
    /// <summary>
    /// Class for the base service with the logger
    /// 
    /// If service inherits from this class, it will have access to the logger .
    /// </summary>
    public abstract class BaseService
    {
        protected readonly NopCommerceContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        protected BaseService(NopCommerceContext context, IMapper mapper, ILogger logger)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
    }
}
