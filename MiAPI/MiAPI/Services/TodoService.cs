using MiAPI.Models;
using MiAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
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


            var list = _context.TodoLists.Include(t => t.Items).SingleOrDefault(t => t.Id == id);
            return list;
        }

        public bool ExistList(int id)
        {
            return _context.TodoLists.Any(t => t.Id == id);
        }

        public int CreateList(TodoList list)
        {
            //Validad que no hay una lista con el mismo nombre
            var exist = _context.TodoLists.Any(t => t.Name == list.Name);
            if (exist)
                throw new ArgumentException("La lista ya existe");

            _context.TodoLists.Add(list);
            _context.SaveChanges();
            
            return list.Id;

        }

        public void UpdateList(TodoList list)
        {
            _context.Entry(list).State = EntityState.Modified;

            foreach (var item in list.Items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void DeleteList(int id)
        {
            var list = _context.TodoLists.Find(id);
            _context.TodoLists.Remove(list);

            _context.SaveChanges();
        }
    }
}
