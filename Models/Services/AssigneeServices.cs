using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Data;
using EntityFramework.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace EntityFramework.Models.Services
{
    public class AssigneeServices : IAssigneeServices
    {
        public readonly ApplicationContext dbContext;
        public AssigneeServices(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Assignee> ReadAssignees()
        {
            return dbContext.Assignees.ToList();
        }
        public void AddAssignee(Assignee assignee)
        {
            dbContext.Assignees.Add(assignee);
            dbContext.SaveChanges();
        }
        public void DeleteAssignee(long id)
        {
            dbContext.Remove(dbContext.Assignees.FirstOrDefault(a => a.Id == id));
            dbContext.SaveChanges();
        }
        public void EditAssignee(long id, string name, string email)
        {
            var assigneeToEdit = dbContext.Assignees.FirstOrDefault(a => a.Id == id);
            assigneeToEdit.Name = name;
            assigneeToEdit.Email = email;
            dbContext.Assignees.Update(assigneeToEdit);
            dbContext.SaveChanges();
        }
        public void InitialAssignees()
        {
            dbContext.Assignees.Add(new Assignee("Zsófi", "zsofi@zsofi.com"));
            dbContext.Assignees.Add(new Assignee("Ádám", "adam@adam.com"));
            dbContext.SaveChanges();
        }
        public Assignee FindAssignee(long id)
        {
            var assigne = dbContext.Assignees.FirstOrDefault(a => a.Id == id);
            return assigne;
        }
        public void AssigneeTodoLink(long assigneeId, long todoId)
        {
            var assignee = dbContext.Assignees.FirstOrDefault(a => a.Id == assigneeId);
            var todo = dbContext.Todos.FirstOrDefault(a => a.Id == todoId);
            assignee.Todos.Add(todo);
        }
    }
}
