using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.DTOs.Students
{
    public class StudentForCreationDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long TeacherId { get; set; }
    }
}
