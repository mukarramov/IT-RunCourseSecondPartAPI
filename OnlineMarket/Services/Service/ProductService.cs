using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public ProductResponse Add(ProductCreate productCreate)
    {
        if (string.IsNullOrEmpty(productCreate.Name))
        {
            throw new Exception();
        }

        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);

        var product = new Product
        {
            Name = productCreate.Name,
            Description = productCreate.Description,
            Price = productCreate.Price,
            CategoryId = productCreate.CategoryId,
            Category = categoryById
        };

        productRepository.Add(product);

        var productResponse = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Category = product.Category
        };

        return productResponse;
    }

    public IEnumerable<ProductResponse> GetAll()
    {
        var products = productRepository.GetAll();

        var productResponse = products.Select(product => new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Category = product.Category
        });

        return productResponse;
    }

    public ProductResponse Update(Guid id, ProductCreate productCreate)
    {
        var product = productRepository.GetById(id);

        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);

        product.Name = productCreate.Name;
        product.Description = productCreate.Description;
        product.Price = productCreate.Price;
        product.CategoryId = categoryById.Id;
        product.Category = categoryById;

        var productResponse = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Category = product.Category
        };

        return productResponse;
    }

    public ProductResponse Delete(Guid id)
    {
        var product = productRepository.Delete(id);

        var productResponse = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Category = product.Category
        };

        return productResponse;
    }

    public ProductResponse GetById(Guid id)
    {
        var product = productRepository.GetById(id);

        var productResponse = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Category = product.Category
        };

        return productResponse;
    }
}