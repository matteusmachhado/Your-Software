using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.interfaces;
using System.Linq;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}