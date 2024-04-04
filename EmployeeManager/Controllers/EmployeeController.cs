using EmployeeManager.Business.Modules;
using EmployeeManager.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeService employeeService = new EmployeeService();
            List<EmployeeViewModel> employeeList = employeeService.GetAllEmployees();
            return View(employeeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<string> Errors = new List<string>();
            ViewBag.Errors = Errors;
            EmployeeViewModel empoyee = new EmployeeViewModel();

            EmployeeService employeeService = new EmployeeService();

            ViewBag.Departments = employeeService.GetAllDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            ViewBag.Grades = employeeService.GetAllGrades().Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            return View(empoyee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel empoyee)
        {
            EmployeeService employeeService = new EmployeeService();
            List<string> Errors = new List<string>();
            if (!ModelState.IsValid)
            {
                
                foreach (ModelState item in ModelState.Values)
                {
                    foreach (ModelError error in item.Errors)
                    {
                        Errors.Add(error.ErrorMessage);
                    }
                }
                ViewBag.Errors = Errors;

                

                ViewBag.Departments = employeeService.GetAllDepartments().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

                ViewBag.Grades = employeeService.GetAllGrades().Select(g => new SelectListItem
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                }).ToList();

                return View(empoyee);
            }

            bool result = employeeService.CreateEmployee(empoyee);

            if (result)
            {
                return RedirectToAction("Index");
            }

            foreach (ModelState item in ModelState.Values)
            {
                foreach (ModelError error in item.Errors)
                {
                    Errors.Add(error.ErrorMessage);
                }
            }
            ViewBag.Errors = Errors;



            ViewBag.Departments = employeeService.GetAllDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            ViewBag.Grades = employeeService.GetAllGrades().Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();
            return View(empoyee);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<string> Errors = new List<string>();
            ViewBag.Errors = Errors;

            EmployeeService employeeService = new EmployeeService();

            EmployeeViewModel employee = employeeService.GetAllEmployees().FirstOrDefault(x => x.Id == id);

            ViewBag.Departments = employeeService.GetAllDepartments().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            ViewBag.Grades = employeeService.GetAllGrades().Select(g => new SelectListItem
            {
                Text = g.Name,
                Value = g.Id.ToString()
            }).ToList();

            return View(employee);
        }
    }
}