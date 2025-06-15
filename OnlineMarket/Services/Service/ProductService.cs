using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ProductService(IProductRepository productRepository, IMapper mapper, ILogger<Product> logger)
    : IProductService
{
    public ProductResponse? Add(ProductCreate productCreate)
    {
        if (string.IsNullOrEmpty(productCreate.Name))
        {
            throw new Exception();
        }
        
        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);
        if (categoryById is null)
        {
            return null;
        }

        var product = mapper.Map<Product>(productCreate);

        product.CategoryId = categoryById.Id;
        product.Category = categoryById;

        productRepository.Add(product);

        return mapper.Map<ProductResponse>(product);
    }

    public IEnumerable<ProductResponse> GetAll()
    {
        return productRepository.GetAll()
            .Select(mapper.Map<ProductResponse>);
    }

    public ProductResponse? Update(Guid id, ProductCreate productCreate)
    {
        var product = productRepository.GetById(id);
        if (product is null)
        {
            return null;
        }

        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);
        if (categoryById is null)
        {
            return null;
        }

        var map = mapper.Map(productCreate, product);

        map.Id = id;
        map.CategoryId = categoryById.Id;
        map.Category = categoryById;

        productRepository.Update(map);

        logger.LogInformation("update {product} successfully passed", product);

        return mapper.Map<ProductResponse>(map);
    }

    public ProductResponse? Delete(Guid id)
    {
        var product = productRepository.Delete(id);

        return product is null ? null : mapper.Map<ProductResponse>(product);
    }

    public ProductResponse? GetById(Guid id)
    {
        var product = productRepository.GetById(id);

        return product is null ? null : mapper.Map<ProductResponse>(product);
    }
}