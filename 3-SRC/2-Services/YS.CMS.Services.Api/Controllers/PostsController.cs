﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YS.CMS.Services.Api.Extensions.ContentFilters;
using System;
using AutoMapper;
using YS.CMS.Common.Models.View;
using Microsoft.AspNetCore.Http;
using YS.CMS.Infra.Security.Manager;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace YS.CMS.Services.Api.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> NewAsync(PostViewModel modelPost)
        {
            if (ModelState.IsValid)
            {
                var newPost = _mapper.Map<PostViewModel, Post>(modelPost, opt => opt.ConstructServicesUsing(x => new Post(modelPost.Title, modelPost.Title)));

                await _repos.CreateAsync(newPost);

                var uri = Url.Action("GetAsync", new { id = newPost.Id });
                return Created(uri, newPost);

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