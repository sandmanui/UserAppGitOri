using System.Collections.Generic;
using System.Threading.Tasks;
using UserApplication.WebApi.Dto;

namespace UserApplication.WebApi.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDTO>> ListAsync();
    }
}