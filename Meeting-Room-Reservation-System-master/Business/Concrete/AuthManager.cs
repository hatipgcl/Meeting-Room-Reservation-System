using Business.Abstract;
using Business.Constanst;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.UserName,
                UserSurname = userForRegisterDto.UserSurname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

     
             public int GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null && int.TryParse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                return userId;
            }
            throw new Exception("Mevcut kullanıcının ID'si alınamadı.");
        }

    }
}
