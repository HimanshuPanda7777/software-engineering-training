using System;
using System.Collections.Generic;

namespace University_Course_Registration_System
{
    // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Course Code: ");
                            string cCode = Console.ReadLine();

                            Console.Write("Enter Course Name: ");
                            string cName = Console.ReadLine();

                            Console.Write("Enter Credits: ");
                            int credits = int.Parse(Console.ReadLine());

                            Console.Write("Enter Max Capacity: ");
                            int capacity = int.Parse(Console.ReadLine());

                            Console.Write("Enter Prerequisites (comma separated, or press Enter): ");
                            string prereqInput = Console.ReadLine();

                            List<string> prerequisites = new List<string>();
                            if (!string.IsNullOrEmpty(prereqInput))
                            {
                                string[] prereqArray = prereqInput.Split(',');
                                foreach (string p in prereqArray)
                                {
                                    prerequisites.Add(p.Trim());
                                }
                            }

                            system.AddCourse(cCode, cName, credits, capacity, prerequisites);
                            break;

                        case "2":
                            Console.Write("Enter Student ID: ");
                            string sId = Console.ReadLine();

                            Console.Write("Enter Student Name: ");
                            string sName = Console.ReadLine();

                            Console.Write("Enter Major: ");
                            string major = Console.ReadLine();

                            Console.Write("Enter Max Credits: ");
                            int maxCredits = int.Parse(Console.ReadLine());

                            Console.Write("Enter Completed Courses (comma separated, or press Enter): ");
                            string completedInput = Console.ReadLine();

                            List<string> completedCourses = new List<string>();
                            if (!string.IsNullOrEmpty(completedInput))
                            {
                                string[] completedArray = completedInput.Split(',');
                                foreach (string c in completedArray)
                                {
                                    completedCourses.Add(c.Trim());
                                }
                            }

                            system.AddStudent(sId, sName, major, maxCredits, completedCourses);
                            break;

                        case "3":
                            Console.Write("Enter Student ID: ");
                            string regStudentId = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string regCourseCode = Console.ReadLine();

                            system.RegisterStudentForCourse(regStudentId, regCourseCode);
                            break;

                        case "4":
                            Console.Write("Enter Student ID: ");
                            string dropStudentId = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string dropCourseCode = Console.ReadLine();

                            system.DropStudentFromCourse(dropStudentId, dropCourseCode);
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Enter Student ID: ");
                            string viewStudentId = Console.ReadLine();

                            system.DisplayStudentSchedule(viewStudentId);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            Console.WriteLine("Exiting system. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
