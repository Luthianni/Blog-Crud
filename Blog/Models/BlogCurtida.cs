using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class BlogCurtida
    {
        [Key]
        public int CurtidaId { get; set; }
        
        [ForeignKey("BlogId")]
        public int BlogId { get; set; }
        public BlogM Blog { get; set; }

        public bool Like { get; set; }
        public DateTime DataCurtida { get; set; }
    }
}
