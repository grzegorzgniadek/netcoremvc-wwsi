using DIYShop.Contexts;
using DIYShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYShop.Logic
{
    public class EmployeesManager : IEmployeesManager
    {
        private readonly EmployeesContext _employeesContext;
        public EmployeesManager(EmployeesContext employeesContext)
        {
            _employeesContext = employeesContext;
        }
        public EmployeesModel Employees { get; set; }

        public EmployeesManager AddEmployee(EmployeesModel employeesModel)
        {
            _employeesContext.Add(employeesModel);
            try
            {
                _employeesContext.SaveChanges();
            }
            catch (Exception)
            {
                if(employeesModel.ID != 0)
                {
                    employeesModel.ID = 0;
                    _employeesContext.SaveChanges();
                }
            }
            return this;
        }

        public EmployeesManager RemoveEmployee(int id)
        {
            var employee = _employeesContext.Employees.Single(x => x.ID == id);
            _employeesContext.Remove(employee);
            _employeesContext.SaveChanges();
            return this;
        }

        public EmployeesManager UpdateEmployee(EmployeesModel employeesModel)
        {
            _employeesContext.Update(employeesModel);
            _employeesContext.SaveChanges();
            return this;
        }

        public EmployeesManager ChangeEmployeeData(int id, string newEmployee)
        {
            GetEmployee(id);
            if (String.IsNullOrEmpty(newEmployee))
            {
                Employees.FirstName = "No Name";
            }
            else
            {
                Employees.FirstName = newEmployee;

            }
            UpdateEmployee(Employees);
            return this;
        }

        public EmployeesModel GetEmployee(int id)
        {
            var employee = _employeesContext.Employees.Single(x => x.ID == id);
            return employee;
        }

        public List<EmployeesModel> GetEmployees()
        {
            return _employeesContext.Employees.ToList();
        }
    }
}
