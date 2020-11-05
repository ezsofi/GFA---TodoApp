using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models.ViewModels
{
    public class AssigneesViewModel
    {
        public List<Assignee> Assignees { get; set; }
        public AssigneesViewModel(List<Assignee> assignees)
        {
            Assignees = assignees;
        }
        public AssigneesViewModel()
        {

        }

    }
}
