using Microsoft.AspNetCore.Mvc;
using HelpStockApp.Application.DTOs;
using HelpStockApp.Application.Interfaces;
using HelpStockApp.Application.Services;

namespace HelpStockApp.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.Add(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Id not Found");
            }

            if (categoryDto == null)
            {
                return BadRequest("Error 500");
            }

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("The category delete not found");
            }

            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}