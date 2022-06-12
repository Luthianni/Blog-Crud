using Blog.Context;
using Blog.Interface;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BlogRepository : IBlogRepositorio
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogM>> ObterTodos()
        {
            return await _context.Blogs.Include(w => w.Image).Include(w => w.Curtidas).ToListAsync();
        }

        public async Task Adicionar(BlogM entidades)
        {
            await _context.Blogs.AddAsync(entidades);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            var del = await _context.Blogs.SingleOrDefaultAsync(d => d.BlogId.Equals(id));
            if (del == null)
                return false;
            _context.Remove(del);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BlogM> Editar(int Id)
        {
            return await _context.Blogs.Include(w => w.Image).Include(w => w.Curtidas).SingleOrDefaultAsync(e => e.BlogId.Equals(Id));
        }

        public async Task<BlogM> Update(BlogM blogm)
        {
            var up = await _context.Blogs.SingleOrDefaultAsync(u => u.BlogId.Equals(blogm.BlogId));
            if (up == null)

                return null;
            _context.Entry(up).CurrentValues.SetValues(blogm);
            await _context.SaveChangesAsync();

            return blogm;
        }

        public async Task LikeDisLikeBlog(int Id, bool LikeDislike)
        {
            var curtida = new BlogCurtida()
            {
                BlogId = Id,
                Like = LikeDislike,
                DataCurtida = System.DateTime.Now,
            };

            await _context.BlogCurtidas.AddAsync(curtida);
            await _context.SaveChangesAsync();

        }
       
    }
}
