using AutoMapper;
using StudentsEnrollmentsDemo.Models.DTOs;
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
        }
    }
}