using KioskManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KioskManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext _ctx = new AppDbContext();

        private void PopulateTeamDropDownList(object selectedTeam = null)
        {
            var teamQuery = from d in _ctx.Team
                       orderby d.TeamName
                       select d;
            ViewBag.TeamId = new SelectList(teamQuery, "TeamId", "TeamName", selectedTeam);
        }

        [HttpGet]
        public ActionResult EmployeeList()
        {
            var employeeList = _ctx.Employee.Include(s=>s.Team).ToList();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PopulateTeamDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "EmployeeId,EmployeeName,DateOfBirth,Phone,Gender, TeamId ")] 
        Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ctx.Employee.Add(employee);
                    _ctx.SaveChanges();
                    return RedirectToAction("EmployeeList");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Không thể thêm mới, hãy thử lại!");
            }
            PopulateTeamDropDownList(employee.TeamId);
            return View(employee);
            
        }

        // GET: Employee/Edit?id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _ctx.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            PopulateTeamDropDownList(employee.TeamId);
            return View(employee);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }    
            var employeeToUpdate = _ctx.Employee.Find(id);
            if(TryUpdateModel(employeeToUpdate,"",
                new string[] {"EmployeeName", "Gender", "Address", "DateOfBirth", "Phone", "TeamId" }))
            {
                try
                {
                    _ctx.SaveChanges();

                    return RedirectToAction("EmployeeList");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Không thể cập nhật, hãy thử lại!");
                }
            }
            PopulateTeamDropDownList(employeeToUpdate.TeamId);
            return View(employeeToUpdate);
        }

        public ActionResult Delete(int? id)
        {
            var employee = _ctx.Employee.Where(s => s.EmployeeId == id).First();
            _ctx.Employee.Remove(employee);
            _ctx.SaveChanges();

            return RedirectToAction("EmployeeList");
        }
    }
}
