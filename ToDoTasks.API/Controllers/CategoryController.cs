using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTasks.Core.DTOs;
using ToDoTasks.Core.Entities;
using ToDoTasks.Core.Interfaces;

namespace ToDoTasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService  categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Category>> GetCategories()
        {
            var categories = _categoryService.GetAllCategories();
            var categoriesDto = _mapper.Map<IEnumerable<Category>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var categoryDto = _mapper.Map<Category>(category);
            if(categoryDto is null)
                return NotFound();
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryService.CreateCategory(category);
            categoryDto = _mapper.Map<CategoryDto>(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
        {
            var getCategoryById = await _categoryService.GetCategoryById(id);
            if (getCategoryById is null)
                return NotFound();

            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;
            await _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var getCategoryById = await _categoryService.GetCategoryById(id);
            if (getCategoryById is null)
                return NotFound();

            await _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
