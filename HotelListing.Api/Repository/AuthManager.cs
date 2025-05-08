using AutoMapper;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Api.Repository;

public class AuthManager : IAuthManager
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApiUser> _userManager;

    public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
    {
        var user = _mapper.Map<ApiUser>(userDto);
        user.UserName = userDto.Email;
        
        var result = await _userManager.CreateAsync(user, userDto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }
        return result.Errors;
    }

    public async Task<bool> Login(LoginDto loginDto)
    {
        bool isValidUser = false;
        try
        {
            var _user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (_user is null)
            {
                return default;
            }
 
            bool isValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);
 
            if (!isValidCredentials)
            {
                return default;
            }
        }
        catch (Exception)
        {
         
        }
        return isValidUser;
      
    }
}