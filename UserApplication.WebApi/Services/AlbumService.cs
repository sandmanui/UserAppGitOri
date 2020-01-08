using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Dto;
using UserApplication.WebApi.Entities;
using UserApplication.WebApi.Repository;

namespace UserApplication.WebApi.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AlbumDTO>> ListAsync()
        {
            var albums = await _albumRepository.FindAll().ToListAsync();
            var albumModel = _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(albums);
            return albumModel;
        }
    }
}
