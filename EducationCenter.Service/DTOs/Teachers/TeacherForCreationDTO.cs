using EducationCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.DTOs.Teachers
{
    public class TeacherForCreationDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Subject Subject { get; set; }
    }
}
