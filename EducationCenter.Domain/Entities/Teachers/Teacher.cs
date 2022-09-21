using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities.Teachers
{
    public class Teacher : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Subject Subject { get; set; }
        public ItemState State { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
