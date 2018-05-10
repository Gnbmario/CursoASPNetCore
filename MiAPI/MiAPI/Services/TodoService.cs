using MiAPI.Models;
using MiAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MiAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationContext _context;

        public TodoService(ApplicationContext context)
        {
            _context = context;
        }

        public IList<TodoList> GetTodoLists()
        {
            return _context.TodoLists.Include(t=> t.Items).ToList();
        }

        public TodoList GetTodoList(int id)
        {


            var list = _context.TodoLists.Include(t => t.Items).Single(t => t.Id == id);
            return list;
        }
    }
}
