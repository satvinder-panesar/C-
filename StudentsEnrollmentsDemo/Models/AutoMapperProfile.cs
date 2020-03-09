using AutoMapper;
using StudentsEnrollmentsDemo.Models.DTOs;
using StudentsEnrollmentsDemo.Models.RequestCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsEnrollmentsDemo.Models
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<AddStudent, Student>();
            CreateMap<UpdateStudent, Student>();
            CreateMap<AddEnrollment, Enrollment>();
        }
    }
}