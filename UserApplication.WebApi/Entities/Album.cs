using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Enums;

namespace UserApplication.WebApi.Entities
{
    public class Album
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Artist { get; set; }
        
        [Required]
        public AlbumTypeDto type { get; set; }
        
        [Required]
        public int stock { get; set; }

        

    }
}
