using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.interfaces;
using System.Linq;
using System.Collections.Generic;
using YS.CMS.Services.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _repos;
        private readonly IRepositorioBase<Category> _repos2;

        public PostsController(IPost repos, IRepositorioBase<Category> repos2)
        {
            _repos = repos;
            _repos2 = repos2;
        }

        [HttpPost]
        public async Task<IActionResult> New(Post _post)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();
                post.Title = "Title Titlesdfsdfds ";
                post.SubTitle = "SubTitle";
                post.Text = "Text";
                post.Author = Guid.NewGuid();
                post.CreateUser = Guid.NewGuid();
                post.UpdateUser = Guid.NewGuid();
                post.UpdateDate = DateTime.Now;
                
                try
                {
                    await _repos.CreateAsync(post);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            if (id.HasValue)
            {
                var post = await _repos.FindAsync(id.Value);
                return Ok(post);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Post model)
        {
            if (ModelState.IsValid)
            {
                var post = _repos.AsNoTracking().FirstOrDefault(p => p.Id == model.Id);
                if (post != null)
                {
                    await _repos.UpdateAsync(model);
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }

        //[HttpPost]
        //public async Task<IEnumerable<Post>> FilterAsync(PostFilterModel filter)
        //{
        //    IQueryable<Post> query = _repos.All.AsNoTracking();

        //    if (!string.IsNullOrEmpty(filter.Title))
        //    {
        //        query.Where(p => p.Title.Contains(filter.Title));
        //    }
        //    else if (!string.IsNullOrEmpty(filter.Description))
        //    {
        //        query.Where(p => p.Title.Contains(filter.Description));
        //    }
        //    return await query.ToListAsync();
        //}
    }
}