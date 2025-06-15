using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ILogger<CartItem> logger)
    : ICartItemService
{
    public CartItemResponse? Add(CartItemCreate cartItemCreate)
    {
        var productById = cartItemRepository.GetProductById(cartItemCreate.ProductId);
        var shoppingCartById = cartItemRepository.GetShoppingCartById(cartItemCreate.ShoppingCartId);
        if (productById is null || shoppingCartById is null)
        {
            return null;
        }

        var cartItem = mapper.Map<CartItem>(cartItemCreate);

        cartItem.ProductId = productById.Id;
        cartItem.Product = productById;
        cartItem.ShoppingCartId = shoppingCartById.Id;
        cartItem.ShoppingCart = shoppingCartById;

        cartItemRepository.Add(cartItem);

        return mapper.Map<CartItemResponse>(cartItem);
    }

    public IEnumerable<CartItemResponse> GetAll()
    {
        var cartItems = cartItemRepository.GetAll();

        return cartItems.Select(mapper.Map<CartItemResponse>);
    }

    public CartItemResponse? Update(Guid id, CartItemCreate cartItemCreate)
    {
        var cartItem = cartItemRepository.GetById(id);
        var productById = cartItemRepository.GetProductById(cartItemCreate.ProductId);
        var shoppingCartById = cartItemRepository.GetShoppingCartById(cartItemCreate.ShoppingCartId);

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