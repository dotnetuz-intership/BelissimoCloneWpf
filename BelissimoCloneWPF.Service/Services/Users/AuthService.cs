using System.Threading.Tasks;
using BelissimoCloneWPF.Data.IRepositories;
using BelissimoCloneWPF.Domain.Entities.Users;
using BelissimoCloneWPF.Service.DTOs.Users;
using BelissimoCloneWPF.Service.Exceptions;
using BelissimoCloneWPF.Service.Interfaces.Users;

namespace BelissimoCloneWPF.Service.Services.Users
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> userRepository;

        public AuthService(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async ValueTask<bool> Login(UserForLoginDTO userForLoginDTO)
        {
            var user = await userRepository.GetAsync(u =>
            u.Username == userForLoginDTO.Login && u.Password == userForLoginDTO.Password);

            if (user == null)
            {
                throw new BelissimoCloneWPFException(404, "Login or Password is incorrect");
            }

            return true;
        }
    }
}