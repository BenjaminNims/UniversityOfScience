using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityOfScienceTwo.Models
{
    public class Professor
    {
        public Professor()
        {
        }
        public int ProfessorId { get; set; }

        public string? OwnerId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}

