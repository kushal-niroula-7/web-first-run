using System;
using Microsoft.EntityFrameworkCore;
using WebFirstRun.Data;
using WebFirstRun.Dto.ProductDtos;
using WebFirstRun.Entity;
using WebFirstRun.Services.Interfaces;

namespace WebFirstRun.Services;

public class ProductService : IProductService
{
    private readonly FirstRunDbContext dbContext;

    public ProductService(FirstRunDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task Create(CreateProductDto dto)
    {
        var product = new Product();
        product.Name = dto.Name;
        product.Category = dto.ProductCategory;
        product.Description = dto.Description;

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(int productId, UpdateProductDto dto)
    {
        var product = await dbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        product.Name = dto.Name;
        product.Category = dto.ProductCategory;
        product.Description = dto.Description;

        dbContext.Products.Update(product);

        await dbContext.SaveChangesAsync();
    }
}
