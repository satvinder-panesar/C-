using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Models.DTOs
{
    public class StudentDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<EnrollmentDto> Enrollments { get; set; }
    }
}