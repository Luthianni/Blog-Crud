using Blog.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Service
{
    public interface IBlogService
    {
        Task AddAsync(BlogDTO blogDTO);

        Task<IEnumerable<BlogDTO>> GetAllAsync();

        Task<BlogDTO> GetByIdAsync(int Id);

        Task<BlogDTO> UpdateAsync(BlogDTO blogm);

        Task<bool> Delete(int Id);
                
        Task DislikeBlog(int id);
        
        Task LikeBlog(int id);
    }
}
