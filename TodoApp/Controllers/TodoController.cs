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

        // GET /todo/create
        public IActionResult Create() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Todo item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                item.UserEmail = User.Identity.Name;
                item.AddedDate = DateTime.Now.Date;
                await context.SaveChangesAsync();
                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET /todo/edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Todo item = await context.TodoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST /todo/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Todo item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                if(item.DoneDate != null)
                {
                    await context.SaveChangesAsync();
                } else if (item.Done)
                {
                    item.DoneDate = DateTime.Now.Date;
                }
                if (!item.Done)
                {
                    item.DoneDate = null;
                }

                await context.SaveChangesAsync();
                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET /todo/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Todo item = await context.TodoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item doesn't exist! :(";
            }else
            {
                context.TodoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }

        // GET/todo/done/5
        public async Task<ActionResult> Done(int id)
        {
            Todo item = await context.TodoList.FindAsync(id);
            item.Done = true;
            item.DoneDate = DateTime.Now;
            await context.SaveChangesAsync();
            TempData["Success"] = "Task complete!";
            return RedirectToAction("Index");
            
        }
    }
}
