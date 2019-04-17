using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Interfaces;

namespace YS.CMS.Services.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _repos;

        public CategoryController(ICategory repos)
        {
            _repos = repos;
        }

        [HttpPost]
        public async Task<IActionResult> New(Category category)
        {
            if (ModelState.IsValid)
            {
                await _repos.CreateAsync(category);

                var uri = Url.Action("Get", new { id = category.Id });
                return Created(uri, category);

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id.HasValue)
            {
                var category = await _repos.FindAsync(id.Value);
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category model)
        {
            if (ModelState.IsValid)
            {
                var category = await _repos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (category != null)
                {
                    await _repos.UpdateAsync(model);
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Category model)
        {
            if (ModelState.IsValid)
            {
                var category = await _repos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == model.Id);
                if (category != null)
                {
                    await _repos.DeleteAsync(model);
                    return Ok();
                }
                return NoContent();
            }
            return BadRequest();
        }
    }
}