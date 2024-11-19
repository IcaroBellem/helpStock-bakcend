using AutoMapper;
using HelpStockApp.Application.DTOs;
using HelpStockApp.Application.Interfaces;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Interfaces;

namespace HelpStockApp.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoryEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity);
        }
    }
}