using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserCreate>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();

        CreateMap<Category, CategoryCreate>().ReverseMap();
        CreateMap<Category, CategoryResponse>().ReverseMap();

        CreateMap<Product, ProductCreate>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();

        CreateMap<Order, OrderResponse>().ReverseMap();
        CreateMap<Order, OrderResponse>().ReverseMap();

        CreateMap<OrderItem, OrderItemCreate>().ReverseMap();
        CreateMap<OrderItem, OrderItemResponse>().ReverseMap();

        // CreateMap<User, UserCreate>().ForMember(x =>
        //     x.Email, x =>
        //     x.Ignore()); //ignored the email property (do it null (email: null;))
        // .ForMember(x => x.Address, x =>
        // x.MapFrom(x => x.FullName)); //equals address property to fullname property (address=fullname)
    }
}