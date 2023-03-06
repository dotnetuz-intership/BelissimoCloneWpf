using BelissimoCloneWPF.Service.DTOs.Users;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Interfaces.Users
{
    public interface IAuthService
    {
        ValueTask<bool> Login(UserForLoginDTO userForLoginDTO);
    }
}
