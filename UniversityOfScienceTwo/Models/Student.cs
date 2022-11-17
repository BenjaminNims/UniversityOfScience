using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfScienceTwo.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string? OwnerID { get; set; }

        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public StudentStatus Status { get; set; }

        public Student()
        {
        }
    }

    public enum StudentStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

