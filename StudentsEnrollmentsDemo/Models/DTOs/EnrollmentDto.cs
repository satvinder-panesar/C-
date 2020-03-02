using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Models.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }
    }
}