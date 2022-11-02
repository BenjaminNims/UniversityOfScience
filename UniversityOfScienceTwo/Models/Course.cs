using System;

namespace UniversityOfScienceTwo.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string? OwnerID { get; set; }

        public string? Name { get; set; }
        public string? Designation { get; set; }

        public CourseStatus Status { get; set; }

        public Course()
        {
        }
    }

    public enum CourseStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

