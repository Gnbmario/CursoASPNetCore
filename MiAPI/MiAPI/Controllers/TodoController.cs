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

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<TodoList> GetLists()
        {
            return _service.GetTodoLists();
        }

        public TodoList GetList(int id)
        {
            return _service.GetTodoList(id);
        }
    }
}