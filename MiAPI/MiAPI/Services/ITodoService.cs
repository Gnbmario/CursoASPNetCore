using MiAPI.Models;
using System.Collections.Generic;

namespace MiAPI.Services
{
    public interface ITodoService
    {
       IList<TodoList> GetTodoLists();
       TodoList GetTodoList(int id);
    }
}
