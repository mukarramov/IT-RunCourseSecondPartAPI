using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs.Requests;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Repositories.Repository;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public ProductResponse Add(ProductRequest productRequest)
    {
        if (string.IsNullOrEmpty(productRequest.Name))
        {
            throw new Exception();
        }

        var categoryById = productRepository.GetCategoryById(productRequest.CategoryId);

        var product = new Product
        {
            Name = productRequest.Name,
            Description = productRequest.Description,
            Price = productRequest.Price,
            CategoryId = productRequest.CategoryId,
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

    public ProductResponse Update(Guid id, ProductRequest productRequest)
    {
        var product = productRepository.GetById(id);

        var categoryById = productRepository.GetCategoryById(productRequest.CategoryId);

        var map = mapper.Map(productRequest, product);

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