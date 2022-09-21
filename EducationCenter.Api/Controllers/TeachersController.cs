using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Teachers;
using EducationCenter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EducationCenter.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeachersController : BaseController
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> AddAsync(TeacherForCreationDTO teacher) 
            => Ok(await teacherService.AddAsync(teacher));

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await teacherService.DeleteAsync(t => t.Id == id));

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await teacherService.GetAllAync(@params, t => t.State != ItemState.Deleted));

        [HttpGet("{Id}"), AllowAnonymous]
        public async Task<ActionResult<Teacher>> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await teacherService.GetAsync(t => t.Id == id));

        [HttpPut("{Id}")]
        public async Task<ActionResult<Teacher>> UpdadteAsync([FromRoute(Name = "Id")] long id, TeacherForCreationDTO teacher)
            => Ok(await teacherService.UpdateAsync(id, teacher));
    }
}