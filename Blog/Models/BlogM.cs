
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogM
    {
        [Key]
        public int BlogId { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Texto { get; set; }

        public BlogImagem Image { get; set; }
        
        public ICollection<BlogCurtida> Curtidas { get; set; } = new HashSet<BlogCurtida>();



    }

}
