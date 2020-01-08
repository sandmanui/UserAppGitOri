using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserApplication.WebApi.Helpers;

namespace UserApplication.WebApi.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userJson = await RestHelper.GetStringAsync(_baseUrl + "users/");
            
            // deserialize JSON string to User object
            var user = JsonConvert.DeserializeObject<IEnumerable<User>>(userJson);
            return user;
        }
        
        public User GetById(object Id)
        {
            throw new NotImplementedException();
        }

        
    }
}
