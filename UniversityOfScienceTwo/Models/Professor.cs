using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfScienceTwo.Models
{
    public class Professor
    {
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Department { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public Professor()
        {
        }
    }
}

