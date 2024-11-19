using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Interfaces;
using HelpStockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _productContext;
    public ProductRepository(ApplicationDbContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<Product> Create(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetById(int? id)
    {
        var product = await _productContext.Products.FindAsync(id);
        return product;
    }
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productContext.Products.OrderBy(c => c.Id).ToListAsync();
    }
    public async Task<Product> Update(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
    public async Task<Product> DeleteCategory(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}

