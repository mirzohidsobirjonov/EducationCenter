using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ItemState State { get; set; }


        public long? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}