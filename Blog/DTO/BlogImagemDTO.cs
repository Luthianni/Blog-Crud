using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogImagemDTO
    {
        [Key]
        public int ImagemId { get; set; }
        public byte[] Imagem { get; set; }
    }
}
