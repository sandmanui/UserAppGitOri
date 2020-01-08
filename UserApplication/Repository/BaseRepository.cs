using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserApplication.Repository
{
    public abstract class BaseRepository
    {
        protected readonly string _baseUrl = "https://jsonplaceholder.typicode.com/";
        public BaseRepository()
        {

        }

    }
}
