using System;
using WebFirstRun.Dto.ProductDtos;

namespace WebFirstRun.Services.Interfaces;

public interface IProductService
{
    // Create
    Task Create(CreateProductDto dto);
    // Update
    Task Update(int productId, UpdateProductDto dto);
}