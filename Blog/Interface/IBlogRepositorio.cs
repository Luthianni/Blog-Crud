using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Interface
{
    public interface IBlogRepositorio
    {
        Task<IEnumerable<BlogM>> ObterTodos();

        Task Adicionar(BlogM entidades);

        Task<BlogM> Editar(int id);

        Task<BlogM> Update(BlogM blogm);
       
        Task<bool> Deletar(int id);

        Task LikeDisLikeBlog(int Id, bool likeDislike);

       
    }
}
