using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;
using IT_RunCourseSecondPartAPI.Repositories.Interface;
using IT_RunCourseSecondPartAPI.Services.Interface;

namespace IT_RunCourseSecondPartAPI.Services.Service;

public class ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMapper mapper) : IShoppingCartService
{
    public ShoppingCartResponse Add(ShoppingCartCreate shoppingCartCreate)
    {
        var shoppingCart = mapper.Map<ShoppingCart>(shoppingCartCreate);

        shoppingCart.User = shoppingCartRepository.GetUserById(shoppingCartCreate.UserId);

        shoppingCartRepository.Add(shoppingCart);

        return mapper.Map<ShoppingCartResponse>(shoppingCart);
    }

    public IQueryable<ShoppingCartResponse> GetAll()
    {
        var shoppingCartResponses = shoppingCartRepository.GetAll()
            .Select(x => mapper.Map<ShoppingCartResponse>(x));

        return shoppingCartResponses;
    }

    public ShoppingCartResponse Update(Guid id, ShoppingCartCreate shoppingCartCreate)
    {
        var shoppingCart = shoppingCartRepository.GetById(id);

        shoppingCart.User = shoppingCartRepository.GetUserById(shoppingCartCreate.UserId);

        shoppingCartRepository.Update(id, shoppingCart);

        return mapper.Map<ShoppingCartResponse>(shoppingCart);
    }

    public ShoppingCartResponse Delete(Guid id)
    {
        return mapper.Map<ShoppingCartResponse>(shoppingCartRepository.Delete(id));
    }

    public ShoppingCartResponse GetById(Guid id)
    {
        return mapper.Map<ShoppingCartResponse>(shoppingCartRepository.GetById(id));
    }

    public User GetUserById(Guid id)
    {
        return shoppingCartRepository.GetUserById(id);
    }
}