using EntityFramework.Data;
using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ApplicationContext dbContext;

        public TodoServices(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Todo> ReadTodos()
        {
            return dbContext.Todos.ToList();
        }

        public void AddTodo(Todo todo)
        {
            dbContext.Todos.Add(todo);
            dbContext.SaveChanges();
        }
        public void DeleteTodo(long id)
        {
            dbContext.Remove(dbContext.Todos.FirstOrDefault(todo => todo.Id == id));
            dbContext.SaveChanges();
        }
        public Todo FindTodo(long id)
        {
            var CurrentTodo = dbContext.Todos.FirstOrDefault(todo => todo.Id == id);
            return CurrentTodo;
        }
        public List<Todo> Search(string search)
        {
            List<Todo> searchedTodos = null;
            if (!String.IsNullOrEmpty(search))
            {
                searchedTodos = dbContext.Todos.Where(todo => todo.Title.ToLower().Contains(search.ToLower())
                                                          || todo.Description.ToLower().Contains(search.ToLower()))
                                               .ToList();
            }
            else
            {
                searchedTodos = dbContext.Todos.ToList();
            }
            return searchedTodos;
        }
        public void Edit(long id, string title, bool isUrgent, bool isDone, Assignee assignee)
        {
            var currentTodo = dbContext.Todos.FirstOrDefault(todo => todo.Id == id);

            currentTodo.Title = title;
            currentTodo.IsUrgent = isUrgent;
            currentTodo.IsDone = isDone;
            currentTodo.Assignee = assignee;
            dbContext.Todos.Update(currentTodo);
            dbContext.SaveChanges();
        }
        public List<Todo> InitialTodoList()
        {
            var Todos = new List<Todo>();
            Todos.Add(new Todo(1,"Start the day"));
            Todos.Add(new Todo(2,"Finish H2 workshop1"));
            Todos.Add(new Todo(3,"Finish JPA workshop2"));
            Todos.Add(new Todo(4,"Create a CRUD project"));
            return Todos;
        }
    }
}
