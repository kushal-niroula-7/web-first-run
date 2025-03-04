using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebFirstRun.Entity;

namespace WebFirstRun.ViewModels.ProductVms;

public class CreateProductVm
{
    // Send from View to Controller
    public string Name { get; set; }
    public int ProductCategoryId { get; set; }
    public string Description { get; set; }

    // Send To View
    public SelectList ProductCategoriesSelectList() 
        => new SelectList(
            // List of items
            ProductCategories,
            nameof(ProductCategory.Id),
            // Displayed text
            nameof(ProductCategory.Name),
            ProductCategoryId
        );
    public List<ProductCategory> ProductCategories;
}
