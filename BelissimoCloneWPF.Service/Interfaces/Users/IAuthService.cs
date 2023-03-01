using System.Threading.Tasks;
using BelissimoCloneWPF.Service.DTOs.Users;

namespace BelissimoCloneWPF.Service.Interfaces.Users
{
    public interface IAuthService
    {
       ValueTask<bool> Login(UserForLoginDTO userForLoginDTO);
    }
}
