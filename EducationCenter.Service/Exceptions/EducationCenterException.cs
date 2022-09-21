using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Exceptions
{
    public class EducationCenterException : Exception
    {
        public int Code { get; set; }

        public EducationCenterException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
