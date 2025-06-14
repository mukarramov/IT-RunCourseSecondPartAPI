using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class ShoppingCartRepository(AppDbContext context, ILogger<ShoppingCart> logger) : IShoppingCartRepository
{
    public ShoppingCart Add(ShoppingCart shoppingCart)
    {
        context.ShoppingCarts.Add(shoppingCart);
        context.SaveChanges();

        return shoppingCart;
    }

    public IEnumerable<ShoppingCart> GetAll()
    {
        var includableQueryable = context.ShoppingCarts.Include(x => x.User);

        return includableQueryable;
    }

    public ShoppingCart Update(ShoppingCart shoppingCart)
    {
        var firstOrDefault = context.ShoppingCarts.FirstOrDefault(x => x.Id == shoppingCart.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {shoppingCart}", firstOrDefault);

            throw new NullReferenceException();
        }

        context.ShoppingCarts.Update(shoppingCart);
        context.SaveChanges();

        return shoppingCart;
    }

    public ShoppingCart Delete(Guid id)
    {
        var firstOrDefault = context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {shoppingCart}", firstOrDefault);

            throw new NullReferenceException();
        }

        context.ShoppingCarts.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public ShoppingCart GetById(Guid id)
    {
        var firstOrDefault = context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {shoppingCart}", firstOrDefault);

            throw new NullReferenceException();
        }

        return firstOrDefault;
    }

    public User GetUserById(Guid id)
    {
        var firstOrDefault = context.Users.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {user}", firstOrDefault);

            throw new NullReferenceException();
        }

        return firstOrDefault;
    }
}