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
        protected readonly ILogger _logger;

        protected BaseService(ILogger logger)
        {
            _logger = logger;
        }
    }
}
