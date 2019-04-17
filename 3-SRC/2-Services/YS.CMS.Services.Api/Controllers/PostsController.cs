using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using YS.CMS.Services.Api.Models;
using System;
using YS.CMS.Domain.Base.Interfaces;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _repos;
        private readonly ICategory _reposCategory;

        public PostsController(IPost repos, ICategory reposCategory)
        {
            _repos = repos;
            _reposCategory = reposCategory;
        }

        [HttpPost]
        public async Task<IActionResult> New(Post post)
        {
            if (ModelState.IsValid)
            {
                
                var category = await _reposCategory.All.FirstOrDefaultAsync(c => c.Id == 1);
                post.Category = category;
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
        public async Task<IEnumerable<Post>> FilterAsync(PostFilterModel filter)
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
            else if (filter.CreateDate.HasValue)
            {
                query = query.Where(p => p.CreateDate.Date == filter.CreateDate.Value.Date);
            }
            return await query.ToListAsync();
        }
    }
}