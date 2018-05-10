using MiAPI.Models;
using MiAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAPI.Services
{

    public interface ITodoService
    {
       IList<TodoList> GetTodoLists();
    }

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
    }

    public class FakeTodoServices : ITodoService
    {
        public FakeTodoServices() { }

        public IList<TodoList> GetTodoLists()
        {
            var lista1 = new TodoList()
            {
                Id = 1,
                Name = "Lista de la compra",
                Owner = "Mario",
                Items = new List<TodoItem>()
                {
                    new TodoItem() { TodoListId=1, Description="Huevos"},
                    new TodoItem() { TodoListId =1, Description="Pan"},
                    new TodoItem() { TodoListId=1, Description="Jamon"},
                    new TodoItem() { TodoListId=1, Description="Queso"},
                }
            };

            var listCollection = new List<TodoList>
            {
                lista1
            };
            return listCollection;
        }
    }
}
