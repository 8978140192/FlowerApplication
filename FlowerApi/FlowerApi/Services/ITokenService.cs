using FlowerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(LoginDto loginDTO);
    }
}
