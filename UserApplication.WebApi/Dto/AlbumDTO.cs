using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Enums;

namespace UserApplication.WebApi.Dto
{
    public class AlbumDTO
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public AlbumTypeDto type { get; set; }

        public int stock { get; set; }
    }
}
