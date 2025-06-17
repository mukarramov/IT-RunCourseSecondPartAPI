using Application.Repositories.Interface;
using Domain.Models;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Repository;

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
            .Include(x => x.ShoppingCart).ToList();
    }

    public CartItem? Update(CartItem cartItem)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == cartItem.Id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            return null;
        }

        context.CartItems.Update(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public CartItem? Delete(Guid id)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            return null;
        }

        context.CartItems.Remove(firstOrDefault);
        context.SaveChanges();

        return firstOrDefault;
    }

    public CartItem? GetById(Guid id)
    {
        var firstOrDefault = context.CartItems.FirstOrDefault(x => x.Id == id);
        if (firstOrDefault is null)
        {
            logger.LogError("can not found the {cartItem}", firstOrDefault);

            return null;
        }

        return firstOrDefault;
    }
}