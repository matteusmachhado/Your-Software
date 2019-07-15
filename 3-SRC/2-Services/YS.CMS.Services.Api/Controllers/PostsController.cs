using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YS.CMS.Services.Api.Extensions.ContentFilters;
using System;
using AutoMapper;
using YS.CMS.Common.Models.Results;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _repos;
        private readonly IMapper _mapper;

        public PostsController(IPost repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync(Post post)
        {
            if (ModelState.IsValid)
            {
                var categoria1 = new Category("Categoria Final");
                var categoria2 = new Category("Categoria Final");
                post.AddCategory(categoria1);
                post.AddCategory(categoria2);

                await _repos.CreateAsync(post);
                
                var resultModelPost = _mapper.Map<PostResultModel>(post);
                if (post.Categories.Any())
                {
                    foreach (var itemCategoryPost in post.Categories)
                    {
                        var category = _mapper.Map<CategoryResultModel>(itemCategoryPost.Category);
                        resultModelPost.Categories.Add(category);
                    }
                }
                
                var uri = Url.Action("GetAsync", new { id = resultModelPost.Id });
                return Created(uri, resultModelPost);

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var post = await _repos.FindWithCategories(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> PostsAsync([FromQuery] PostFilterModel filter, [FromQuery] PostOrderModel order)
        {
            var list = await _repos.All
                .ApplyFilter(filter)
                .ApplyOrder(order)
                .ToListAsync();

            if (list.Any())
            {
                return Ok(list);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Post model)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var post = await _repos.FindAsync(id);
            if (post != null)
            {
                await _repos.DeleteAsync(post);
                return Ok();
            }
            return NoContent();
        }

    }
}