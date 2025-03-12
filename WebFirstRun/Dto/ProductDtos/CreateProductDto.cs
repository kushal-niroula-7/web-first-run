using System;
using WebFirstRun.Entity;

namespace WebFirstRun.Dto.ProductDtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public string Description { get; set; }

}
