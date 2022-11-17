using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;

namespace UniversityOfScienceTwo.Models
{
    public class Course
    {
        public Course()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        
        public string? OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }

        public int? ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        public CourseStatus Status { get; set; }

    }

    public enum CourseStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

