using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.Models;
using MiAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        ITodoService _service;
        private const string NotFoundMessage = "No existe ninguna lista con el id especificado";

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<TodoList> GetLists(int id)
        {
            return _service.GetTodoLists();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetList(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_service.ExistList(id))
                return NotFound(new { info = "No existe ninguna lista con el id especificado" });

            var result= _service.GetTodoList(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostTodoList([FromBody]TodoList list)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int createdId;
            try
            {
                 createdId = _service.CreateList(list);
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction("PostTodoList", new { id = createdId }, list);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutTodoList(int id,[FromBody] TodoList list)
        {
            // || OR
            // && AND
            if (!ModelState.IsValid || id <=0)
                return BadRequest(ModelState);

            _service.UpdateList(list);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTodoList(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!_service.ExistList(id))
                return NotFound(new { info = NotFoundMessage });

            _service.DeleteList(id);

                return Ok();
        }
    }
}