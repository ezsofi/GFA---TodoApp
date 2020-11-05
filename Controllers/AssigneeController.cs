using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models.Services;
using EntityFramework.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    [Route("assignees")]
    public class AssigneeController : Controller
    {
        private readonly IAssigneeServices assigneeService;
        public AssigneeController(IAssigneeServices service)
        {
            assigneeService = service;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // assigneeService.InitialAssignees();
            return View("Index", new AssigneesViewModel(assigneeService.ReadAssignees()));
        }
        [HttpPost]
        public IActionResult DeleteAssignee(long id)
        {
            assigneeService.DeleteAssignee(id);
            return RedirectToAction("Index");
        }
        [HttpGet("{id}/editAssignee")]
        public IActionResult EditAssignee(long id)
        {
            return View(new AssigneeViewModel(assigneeService.FindAssignee(id)));
        }
        [HttpPost("{id}/editAssignee")]
        public IActionResult EditAssignee(AssigneeViewModel assigneModel)
        {
            assigneeService.EditAssignee(assigneModel.Assignee.Id, assigneModel.Assignee.Name, assigneModel.Assignee.Email);
            return RedirectToAction("Index");
        }
        [HttpGet("addassignee")]
        public IActionResult AddAssignee()
        {
            return View();
        }
        [HttpPost("addassignee")]
        public IActionResult AddAssignee(Assignee assignee)
        {
            assigneeService.AddAssignee(assignee);
            return RedirectToAction("Index");
        }
    }
}
