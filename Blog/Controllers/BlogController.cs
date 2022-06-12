using Blog.DTO;
using Blog.Models;
using Blog.Service;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNotas.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await service.GetAllAsync();
            return View(list);
        }
        public async Task<IActionResult> List()
        {
            var list = await service.GetAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [Route("ObterLista")]
        public async Task<IActionResult> ObterLista()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogDTO dto)
        {
            if (Request.Form.Files.Any())
            {
                foreach (var arquivo in Request.Form.Files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await arquivo.CopyToAsync(memoryStream);
                        dto.Imagem = memoryStream.ToArray();
                    }
                }
            }

            await service.AddAsync(dto);

            return RedirectToAction("Index");
        }          


        public async Task<IActionResult> Edit(int id)
        {
            var correction = await service.GetByIdAsync(id);
            return View(correction);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogDTO blog)
        {
            await service.UpdateAsync(blog);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id)
        {
            var detblog = await service.GetByIdAsync(id);
            return View(detblog);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delblog = await service.GetByIdAsync(id);
            return View(delblog);
        }



        [HttpPost]
        public async Task<IActionResult> Deletar(int BlogId)
        {
            var delblog = await service.Delete(BlogId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Curtida(int Id)
        {
            var edicoes = await service.GetByIdAsync(Id);
            return View(edicoes);
        }
        public async Task<IActionResult> Poster(int Id)
        {
            var edicoes = await service.GetByIdAsync(Id);
            return View(edicoes);
        }

        [HttpPost]

        public async Task<IActionResult> LikeBlog(int blogId)
        {
            await service.LikeBlog(blogId);
            var poster = await service.GetByIdAsync(blogId);
            var quantidade = new { success = true, like = poster.Likes, dislikes = poster.Dislikes };

            return Json(quantidade);
        }

        [HttpPost]

        public async Task<IActionResult> DislikeBlog(int blogId)
        {
            await service.DislikeBlog(blogId);
            var poster = await service.GetByIdAsync(blogId);
            var quantidade = new { success = true, like = poster.Likes, dislikes = poster.Dislikes };

            return Json(quantidade);
        }

    }

}
