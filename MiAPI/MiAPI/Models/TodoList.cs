using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiAPI.Models
{

    // Lista 
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Owner { get; set; }

        public IList<TodoItem> Items { get; set; }  
    }

    // Elemento de lista
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Done { get; set; }

        public int TodoListId { get; set; }

        [JsonIgnore]
        public TodoList TodoList { get; set; }
    }
}

