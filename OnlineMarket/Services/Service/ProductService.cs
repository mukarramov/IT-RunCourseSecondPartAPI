using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
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

        return mapper.Map<ProductResponse>(product);
    }

    public IEnumerable<ProductResponse> GetAll()
    {
        var products = productRepository.GetProducts();

        return mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public ProductResponse Update(Guid id, ProductCreate productCreate)
    {
        var product = productRepository.GetById(id);

        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);

        var map = mapper.Map(productCreate, product);

        map.CategoryId = categoryById.Id;
        map.Category = categoryById;

        return mapper.Map<ProductResponse>(map);
    }

    public ProductResponse Delete(Guid id)
    {
        var product = productRepository.Delete(id);

        return mapper.Map<ProductResponse>(product);
    }

    public ProductResponse GetById(Guid id)
    {
        var product = productRepository.GetById(id);

        return mapper.Map<ProductResponse>(product);
    }
}