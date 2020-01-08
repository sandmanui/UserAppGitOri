using System.Collections.Generic;
using System.Threading.Tasks;
using UserApplication.WebApi.Dto;

namespace UserApplication.WebApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> ListAsync();
        Task<UserDTO> GetAsync(int userId);
    }
}