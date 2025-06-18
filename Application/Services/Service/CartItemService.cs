using Application.Dtos.CreatedRequest;
using Application.Dtos.Response;
using Application.Repositories.Interface;
using Application.Services.Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.Service;

public class CartItemService(
    ICartItemRepository cartItemRepository,
    IProductRepository productRepository,
    IShoppingCartRepository shoppingCartRepository,
    IMapper mapper,
    ILogger<CartItem> logger)
    : ICartItemService
{
    public CartItemResponse? Add(CartItemCreate cartItemCreate)
    {
        var productById = productRepository.GetById(cartItemCreate.ProductId);
        var shoppingCartById = shoppingCartRepository.GetById(cartItemCreate.ShoppingCartId);
        if (productById is null || shoppingCartById is null)
        {
            return null;
        }

        var cartItem = mapper.Map<CartItem>(cartItemCreate);

        var item = cartItemRepository.GetAll().FirstOrDefault(x =>
            x.ProductId == cartItemCreate.ProductId && x.ShoppingCartId == cartItemCreate.ShoppingCartId);

        var map = mapper.Map(item, cartItem);
        if (item is not null)
        {
            if (map.Product != null)
            {
                map.Quantity++;
                var sum = map.Quantity * map.Product.Price;
                map.TotalPrice = sum;
            }

            cartItemRepository.Update(map);
            shoppingCartById.TotalPrice += map.TotalPrice;
            shoppingCartById.CartItems?.Add(map);
            shoppingCartRepository.Update(shoppingCartById);

            return mapper.Map<CartItemResponse>(cartItem);
        }

        cartItem.ProductId = productById.Id;
        cartItem.Product = productById;
        cartItem.ShoppingCartId = shoppingCartById.Id;
        cartItem.ShoppingCart = shoppingCartById;

        shoppingCartById.TotalPrice += cartItem.TotalPrice;
        shoppingCartById.CartItems?.Add(cartItem);

        cartItemRepository.Add(map);
        shoppingCartRepository.Update(shoppingCartById);

        return mapper.Map<CartItemResponse>(map);
    }

    public IEnumerable<CartItemResponse> GetAll()
    {
        var cartItems = cartItemRepository.GetAll();

        return cartItems.Select(mapper.Map<CartItemResponse>);
    }

    public CartItemResponse? Update(Guid id, CartItemCreate cartItemCreate)
    {
        var cartItem = cartItemRepository.GetById(id);
        var productById = productRepository.GetById(cartItemCreate.ProductId);
        var shoppingCartById = shoppingCartRepository.GetById(cartItemCreate.ShoppingCartId);

        if (cartItem is null || productById is null || shoppingCartById is null)
        {
            return null;
        }

        cartItem.Id = id;
        cartItem.Product = productById;
        cartItem.ShoppingCart = shoppingCartById;

        cartItemRepository.Update(cartItem);

        logger.LogInformation("update {cartItem} successfully passed", cartItem);

        return mapper.Map<CartItemResponse>(mapper.Map(cartItemCreate, cartItem));
    }

    public CartItemResponse? Delete(Guid id)
    {
        var cartItem = cartItemRepository.Delete(id);

        return cartItem is null ? null : mapper.Map<CartItemResponse>(cartItem);
    }

    public CartItemResponse? GetById(Guid id)
    {
        var cartItem = cartItemRepository.GetById(id);

        return cartItem is null ? null : mapper.Map<CartItemResponse>(cartItem);
    }
}