using System;
using System.Data.Entity;
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
        
        public int CourseId { get; set; }
        
        public string? OwnerId { get; set; }

        public string? Name { get; set; }
        public string? Designation { get; set; }

        public CourseStatus Status { get; set; }

    }

    public enum CourseStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

