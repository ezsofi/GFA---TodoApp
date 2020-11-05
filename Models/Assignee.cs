using EntityFramework.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Assignee
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Todo> Todos { get; set; }
        public Assignee(string name, string email)
        {
            Name = name;
            Email = email;
            Todos = new List<Todo>();

        }
        public Assignee()
        {

        }
    }
}
