using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Models
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}