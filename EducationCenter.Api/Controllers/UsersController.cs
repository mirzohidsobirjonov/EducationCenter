using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Users;
using EducationCenter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EducationCenter.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<User>> AddAsync(UserForCrerationDTO dto)
            => Ok(await userService.AddAsync(dto));

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await userService.DeleteAsync(u => u.Id == id));

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await userService.GetAync(u => u.Id == id));

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetAll([FromQuery] PaginationParams @params)
            => Ok(await userService.GetAllAync(@params, u => u.State != ItemState.Deleted));

        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> UpdateAsync([FromRoute(Name = "Id")] long id, UserForCrerationDTO dto)
            => Ok(await userService.UpdateAsync(id, dto));
    }
}