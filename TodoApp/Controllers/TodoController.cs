using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        
        private readonly TodoDbContext context;
        public TodoController(TodoDbContext context)
        {
            this.context = context;
        }

        // GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<Todo> items = from i in context.TodoList orderby i.TodoItemID select i;

            List<Todo> todoList = await items.ToListAsync();

            return View(todoList);
        }
        
    }
}
