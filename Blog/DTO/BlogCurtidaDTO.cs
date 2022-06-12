using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BlogCurtidaDTO
    {
        [Key]
        public int CurtidaId { get; set; }

        public bool Likes { get; set; }
        public bool Dislikes { get; set; }
    }
}
