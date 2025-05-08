using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class ProductRepository : IProductRepository
{
    public static readonly List<Product> Products = [];

    public Product Create(Product product)
    {
        var categories = CategoryRepository.Categories;

        var lookForCategory = categories.SingleOrDefault(x => x.Id == product.CategoryId);
        if (lookForCategory == null)
        {
            throw new($"the product category with id: {product.CategoryId} does not exist!");
        }

        product.CategoryId = lookForCategory.Id;
        product.Category = lookForCategory;

        Products.Add(product);

        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        return Products;
    }

    public Product Update(Product product)
    {
        var lookForProduct = Products.SingleOrDefault(x => x.Id == product.Id);

        if (lookForProduct == null)
        {
            throw new($"the product with id: {product.Id} does not exist!");
        }

        var categories = CategoryRepository.Categories;

        var lookForCategory = categories.SingleOrDefault(x => x.Id == product.CategoryId);
        if (lookForCategory == null)
        {
            throw new($"the product category with id: {product.CategoryId} does not exist!");
        }

        lookForProduct.Id = product.Id;
        lookForProduct.Name = product.Name;
        lookForProduct.Price = product.Price;
        lookForProduct.CategoryId = lookForCategory.Id;
        lookForProduct.Category = lookForCategory;

        return lookForProduct;
    }

    public bool Delete(int productId)
    {
        var lookForProduct = Products.SingleOrDefault(x => x.Id == productId);

        if (lookForProduct == null)
        {
            throw new($"the product with id: {productId} does not exist!");
        }

        Products.Remove(lookForProduct);

        return true;
    }
}