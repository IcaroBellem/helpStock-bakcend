using HelpStockApp.Domain.Interfaces;
using HelpStockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using HelpStockApp.Domain.Entities;

namespace HelpStockApp.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository 
    {
        private ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }   
        
        public async Task<Category> GetById(int? id) 
        {
            var category = await _categoryContext.Categories.FindAsync(id);
            return category;
        }
        public async Task<IEnumerable<Category>> GetCategories() 
        {
         return await _categoryContext.Categories.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
