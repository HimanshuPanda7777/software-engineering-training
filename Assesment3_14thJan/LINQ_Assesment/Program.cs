using System;
using System.Collections.Generic;
using LinqAssessment.Models;
using LinqAssessment.Services;

namespace LinqAssessment
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            List<Project> projects = new List<Project>();

            Console.Write("Enter number of employees: ");
            int employeeCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < employeeCount; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}");

                Employee employee = new Employee();

                Console.Write("Id: ");
                employee.Id = int.Parse(Console.ReadLine()!);

                Console.Write("Name: ");
                employee.Name = Console.ReadLine()!;

                Console.Write("Department: ");
                employee.Department = Console.ReadLine()!;

                Console.Write("Salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine()!);

                Console.Write("Number of skills: ");
                int skillCount = int.Parse(Console.ReadLine()!);

                employee.Skills = new List<string>();

                for (int j = 0; j < skillCount; j++)
                {
                    Console.Write($"Enter skill {j + 1}: ");
                    employee.Skills.Add(Console.ReadLine()!);
                }

                employees.Add(employee);
            }

            Console.Write("\nEnter number of projects: ");
            int projectCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < projectCount; i++)
            {
                Console.WriteLine($"\nEnter details for Project {i + 1}");

                Project project = new Project();

                Console.Write("Project Id: ");
                project.ProjectId = int.Parse(Console.ReadLine()!);

                Console.Write("Employee Id assigned to project: ");
                project.EmployeeId = int.Parse(Console.ReadLine()!);

                Console.Write("Project Name: ");
                project.ProjectName = Console.ReadLine();

                projects.Add(project);
            }

            
            var highSalaryEmployees = LinqReports.GetSalaryReviewCandidates(employees);
            var employeeNames = LinqReports.GetEmployeeNames(employees);
            var hasHR = LinqReports.HasHRDepartment(employees);
            var unassignedEmployees = LinqReports.GetUnassignedEmployees(employees, projects);

            Console.WriteLine("\n--- REPORT OUTPUT ---");

            Console.WriteLine("\nEmployees earning more than 60000:");
            foreach (var emp in highSalaryEmployees)
            {
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine("\nAll Employee Names:");
            employeeNames.ForEach(Console.WriteLine);

            Console.WriteLine($"\nHR Department Exists: {hasHR}");

            Console.WriteLine("\nUnassigned Employees:");
            foreach (var emp in unassignedEmployees)
            {
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine("\nProgram executed successfully.");
        }
    }
}
