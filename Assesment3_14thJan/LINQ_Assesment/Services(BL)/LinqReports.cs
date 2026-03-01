using System.Collections.Generic;
using System.Linq;
using LinqAssessment.Models;

namespace LinqAssessment.Services
{
    public static class LinqReports
    {
     
        public static List<Employee> GetSalaryReviewCandidates(List<Employee> employees)
        {
            return employees.Where(e => e.Salary > 60000).ToList();
        }

      
        public static List<string> GetEmployeeNames(List<Employee> employees)
        {
            return employees.Select(e => e.Name).ToList();
        }

      
        public static bool HasHRDepartment(List<Employee> employees)
        {
            return employees.Any(e => e.Department=="HR");
        }

     
        public static List<object> GetDepartmentHeadcount(List<Employee> employees)
        {
            return employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count()
                })
                .Cast<object>()
                .ToList();
        }

        public static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            return employees.OrderByDescending(e => e.Salary).FirstOrDefault();
        }

        
        public static List<Employee> GetSortedEmployees(List<Employee> employees)
        {
            return employees
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.Name)
                .ToList();
        }

        
        public static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            return employees
                .Where(e => !projects.Any(p => p.EmployeeId == e.Id))
                .ToList();
        }

       
        public static List<string> GetAllSkills(List<Employee> employees)
        {
            return employees
                .SelectMany(e => e.Skills)
                .Distinct()
                .ToList();
        }

      
        public static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            return employees
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToList();
        }

       
        public static List<Employee> GetPagedEmployees(
            List<Employee> employees,
            int pageNumber,
            int pageSize)
        {
            return employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
