using AutoMapper;
using Blog.DTO;
using Blog.Interface;
using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class BlogService : IBlogService
    {
        private readonly IMapper mapper;
        private readonly IBlogRepositorio repositorio;

        public BlogService(IMapper mapper, IBlogRepositorio repositorio)
        {
            this.mapper = mapper;
            this.repositorio = repositorio;
        }

        public async Task AddAsync(BlogDTO blogDTO)
        {
            var entidade = mapper.Map<BlogM>(blogDTO);
            entidade.Image = new BlogImagem
            {
                Imagem = blogDTO.Imagem
            };

            await repositorio.Adicionar(entidade);
        }

        public async Task<IEnumerable<BlogDTO>> GetAllAsync()
        {
            var chats = await repositorio.ObterTodos();
            var chatsVM = mapper.Map<IEnumerable<BlogDTO>>(chats);

            return chatsVM;
        }

        public async Task<BlogDTO> GetByIdAsync(int Id)
        {
            var blog = await repositorio.Editar(Id);
            var entidade = mapper.Map<BlogDTO>(blog);

            return entidade;
        }

        public async Task<BlogDTO> UpdateAsync(BlogDTO blog)
        {
            var UpBlog = mapper.Map<BlogM>(blog);
            await repositorio.Update(UpBlog);
            var BlogUp = mapper.Map<BlogDTO>(UpBlog);

            return BlogUp;
        }

        public async Task<bool> Delete(int id)
        {
            return await repositorio.Deletar(id);
        }

        public async Task LikeBlog(int Id)
        {
            await repositorio.LikeDisLikeBlog(Id, true);
        }

        public async Task DislikeBlog(int id)
        {
            await repositorio.LikeDisLikeBlog(id, false);
        }

        
    }
}
