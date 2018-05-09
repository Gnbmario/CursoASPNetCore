using MiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAPI.Services
{
    public class FakeTodoServices
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
