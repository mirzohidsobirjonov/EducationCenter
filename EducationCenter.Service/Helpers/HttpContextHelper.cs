using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor { get; set; }
        public static HttpContext HttpContext => Accessor?.HttpContext;
        public static long? UserId => GetUserId();
        public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

        private static long? GetUserId()
        {
            long id;
            bool canParse = long.TryParse(HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
            return canParse ? id : null;
        }
    }
}