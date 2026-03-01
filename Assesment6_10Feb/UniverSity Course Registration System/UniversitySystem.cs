using System;
using System.Collections.Generic;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // Check if course already exists
            if (AvailableCourses.ContainsKey(code))
            {
                throw new ArgumentException("Course code already exists.");
            }

            Course course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code, course);

            Console.WriteLine("Course added successfully.");
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // Check if student already exists
            if (Students.ContainsKey(id))
            {
                throw new ArgumentException("Student ID already exists.");
            }

            Student student = new Student(id, name, major, maxCredits, completedCourses);
            Students.Add(id, student);

            Console.WriteLine("Student added successfully.");
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // Validate student
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            // Validate course
            if (!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            Student student = Students[studentId];
            Course course = AvailableCourses[courseCode];

            bool success = student.AddCourse(course);

            if (success)
            {
                Console.WriteLine("Registration successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Registration failed. Check credits, prerequisites, or course capacity.");
                return false;
            }
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // Validate student
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            Student student = Students[studentId];
            bool success = student.DropCourse(courseCode);

            if (success)
            {
                Console.WriteLine("Course dropped successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Course not found in student's schedule.");
                return false;
            }
        }

        public void DisplayAllCourses()
        {
            if (AvailableCourses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            Console.WriteLine("Available Courses:");
            foreach (Course course in AvailableCourses.Values)
            {
                Console.WriteLine(
                    course.CourseCode + " - " +
                    course.CourseName + " | Credits: " +
                    course.Credits + " | Enrollment: " +
                    course.GetEnrollmentInfo()
                );
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Student student = Students[studentId];
            Console.WriteLine("Schedule for " + student.Name + ":");
            student.DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            int totalEnrollment = 0;

            foreach (Course course in AvailableCourses.Values)
            {
                string[] parts = course.GetEnrollmentInfo().Split('/');
                totalEnrollment += int.Parse(parts[0]);
            }

            double averageEnrollment = 0;
            if (totalCourses > 0)
            {
                averageEnrollment = (double)totalEnrollment / totalCourses;
            }

            Console.WriteLine("System Summary:");
            Console.WriteLine("Total Students: " + totalStudents);
            Console.WriteLine("Total Courses: " + totalCourses);
            Console.WriteLine("Average Enrollment: " + averageEnrollment);
        }
    }
}
