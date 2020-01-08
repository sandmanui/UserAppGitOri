using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Dto;
using UserApplication.WebApi.Helpers;
using UserApplication.WebApi.Repository;

namespace UserApplication.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UserService(IUserRepository userRepository, IMapper mapper, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<IEnumerable<UserDTO>> ListAsync()
        {
            // Here I list user list from cache if they exist, there is no data filter on list so cache key will be constant
            // composing a cache key for further enhancement and to avoid returning wrong data.
            //any users list fetched within 1 min of previous call, data will be returned from cache
            string cacheKey = GetCacheKey();

            var users = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _userRepository.GetAllAsync();
            });

            //var users = await _userRepository.GetAllAsync();
            var userModel = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return userModel;
        }

        public async Task<UserDTO> GetAsync(int userId)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.Where(u => u.Id == userId).FirstOrDefault();
            var userModel = _mapper.Map<User, UserDTO>(user);
            return userModel;
        }

        private string GetCacheKey()
        {
            string key = CacheKeys.UserList.ToString(); //this will be 0, we can add more number of cache key for different collections
            key = string.Concat(key, "_1");
            return key;
        }
    }
}
