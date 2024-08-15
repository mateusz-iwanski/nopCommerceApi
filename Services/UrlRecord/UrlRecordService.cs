using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.UrlRecord;
using System.Diagnostics.Eventing.Reader;

namespace nopCommerceApi.Services.UrlRecord
{
    public interface IUrlRecordService
    {
        Task<UrlRecordDto> CreateAsync(UrlRecordCreateDto urlRecordCreateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<UrlRecordDto>> GetAllAsync();
        Task<UrlRecordDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(UrlRecordUpdateDto urlRecordUpdateDto);
        Task<UrlRecordDto> GetByEntityIdAsync(int entityId);
    }

    public class UrlRecordService : BaseService, IUrlRecordService
    {
        public UrlRecordService(NopCommerceContext context, IMapper mapper, ILogger<UrlRecordService> logger) : base(context, mapper, logger)
        {
        }

        // get all url records
        public async Task<IEnumerable<UrlRecordDto>> GetAllAsync()
        {
            var urlRecords = await _context.UrlRecords
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<UrlRecordDto>>(urlRecords);
        }

        // get url record by id
        public async Task<UrlRecordDto> GetByIdAsync(int id)
        {
            var urlRecord = await _context.UrlRecords
                .FindAsync(id);

            if (urlRecord == null)
            {
                throw new NotFoundExceptions($"The url record with id {id} was not found.");
            }

            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // get by EntityId
        public async Task<UrlRecordDto> GetByEntityIdAsync(int entityId)
        {
            var urlRecord = await _context.UrlRecords
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EntityId == entityId);

            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // create url record
        public async Task<UrlRecordDto> CreateAsync(UrlRecordCreateDto urlRecordCreateDto)
        {
            var urlRecord = _mapper.Map<Entities.Usable.UrlRecord>(urlRecordCreateDto);

            _context.UrlRecords.Add(urlRecord);

            await _context.SaveChangesAsync();

            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // update url record
        public async Task<bool> UpdateAsync(UrlRecordUpdateDto urlRecordUpdateDto)
        {
            var urlRecord = await _context.UrlRecords.FindAsync(urlRecordUpdateDto.Id);

            _mapper.Map(urlRecordUpdateDto, urlRecord);

            await _context.SaveChangesAsync();

            return true;
        }

        // delete url record
        public async Task<bool> DeleteAsync(int id)
        {
            var urlRecord = await _context.UrlRecords.FindAsync(id);
            if (urlRecord == null)
            {
                throw new NotFoundExceptions($"The url record with id {id} was not found.");
            }

            _context.UrlRecords.Remove(urlRecord);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
