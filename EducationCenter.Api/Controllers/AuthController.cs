using EducationCenter.Service.DTOs.Users;
using EducationCenter.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationCenter.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserForLoginDTO dto)
        {
            var token = await authService.GenerateToken(dto);

            return Ok(new
            {
                Token = token
            });
        }
    }
}
