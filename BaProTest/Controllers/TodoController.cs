using BaProTest.Models;
using BaProTest.Models.DTO;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BaProTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _config;

        public TodoController(ITodoServices config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult> alltodos()
        {
            var todos = await _config.getall();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult> addnew (Class y)
        {
            var added = await _config.addtodo(y);
            return Ok(added);
        }

        [HttpDelete]
        public async Task<ActionResult> deleteone (int Id)
        {
            await _config.deletetodo(Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> editone (TodoModel model)
        {
            await _config.edittotdo(model);
            return NoContent();
        }
        
    }
}
