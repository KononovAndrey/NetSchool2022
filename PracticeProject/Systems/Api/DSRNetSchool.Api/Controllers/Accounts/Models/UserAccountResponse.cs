namespace DSRNetSchool.API.Controllers.Models;

using AutoMapper;
using DSRNetSchool.Services.UserAccount;

public class UserAccountResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserAccountResponseProfile : Profile
{
    public UserAccountResponseProfile()
    {
        CreateMap<UserAccountModel, UserAccountResponse>();
    }
}
