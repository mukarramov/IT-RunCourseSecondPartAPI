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

    public IEnumerable<ShoppingCartResponse> GetAll()
    {
        return shoppingCartRepository.GetAll().ToList()
            .Select(x => mapper.Map<ShoppingCartResponse>(x));
    }

    public ShoppingCartResponse Update(Guid id, ShoppingCartCreate shoppingCartCreate)
    {
        var shoppingCart = shoppingCartRepository.GetById(id);

        shoppingCart.User = shoppingCartRepository.GetUserById(shoppingCartCreate.UserId);

        shoppingCartRepository.Update(id, shoppingCart);

        var shoppingCartResponse = mapper.Map<ShoppingCartResponse>(shoppingCartRepository.GetById(id));

        var timeFromUtc = TimeZoneInfo.ConvertTimeFromUtc(shoppingCartResponse.CreateAt, TimeZoneInfo.Local);

        shoppingCartResponse.CreateAt = timeFromUtc;

        return shoppingCartResponse;
    }

    public ShoppingCartResponse Delete(Guid id)
    {
        var shoppingCartResponse = mapper.Map<ShoppingCartResponse>(shoppingCartRepository.GetById(id));

        var timeFromUtc = TimeZoneInfo.ConvertTimeFromUtc(shoppingCartResponse.CreateAt, TimeZoneInfo.Local);

        shoppingCartResponse.CreateAt = timeFromUtc;

        return shoppingCartResponse;
    }

    public ShoppingCartResponse GetById(Guid id)
    {
        var shoppingCartResponse = mapper.Map<ShoppingCartResponse>(shoppingCartRepository.GetById(id));

        var timeFromUtc = TimeZoneInfo.ConvertTimeFromUtc(shoppingCartResponse.CreateAt, TimeZoneInfo.Local);

        shoppingCartResponse.CreateAt = timeFromUtc;

        return shoppingCartResponse;
    }
}