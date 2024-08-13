using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Category;
using nopCommerceApi.Models.Manufacturer;

namespace nopCommerceApi.Services.Category
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CategoryCreateDto createCategoryDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> UpdateAsync(CategoryUpdateDto updateCategoryDto);
    }

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(NopCommerceContext context, IMapper mapper, ILogger<CategoryService> logger) : base(context, mapper, logger) { }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return categoryDtos;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) throw new NotFoundExceptions($"Category with id {id} not found");

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<CategoryDto> CreateAsync(CategoryCreateDto createCategoryDto)
        {
            var category = _mapper.Map<Entities.Usable.Category>(createCategoryDto);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto updateCategoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updateCategoryDto.Id);

            updateCategoryDto.CreatedOnUtc = category.CreatedOnUtc;

            _mapper.Map(updateCategoryDto, category);

            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) throw new NotFoundExceptions($"Category with id {id} not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
