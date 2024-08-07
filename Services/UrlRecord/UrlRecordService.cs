using AutoMapper;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.UrlRecord;
using System.Diagnostics.Eventing.Reader;

namespace nopCommerceApi.Services.UrlRecord
{
    public interface IUrlRecordService
    {
        UrlRecordDto Create(UrlRecordCreateDto urlRecordCreateDto);
        bool Delete(int id);
        IEnumerable<UrlRecordDto> GetAll();
        UrlRecordDto GetById(int id);
        bool Update(int id, UrlRecordUpdateDto urlRecordUpdateDto);
        UrlRecordDto GetByEntityId(int entityId);
    }

    public class UrlRecordService : BaseService, IUrlRecordService
    {
        public UrlRecordService(NopCommerceContext context, IMapper mapper, ILogger<UrlRecordService> logger) : base(context, mapper, logger)
        {
        }

        // get all url records
        public IEnumerable<UrlRecordDto> GetAll()
        {
            var urlRecords = _context.UrlRecords.ToList();

            return _mapper.Map<IEnumerable<UrlRecordDto>>(urlRecords);
        }

        // get url record by id
        public UrlRecordDto GetById(int id)
        {
            var urlRecord = _context.UrlRecords.Find(id);
            if (urlRecord == null)
            {
                throw new NotFoundExceptions($"The url record with id {id} was not found.");
            }

            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // get by EntityId
        public UrlRecordDto GetByEntityId(int entityId)
        {
            var urlRecord = _context.UrlRecords.FirstOrDefault(x => x.EntityId == entityId);
            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // create url record
        public UrlRecordDto Create(UrlRecordCreateDto urlRecordCreateDto)
        {
            var urlRecord = _mapper.Map<Entities.Usable.UrlRecord>(urlRecordCreateDto);

            _context.UrlRecords.Add(urlRecord);
            _context.SaveChanges();

            return _mapper.Map<UrlRecordDto>(urlRecord);
        }

        // update url record
        public bool Update(int id, UrlRecordUpdateDto urlRecordUpdateDto)
        {
            var urlRecord = _context.UrlRecords.Find(id);
            if (urlRecord == null)
            {
                throw new NotFoundExceptions($"The url record with id {id} was not found.");
            }

            _mapper.Map(urlRecordUpdateDto, urlRecord);
            _context.SaveChanges();

            return true;
        }

        // delete url record
        public bool Delete(int id)
        {
            var urlRecord = _context.UrlRecords.Find(id);
            if (urlRecord == null)
            {
                throw new NotFoundExceptions($"The url record with id {id} was not found.");
            }

            _context.UrlRecords.Remove(urlRecord);
            _context.SaveChanges();

            return true;
        }
    }
}
