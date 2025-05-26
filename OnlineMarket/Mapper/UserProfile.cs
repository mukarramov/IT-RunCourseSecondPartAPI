using AutoMapper;
using IT_RunCourseSecondPartAPI.DTOs;
using IT_RunCourseSecondPartAPI.Models;

namespace IT_RunCourseSecondPartAPI.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ForMember(x =>
            x.Email, x =>
            x.Ignore()); //ignored the email property (do it null (email: null;))

        // .ForMember(x => x.Address, x =>
        // x.MapFrom(x => x.FullName)); //equals address property to fullname property (address=fullname)
    }
}