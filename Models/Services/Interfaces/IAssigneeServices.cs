using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Models.Services
{
    public interface IAssigneeServices
    {
        public void InitialAssignees();
        public List<Assignee> ReadAssignees();
        public void AddAssignee(Assignee assignee);
        public void DeleteAssignee(long id);
        public void EditAssignee(long id, string name, string email);
        public Assignee FindAssignee(long id);
        public void AssigneeTodoLink(long assigneeId, long todoId);

    }
}
