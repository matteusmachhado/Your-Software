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
        private readonly ICategory _reposCategory;
        private readonly IMapper _mapper;

        public PostsController(IPost repos, IMapper mapper, ICategory reposCategory)
        {
            _repos = repos;
            _reposCategory = reposCategory;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync(Post post)
        {
            if (ModelState.IsValid)
            {
               if (post.Categories.Any())
                {
                    var arrayCategories = post.Categories.Select(c => c.Category.Id).ToArray();
                    post.RemoveAllCategories();
                    var categories = await _reposCategory.FindAllAsync(arrayCategories);
                    post.AddRangeCategory(categories.ToArray());
                }

                await _repos.CreateAsync(post);
                var postResultModel = _mapper.Map<PostResultModel>(post);

                post.Categories.ToList().ForEach(c =>
                {
                   var category = _mapper.Map<CategoryResultModel>(c.Category);
                    postResultModel.Categories.Add(category);
                });

                var uri = Url.Action("GetAsync", new { id = postResultModel.Id });
                return Created(uri, postResultModel);

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