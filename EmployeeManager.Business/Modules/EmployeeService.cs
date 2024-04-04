using EmployeeManager.Business.ViewModels;
using EmployeeManager.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Modules
{
    public class EmployeeService
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public List<DepartmentViewModel> GetAllDepartments()
        {
            return context.Departments.Select(d => new DepartmentViewModel
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            return context.Employees.Include(nameof(Department)).Include(nameof(Grade)).Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                CreatedDate = e.CreatedDate,
                Department = new DepartmentViewModel
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name,
                },
                DepartmentId = e.Department.Id,
                Email = e.Email,
                FirstName = e.FirstName,
                Grade = new GradeViewModel
                {
                    Id = e.Grade.Id,
                    Name = e.Grade.Name,
                    Salary = e.Grade.Salary.Value
                },
                GradeId = e.Grade.Id,
                IsActive = e.IsActive,
                LastName = e.LastName,
                ModifiedDate = e.ModifiedDate,
                Phone = e.Phone
            }).ToList();
        }

        public List<GradeViewModel> GetAllGrades()
        {
            return context.Grades.Select(d => new GradeViewModel
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();
        }

        public bool CreateEmployee(EmployeeViewModel model)
        {
            Employee employee = new Employee
            {
                CreatedDate = DateTime.Now,
                DepartmentId = model.DepartmentId,
                Email = model.Email,
                FirstName = model.FirstName,
                GradeId = model.GradeId,
                IsActive = true,
                LastName = model.LastName,
                Phone = model.Phone
            };
            context.Employees.Add(employee);
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
