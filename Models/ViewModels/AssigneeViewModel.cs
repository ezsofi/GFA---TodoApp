using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models.ViewModels
{
    public class AssigneeViewModel
    {
        public Assignee Assignee { get; set; }
        public AssigneeViewModel(Assignee assignee)
        {
            Assignee = assignee;
        }
        public AssigneeViewModel()
        {

        }
    }
}
