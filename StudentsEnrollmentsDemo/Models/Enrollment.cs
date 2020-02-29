using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Models
{
    public enum Grade
    {
        A, B, C, D
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public virtual Student Student { get; set; }
    }
}