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
    public CartItemResponse Add(CartItemCreate cartItemCreate)
    {
        var cartItem = mapper.Map<CartItem>(cartItemCreate);

        var productById = cartItemRepository.GetProductById(cartItemCreate.ProductId);
        var shoppingCartById = cartItemRepository.GetShoppingCartById(cartItemCreate.ShoppingCartId);

        cartItem.Product = productById;
        cartItem.ShoppingCart = shoppingCartById;

        cartItemRepository.Add(cartItem);

        return mapper.Map<CartItemResponse>(cartItem);
    }

    public IEnumerable<CartItemResponse> GetAll()
    {
        var cartItems = cartItemRepository.GetAll();

        return cartItems.Select(mapper.Map<CartItemResponse>);
    }

    public CartItemResponse Update(Guid id, CartItemCreate cartItemCreate)
    {
        var cartItem = cartItemRepository.GetById(id);

        var productById = cartItemRepository.GetProductById(cartItemCreate.ProductId);
        var shoppingCartById = cartItemRepository.GetShoppingCartById(cartItemCreate.ShoppingCartId);

        cartItem.Id = id;
        cartItem.Product = productById;
        cartItem.ShoppingCart = shoppingCartById;

        cartItemRepository.Update(cartItem);

        logger.LogInformation("update {cartItem} successfully passed", cartItem);

        return mapper.Map<CartItemResponse>(mapper.Map(cartItemCreate, cartItem));
    }

    public CartItemResponse Delete(Guid id)
    {
        return mapper.Map<CartItemResponse>(cartItemRepository.Delete(id));
    }

    public CartItemResponse GetById(Guid id)
    {
        return mapper.Map<CartItemResponse>(cartItemRepository.GetById(id));
    }
}