using System;
using System.Collections.Generic;

namespace University_Course_Registration_System
{
    public class Course
    {
        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public int Credits { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<string> Prerequisites { get; private set; }

        private int CurrentEnrollment;

        public Course(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            CourseCode = code;
            CourseName = name;
            Credits = credits;
            MaxCapacity = maxCapacity;

            if (prerequisites == null)
                Prerequisites = new List<string>();
            else
                Prerequisites = prerequisites;

            CurrentEnrollment = 0;
        }

        // Check if course is full
        public bool IsFull()
        {
            if (CurrentEnrollment >= MaxCapacity)
                return true;

            return false;
        }

        // Check if student has completed all prerequisites
        public bool HasPrerequisites(List<string> completedCourses)
        {
            // No prerequisites → allowed
            if (Prerequisites.Count == 0)
                return true;

            // Check each prerequisite manually
            foreach (string prereq in Prerequisites)
            {
                if (!completedCourses.Contains(prereq))
                    return false;
            }

            return true;
        }

        // Enroll student
        public void EnrollStudent()
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Cannot enroll. Course is full.");
            }

            CurrentEnrollment++;
        }

        // Drop student
        public void DropStudent()
        {
            if (CurrentEnrollment > 0)
            {
                CurrentEnrollment--;
            }
        }

        public string GetEnrollmentInfo()
        {
            return CurrentEnrollment + "/" + MaxCapacity;
        }
    }
}
