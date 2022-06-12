using System;
using System.ComponentModel.DataAnnotations;


namespace Blog.DTO
{
    public class BlogDTO
    {
        [Key]
        public int BlogId { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Texto { get; set; }
        public byte[] Imagem { get; set; }

        //////////Check-out///////////

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
