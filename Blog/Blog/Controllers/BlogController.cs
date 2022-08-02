using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blog;
        public BlogController(IBlogService blog)=>
            _blog = blog;

        [HttpGet]
        public IEnumerable<TopicDto> Get()=>
            _blog.Get();

        [HttpGet("{id}")]
        public IActionResult Get(int id)=>
            Ok(_blog.Get(id));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)=>
            _blog.IsDelete(id)? Ok("Blog was succesfully deleted") : BadRequest("Failed to delete blog");

        [HttpPost("Update")]
        public void Update()=>
            _blog.AddRange();
    }
}

