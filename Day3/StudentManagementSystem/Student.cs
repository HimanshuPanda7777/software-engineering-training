using System;

namespace StudentManagementSystem
{
    public class Student
    {
        int rollNo;
        int phy;
        int chem;
        int math;

        // CLR Properties
        public int RollNo
        {
            set
            {
                rollNo = value;
            }
            get
            {
                return rollNo;
            }
        }

        public int Phy
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    phy = value;
                }
                else
                {
                    Console.WriteLine("Invalid Marks");
                }
            }
            get
            {
                return phy;
            }
        }

        public int Chem
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    chem = value;
                }
                else
                {
                    Console.WriteLine("Invalid Marks");
                }
            }
            get
            {
                return chem;
            }
        }

        public int Math
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    math = value;
                }
                else
                {
                    Console.WriteLine("Invalid Marks");
                }
            }
            get
            {
                return math;
            }
        }

        // Auto-Implemented Properties
        public string Name { get; set; }
        public string Address { get; set; }

        public int Total { get; set; }
        public float Perc { get; set; }
    }
}
