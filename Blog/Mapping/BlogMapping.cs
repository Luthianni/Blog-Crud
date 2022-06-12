using AutoMapper;
using Blog.DTO;
using Blog.Models;
using System.Linq;

namespace Blog.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<BlogDTO, BlogM>();

            CreateMap<BlogM, BlogDTO>()
                .ForMember(dto => dto.Imagem, opt => opt.MapFrom
                (entity => entity.Image.Imagem))

                .ForMember(dto => dto.Likes, opt => opt.MapFrom
                (entity => entity.Curtidas.Count(w => w.Like)))

                .ForMember(dto => dto.Dislikes, opt => opt.MapFrom
                (entity => entity.Curtidas.Count(w => !w.Like)));
        }
    }
}
