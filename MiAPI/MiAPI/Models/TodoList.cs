using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAPI.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public IList<TodoItem> Items { get; set; }  
    }

    public class TodoItem
    {
        public int TodoListId { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}

