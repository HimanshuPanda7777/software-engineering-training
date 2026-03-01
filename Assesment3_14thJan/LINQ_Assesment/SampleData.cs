using System.Collections.Generic;
using LinqAssessment.Models;

namespace LinqAssessment.Data
{
    public static class SampleData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Amit", Department = "HR", Salary = 65000, Skills = new List<string>{ "Recruitment" }},
            new Employee { Id = 2, Name = "Neha", Department = "IT", Salary = 85000, Skills = new List<string>{ "C#", "SQL" }},
            new Employee { Id = 3, Name = "Rahul", Department = "IT", Salary = 75000, Skills = new List<string>{ "React" }},
            new Employee { Id = 2, Name = "Neha", Department = "IT", Salary = 85000, Skills = new List<string>{ "C#", "SQL" }} // duplicate
        };

        public static List<Project> Projects = new List<Project>
        {
            new Project { ProjectId = 1, EmployeeId = 2, ProjectName = "Payroll System" },
            new Project { ProjectId = 2, EmployeeId = 3, ProjectName = "Web Portal" }
        };
    }
}
