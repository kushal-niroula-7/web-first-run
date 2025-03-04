using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFirstRun.Data;
using WebFirstRun.Entity;
using WebFirstRun.ViewModels.ProductVms;

namespace WebFirstRun.Controllers;

public class ProductController : Controller
{
    private readonly FirstRunDbContext dbContext;

    public ProductController(FirstRunDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // Create Product Form
    public async Task<IActionResult> Create()
    {
        var productCategories = await dbContext.ProductCategories
            .OrderBy(x => x.Name)
            // .OrderByDescending(x => x.Name)
            .ToListAsync();
        var vm = new CreateProductVm();
        vm.ProductCategories = productCategories;
        return View(vm);
    }

    // Db handling action
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVm vm)
    {
        try
        {
            // Check for valiation errors
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Check for name uniqueness


            // Create new product

            var productCategory = await dbContext.ProductCategories.Where(x => x.Id == vm.ProductCategoryId).FirstOrDefaultAsync();

            if (productCategory == null)
            {
                throw new Exception("Product Category not found");
            }

            var product = new Product();
            product.Name = vm.Name;
            product.Category = productCategory;
            product.Description = vm.Description;

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            // Do something
            // Usually send error resposne to view
            return BadRequest(e.Message);
        }
    }

    // Create Product Form
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            var productCategories = await dbContext.ProductCategories
                        .OrderBy(x => x.Name)
                        // .OrderByDescending(x => x.Name)
                        .ToListAsync();

            var product = await dbContext.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (product == null)
            {
               throw new Exception("Product not found");
            }

            var vm = new UpdateProductVm();
            vm.ProductCategories = productCategories;

            vm.Name = product.Name;
            vm.ProductCategoryId = product.Category.Id;
            vm.Description = product.Description;

            return View(vm);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }


    }

    // Db handling action
    [HttpPost]
    public async Task<IActionResult> Update(int id, CreateProductVm vm)
    {
        try
        {
            // Check for valiation errors
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Check for name uniqueness


            // Create new product

            var productCategory = await dbContext.ProductCategories.Where(x => x.Id == vm.ProductCategoryId).FirstOrDefaultAsync();

            if (productCategory == null)
            {
                throw new Exception("Product Category not found");
            }

            var product = await dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = vm.Name;
            product.Category = productCategory;
            product.Description = vm.Description;

            dbContext.Products.Update(product);

            await dbContext.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            // Do something
            // Usually send error resposne to view
            return BadRequest(e.Message);
        }
    }
}
