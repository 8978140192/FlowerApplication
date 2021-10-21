using FlowerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlowerApi.Services
{
    public class UserService
    {
        private readonly FlowerContext _context;
        private readonly ITokenService _tokenService;

        public UserService(FlowerContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public User Register(RegisterDto user)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var newUser = new User()
                {
                    UserId = user.userId,
                    userName = user.userName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.password)),
                    PasswordSalt = hmac.Key
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();


                return newUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public LoginDto Login(LoginDto userDto)
        {
            try
            {
                var myUser = _context.Users.SingleOrDefault(u => u.UserId == userDto.UserId);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDto.jwtToken = _tokenService.CreateToken(userDto);
                    userDto.Password = "";
                    return userDto;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
