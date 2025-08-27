using LibraryManagement.Core.Entities.Concrete;
using LibraryManagement.Core.Utilities.Results;
using LibraryManagement.Core.Utilities.Security.JWT;
using LibraryManagement.Entities.DTOs;

namespace LibraryManagement.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
