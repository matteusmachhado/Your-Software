using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YS.CMS.Services.Api.Models;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _repos;

        public PostsController(IPost repos)
        {
            _repos = repos;
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post)
        {
            if (ModelState.IsValid)
            {
                await _repos.CreateAsync(post);

                var uri = Url.Action("Get", new { id = post.Id });
                return Created(uri, post);

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
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
                var post = await _repos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (post != null)
                {
                    await _repos.UpdateAsync(model);
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Post model)
        {
            if (ModelState.IsValid)
            {
                var post = await _repos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (post != null)
                {
                    await _repos.DeleteAsync(model);
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<Post>> FilterAsync(PostFilterModel filter)
        {
            IQueryable<Post> query = _repos.All.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(p => p.Title.Contains(filter.Title));
            }
            else if (!string.IsNullOrEmpty(filter.Text))
            {
                query = query.Where(p => p.Title.Contains(filter.Text));
            }
            else if (!string.IsNullOrEmpty(filter.SubTitle))
            {
                query = query.Where(p => p.Title.Contains(filter.SubTitle));
            }
            else if (filter.Category != null)
            {
                query = query.Where(p => p.Category.Id == filter.Category.Id);
            }
            else if (filter.Author.HasValue)
            {
                query = query.Where(p => p.Author == filter.Author.Value);
            }
            else if (filter.CreateUser.HasValue)
            {
                query = query.Where(p => p.CreateUser == filter.CreateUser.Value);
            }
            else if (filter.CreateDate.HasValue)
            {
                query = query.Where(p => p.CreateDate.Date == filter.CreateDate.Value.Date);
            }
            else if (filter.UpdateDate.HasValue)
            {
                query = query.Where(p => p.UpdateDate.Value.Date == filter.UpdateDate.Value.Date);
            }
            else if (filter.PublishDate.HasValue)
            {
                query = query.Where(p => p.PublishDate.Value.Date == filter.PublishDate.Value.Date);
            }
            
            var result = await query.ToListAsync();
            return Ok(result);
        }
    }
}