using DIYShop.Models;
using System.Collections.Generic;

namespace DIYShop.Logic
{
    public interface IEmployeesManager
    {
        EmployeesManager AddEmployee(EmployeesModel employeesModel);
        EmployeesManager ChangeEmployeeData(int id, string newEmployee);
        EmployeesModel GetEmployee(int id);
        List<EmployeesModel> GetEmployees();
        EmployeesManager RemoveEmployee(int id);
        EmployeesManager UpdateEmployee(EmployeesModel employeesModel);
    }
}