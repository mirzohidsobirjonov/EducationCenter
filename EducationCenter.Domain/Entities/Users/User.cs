using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ItemState State { get; set; } = ItemState.Created;
        public UserRole Role { get; set; } = UserRole.User;
    }
}
