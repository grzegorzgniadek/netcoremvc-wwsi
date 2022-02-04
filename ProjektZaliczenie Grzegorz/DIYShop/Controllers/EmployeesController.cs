using DIYShop.Logic;
using DIYShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeesManager _employeesManager;

        public EmployeesController(IEmployeesManager employeesManager)
        {
            _employeesManager = employeesManager;
        }
        public IActionResult Index()
        {
            var employees = _employeesManager.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeesModel employee)
        {
            _employeesManager.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var employee = _employeesManager.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            try
            {
                _employeesManager.RemoveEmployee(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeesManager.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeesModel employeeModel)
        {
            _employeesManager.UpdateEmployee(employeeModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeesManager.GetEmployee(id);
            return View(employee);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

