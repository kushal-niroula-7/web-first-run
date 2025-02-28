using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFirstRun.Data;
using WebFirstRun.Entity;

namespace WebFirstRun.Controllers
{
    [ApiController]
    public class TestApi : ControllerBase
    {
        private readonly FirstRunDbContext dbContext;

        // Using DI
        public TestApi(FirstRunDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("/api/product-category/seed")]
        public async Task<IActionResult> SeedProductCategory()
        {
            // Prepare the object model
            // In reality: Use data from request
            var productCategory = new ProductCategory
            {
                Name = "Test Category",
                IsActive = true,
                CreatedAt = System.DateTime.UtcNow,
            };
            
            // Mark it as to be added to database\
            // We need the db context to do this

            dbContext.ProductCategories.Add(productCategory); // Marked as to be added

            // Save the changes to the database

            // dbContext.SaveChanges(); // Save the changes to the database

            await dbContext.SaveChangesAsync(); // Using the async version

            return Ok(productCategory);

        }

        // Get List
        [HttpGet("/api/product-category/")]
        public async Task<IActionResult> GetProductCategories()
        {
            // Get the list of product categories
            var productCategories = await dbContext.ProductCategories.ToListAsync();

            return Ok(productCategories);
        }

        // Update
        [HttpGet("/api/product-category/update/{id}")]
        public async Task<IActionResult> UpdateProductCategory(int id)
        {
            // Get the object from the database
            var productCategory = await dbContext.ProductCategories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(productCategory == null)
            {
                return NotFound();
            }

            // Update the object
            productCategory.Name = "Updated Name";

            // Mark it as to be updated
            dbContext.ProductCategories.Update(productCategory); // Marks for update

            // Save the changes to the database
            await dbContext.SaveChangesAsync(); // Sends the query to database

            return Ok(productCategory);
        }

        // Foreign Key handling

         [HttpGet("/api/product-category/create-sample-product/{id}")]
        public async Task<IActionResult> CreateSampleProduct(int id)
        {
            // Get the object from the database
            var productCategory = await dbContext.ProductCategories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(productCategory == null)
            {
                return NotFound();
            }
            var product = new Product();
            product.Name = "Sample Product";
            product.Description = "Sample Description";
            product.IsActive = true;
            product.CreatedAt = System.DateTime.UtcNow;
            product.Category = productCategory; // Assign the category
            
            dbContext.Products.Add(product); // Marks for Create

            // Save the changes to the database
            await dbContext.SaveChangesAsync(); // Sends the query to database

            return Ok(productCategory);
        }

        // GEt product list
        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {
            // Get the list of products
            var products = await dbContext.Products
                .ToListAsync();

            return Ok(products);
        }
    }
}
