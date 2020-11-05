using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models.ViewModels
{
    public class ItemViewModel
    {
        public Todo Todo { get; set; }
        public ItemViewModel(Todo todo)
        {
            Todo = todo;
        }
        public ItemViewModel()
        {

        }
    }
}
