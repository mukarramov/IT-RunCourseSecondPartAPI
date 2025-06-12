using AutoMapper;
using IT_RunCourseSecondPartAPI.Dtos.CreatedRequest;
using IT_RunCourseSecondPartAPI.DTOs.Response;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserCreate>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();

        CreateMap<Category, CategoryCreate>().ReverseMap();
        CreateMap<Category, CategoryResponse>().ReverseMap();

        CreateMap<Product, ProductCreate>().ReverseMap();
        CreateMap<Product, ProductResponse>().ReverseMap();

        CreateMap<Order, OrderCreate>().ReverseMap();
        CreateMap<Order, OrderResponse>().ReverseMap();

        CreateMap<OrderItem, OrderItemCreate>().ReverseMap();
        CreateMap<OrderItem, OrderItemResponse>().ReverseMap();

        CreateMap<CartItem, CartItemCreate>().ReverseMap();
        CreateMap<CartItem, CartItemResponse>().ReverseMap();

        CreateMap<ShoppingCart, ShoppingCartCreate>().ReverseMap();
        CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
    }
}