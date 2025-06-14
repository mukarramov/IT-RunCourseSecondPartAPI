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

        var product = mapper.Map<Product>(productCreate);

        product.CategoryId = categoryById.Id;
        product.Category = categoryById;

        productRepository.Add(product);

        return mapper.Map<ProductResponse>(product);
    }

    public IEnumerable<ProductResponse> GetAll()
    {
        return productRepository.GetAll().ToList()
            .Select(mapper.Map<ProductResponse>);
    }

    public ProductResponse Update(Guid id, ProductCreate productCreate)
    {
        var product = productRepository.GetById(id);

        var categoryById = productRepository.GetCategoryById(productCreate.CategoryId);

        var map = mapper.Map(productCreate, product);

        map.Id = id;
        map.CategoryId = categoryById.Id;
        map.Category = categoryById;

        productRepository.Update(map);

        return mapper.Map<ProductResponse>(map);
    }

    public ProductResponse Delete(Guid id)
    {
        return mapper.Map<ProductResponse>(productRepository.Delete(id));
    }

    public ProductResponse GetById(Guid id)
    {
        return mapper.Map<ProductResponse>(productRepository.GetById(id));
    }
}