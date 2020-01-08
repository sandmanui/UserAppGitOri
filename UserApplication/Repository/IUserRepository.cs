using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApplication.Repository
{
   public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(object Id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
