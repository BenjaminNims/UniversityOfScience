using System;
namespace UniversityOfScienceTwo.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string EnrolledCourses { get; set; } = String.Empty;
        public float GPA { get; set; } = 0;

        public Student()
        {
        }
    }
}

