using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFirstRun.Entity;

[Table("product_category")]
// By default: ProductCategories
public class ProductCategory
{
    [Column("id")] // Configuration
    // By default: Id : Convention
    [Key] // Configuration
    public int Id { get; set; }

    public string Name { get; set; }
    
    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
