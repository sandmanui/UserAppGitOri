using System.Collections.Generic;
using System.Threading.Tasks;
using UserApplication.Dto;
using UserApplication.Repository;

namespace UserApplication.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> ListAsync();
        Task<UserDTO> GetAsync(int userId);
    }
}