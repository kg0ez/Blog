using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BusinessLogic.Services.Implementations;
using Blog.BusinessLogic.Services.Interfaces;
using Blog.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class CorrespondentController : ControllerBase
    {
        private readonly ICorrespondService _correspond;
        public CorrespondentController(ICorrespondService correspond)
        {
            _correspond = correspond;
        }

        [HttpGet]
        public IEnumerable<ViewDto> Get()=>
            _correspond.Get();

        [HttpGet("id")]
        public ViewDto Get([FromQuery] int id)=>
            _correspond.Get(id);
        
        [HttpGet("Username")]
        public ViewDto Get([FromQuery] string username)=>
            _correspond.Get(username);

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)=>
            _correspond.IsDelete(id) ? Ok("Account was succesfully deleted") : BadRequest("Failed to delete account");
    }
}

