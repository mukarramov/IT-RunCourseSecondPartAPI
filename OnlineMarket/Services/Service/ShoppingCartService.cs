using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ShoppingCartService(
    IShoppingCartRepository shoppingCartRepository,
    IMapper mapper,
    ILogger<ShoppingCart> logger) : IShoppingCartService
{
    public ShoppingCartResponse Add(ShoppingCartCreate shoppingCartCreate)
    {
        var shoppingCart = mapper.Map<ShoppingCart>(shoppingCartCreate);

        shoppingCart.User = shoppingCartRepository.GetUserById(shoppingCartCreate.UserId);

        shoppingCartRepository.Add(shoppingCart);

        return mapper.Map<ShoppingCartResponse>(shoppingCart);
    }

    public IEnumerable<ShoppingCartResponse> GetAll()
    {
        return shoppingCartRepository.GetAll().ToList()
            .Select(mapper.Map<ShoppingCartResponse>);
    }

    public ShoppingCartResponse Update(Guid id, ShoppingCartCreate shoppingCartCreate)
    {
        var shoppingCart = shoppingCartRepository.GetById(id);

        var user = shoppingCartRepository.GetUserById(shoppingCartCreate.UserId);

        shoppingCart.Id = id;
        shoppingCart.UserId = user.Id;
        shoppingCart.User = user;

        shoppingCartRepository.Update(shoppingCart);

        logger.LogInformation("update {shoppingCart} successfully passed", shoppingCart);

        return mapper.Map<ShoppingCartResponse>(shoppingCart);
    }

    public ShoppingCartResponse Delete(Guid id)
    {
        return mapper.Map<ShoppingCartResponse>
            (shoppingCartRepository.GetById(id));
    }

    public ShoppingCartResponse GetById(Guid id)
    {
        return mapper.Map<ShoppingCartResponse>
            (shoppingCartRepository.GetById(id));
    }
}