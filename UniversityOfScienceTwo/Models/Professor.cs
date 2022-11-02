using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityOfScienceTwo.Models
{
    public class Professor
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public Professor()
        {
        }
    }
}

