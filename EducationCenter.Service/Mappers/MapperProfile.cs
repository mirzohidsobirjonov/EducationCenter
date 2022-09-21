using AutoMapper;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Service.DTOs.Students;
using EducationCenter.Service.DTOs.Teachers;
using EducationCenter.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForCrerationDTO, User>().ReverseMap();
            CreateMap<TeacherForCreationDTO, Teacher>().ReverseMap();
            CreateMap<StudentForCreationDTO, Student>().ReverseMap();
        }
    }
}
