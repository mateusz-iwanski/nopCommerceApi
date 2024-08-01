using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities;
using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Category;

namespace nopCommerceApi.Services.Category
{
    public interface ICategoryService
    {
        CategoryDto Create(CreateCategoryDto createCategoryDto);
        bool Delete(int id);
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        CategoryDto Update(int id, UpdateCategoryDto updateCategoryDto);
    }

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(NopCommerceContext context, IMapper mapper, ILogger<CategoryService> logger) : base(context, mapper, logger) { }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _context.Categories.ToList();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return categoryDtos;
        }

        public CategoryDto GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null) throw new NotFoundExceptions($"Category with id {id} not found");

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public CategoryDto Create(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Entities.Usable.Category>(createCategoryDto);

            _context.Categories.Add(category);
            _context.SaveChanges();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public CategoryDto Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null) throw new NotFoundExceptions($"Category with id {id} not found");

            updateCategoryDto.Id = id;
            updateCategoryDto.CreatedOnUtc = category.CreatedOnUtc;

            _mapper.Map(updateCategoryDto, category);

            _context.SaveChanges();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null) throw new NotFoundExceptions($"Category with id {id} not found");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return true;
        }
    }
}
