using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.DelivaeryDate;

namespace nopCommerceApi.Services.DeliveryDayte
{
    public interface IDeliveryDateService
    {
        Task<DeliveryDateDto> CreateAsync(DeliveryDateCreateDto createDeliveryDateDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<DeliveryDateDto>> GetAllAsync();
        Task<DeliveryDateDto> GetByIdAsync(int id);
        Task<DeliveryDateDto> UpdateAsync(DeliveryDateUpdateDto updateDeliveryDateDto);
    }

    public class DeliveryDateService : BaseService, IDeliveryDateService
    {
        public DeliveryDateService(NopCommerceContext context, IMapper mapper, ILogger<DeliveryDateService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<DeliveryDateDto>> GetAllAsync()
        {
            var deliveryDates = await _context.DeliveryDates
                .AsNoTracking()
                .ToListAsync();
            var deliveryDateDtos = _mapper.Map<List<DeliveryDateDto>>(deliveryDates);

            return deliveryDateDtos;
        }

        public async Task<DeliveryDateDto> GetByIdAsync(int id)
        {
            var deliveryDate = await _context.DeliveryDates
                .AsNoTracking()
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (deliveryDate == null) throw new NotFoundExceptions($"Delivery date with id {id} not found");

            var deliveryDateDto = _mapper.Map<DeliveryDateDto>(deliveryDate);

            return deliveryDateDto;
        }

        public async Task<DeliveryDateDto> CreateAsync(DeliveryDateCreateDto createDeliveryDateDto)
        {
            var deliveryDate = _mapper.Map<DeliveryDate>(createDeliveryDateDto);

            _context.DeliveryDates.Add(deliveryDate);
            await _context.SaveChangesAsync();

            var deliveryDateDto = _mapper.Map<DeliveryDateDto>(deliveryDate);

            return deliveryDateDto;
        }

        public async Task<DeliveryDateDto> UpdateAsync(DeliveryDateUpdateDto updateDeliveryDateDto)
        {
            var deliveryDate = await _context.DeliveryDates.FirstOrDefaultAsync(dd => dd.Id == updateDeliveryDateDto.Id);

            _mapper.Map(updateDeliveryDateDto, deliveryDate);

            _context.DeliveryDates.Update(deliveryDate);

            await _context.SaveChangesAsync();

            var deliveryDateDto = _mapper.Map<DeliveryDateDto>(deliveryDate);

            return deliveryDateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deliveryDate = await _context.DeliveryDates
                .AsNoTracking()
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (deliveryDate == null) throw new NotFoundExceptions($"Delivery date with id {id} not found");

            _context.DeliveryDates.Remove(deliveryDate);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
