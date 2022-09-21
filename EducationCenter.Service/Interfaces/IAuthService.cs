using EducationCenter.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(UserForLoginDTO user);
    }
}
