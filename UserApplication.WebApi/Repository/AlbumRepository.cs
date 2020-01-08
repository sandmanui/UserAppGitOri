using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Context;
using UserApplication.WebApi.Entities;

namespace UserApplication.WebApi.Repository
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

       
    }
}
