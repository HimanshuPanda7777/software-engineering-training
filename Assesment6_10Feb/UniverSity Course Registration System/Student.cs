using System;
using System.Collections.Generic;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;

            if (completedCourses == null)
                CompletedCourses = new List<string>();
            else
                CompletedCourses = completedCourses;

            RegisteredCourses = new List<Course>();
        }

        // Calculate total registered credits
        public int GetTotalCredits()
        {
            int totalCredits = 0;

            foreach (Course course in RegisteredCourses)
            {
                totalCredits += course.Credits;
            }

            return totalCredits;
        }

        // Check if a course can be added
        public bool CanAddCourse(Course course)
        {
            // Check if course already registered
            foreach (Course c in RegisteredCourses)
            {
                if (c.CourseCode == course.CourseCode)
                    return false;
            }

            // Check credit limit
            if (GetTotalCredits() + course.Credits > MaxCredits)
                return false;

            // Check prerequisites
            if (!course.HasPrerequisites(CompletedCourses))
                return false;

            return true;
        }

        // Add course
        public bool AddCourse(Course course)
        {
            if (!CanAddCourse(course))
                return false;

            if (course.IsFull())
                return false;

            RegisteredCourses.Add(course);
            course.EnrollStudent();

            return true;
        }

        // Drop course
        public bool DropCourse(string courseCode)
        {
            Course courseToRemove = null;

            foreach (Course course in RegisteredCourses)
            {
                if (course.CourseCode == courseCode)
                {
                    courseToRemove = course;
                    break;
                }
            }

            if (courseToRemove == null)
                return false;

            RegisteredCourses.Remove(courseToRemove);
            courseToRemove.DropStudent();

            return true;
        }

        // Display student schedule
        public void DisplaySchedule()
        {
            if (RegisteredCourses.Count == 0)
            {
                Console.WriteLine("No courses registered.");
                return;
            }

            Console.WriteLine("Registered Courses:");
            foreach (Course course in RegisteredCourses)
            {
                Console.WriteLine(
                    course.CourseCode + " - " +
                    course.CourseName + " (" +
                    course.Credits + " credits)"
                );
            }
        }
    }
}
