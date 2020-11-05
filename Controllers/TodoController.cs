using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Data;
using EntityFramework.Model;
using EntityFramework.Models;
using EntityFramework.Models.Services;
using EntityFramework.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    [Route("")]
    //[Route("todo")]
    public class TodoController : Controller
    {
        private readonly ITodoServices service;
        private  ApplicationContext applicationContext;
        public TodoController(ITodoServices service, ApplicationContext applicationContext)
        {
            this.service = service;
            this.applicationContext = applicationContext;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            //service.AddTodo(new Todo("Start the day"));
            //service.AddTodo(new Todo("Finish H2 workshop1"));
            //service.AddTodo(new Todo("Finish JPA workshop2"));
            //service.AddTodo(new Todo("Create a CRUD project"));
            //service.AddTodo(new Todo("daily task"));
            //service.AddTodo(new Todo("make the beds", true, true));
            //service.AddTodo(new Todo("do the washing up", true));
            //service.AddTodo(new Todo("clean the bathroom and the kitchen", true, true));
            //service.AddTodo(new Todo("wipe all the surfaces with a cloth", true));
            //service.AddTodo(new Todo("remove the grease", true, true));
            //service.AddTodo(new Todo("tidy up"));
            //service.AddTodo(new Todo("throw away the rubbish", true, true));
            //service.AddTodo(new Todo("broom", true));
            //service.AddTodo(new Todo("sweep the floor", true, true));
            //service.AddTodo(new Todo("wash the floors", true));
            //service.AddTodo(new Todo("mop", true, true));
            //service.AddTodo(new Todo("vacuum the carpet"));
            //service.AddTodo(new Todo("vacuum cleaner / hoover", true, true));
            //service.AddTodo(new Todo("dust the furniture", true));
            var todos = service.ReadTodos();
            var model = new ListViewModel(todos);

            return View(model);
        }

        [HttpGet("add")]
        public IActionResult AddTodo()
        {
            return View();
        }
        [HttpPost("add")]
        public IActionResult AddTodo(string title)
        {
            service.AddTodo(new Todo(title));
            return RedirectToAction("Index");
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var todos = service.InitialTodoList();
            var model = new ListViewModel(todos);
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteTodo(long id)
        {
            service.DeleteTodo(id);
            return RedirectToAction("Index");
        }
        [HttpGet("{id}/edit")]
        public IActionResult Edit(long id)
        {
            return View(new ItemViewModel(service.FindTodo(id)));
        }
        [HttpPost("{id}/edit")]
        public IActionResult Edit(ItemViewModel itemModel)
        {
            service.Edit(itemModel.Todo.Id, itemModel.Todo.Title, itemModel.Todo.IsUrgent, itemModel.Todo.IsDone, itemModel.Todo.Assignee);
            return RedirectToAction("Index");
        }
        [HttpPost("search")]
        public IActionResult Search(string search)
        {
            return View("Index", new ListViewModel(service.Search(search)));
        }  

    }
}
