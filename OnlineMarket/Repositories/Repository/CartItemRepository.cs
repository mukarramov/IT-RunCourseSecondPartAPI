using IT_RunCourseSecondPartAPI.Data;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_RunCourseSecondPartAPI.Repositories.Repository;

public class CartItemRepository(AppDbContext context, ILogger<CartItem> logger) : ICartItemRepository
{
    public CartItem Add(CartItem cartItem)
    {
        context.CartItems.Add(cartItem);
        context.SaveChanges();

        return cartItem;
    }

    public IEnumerable<CartItem> GetAll()
    {
        return context.CartItems.Include(x => x.Product).ThenInclude(x => x!.Category)
            .Include(x => x.ShoppingCart);
    }

    public CartItem Update(CartItem cartItem)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == cartItem.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            throw new NullReferenceException();
        }

        context.CartItems.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public CartItem Delete(Guid id)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            throw new NullReferenceException();
        }

        context.CartItems.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public CartItem GetById(Guid id)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            throw new NullReferenceException();
        }

        return firstOrDefault;
    }

    public Product GetProductById(Guid id)
    {
        var firstOrDefault = context.Products.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {product}", firstOrDefault);

            throw new NullReferenceException();
        }

        return firstOrDefault;
    }

    public ShoppingCart GetShoppingCartById(Guid id)
    {
        var firstOrDefault = context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {shoppingCart}", firstOrDefault);

            throw new NullReferenceException();
        }

        return firstOrDefault;
    }
}