using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Service.DTOs.Users;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Interfaces.Users;
using Microsoft.Extensions.Configuration;

namespace BelissimoCloneWPF.Service.Services.Users
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> userRepository;

        public AuthService(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

      
        ValueTask<bool> Login(UserForLoginDTO userForLoginDTO)
        {

        }
        
    }
}
