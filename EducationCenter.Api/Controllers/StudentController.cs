using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Students;
using EducationCenter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationCenter.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : BaseController
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddAsync(StudentForCreationDTO student)
            => Ok(await studentService.AddAsync(student));

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await studentService.DeleteAsync(s => s.Id == id));

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<Student>> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await studentService.GetAllAync(@params, s => s.State != ItemState.Deleted));

        [HttpGet("{Id}"), AllowAnonymous]
        public async Task<ActionResult<Student>> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await studentService.GetAync(s => s.Id == id));

        [HttpPatch("{Id}")]
        public async Task<ActionResult<Student>> UpdateAsync([FromRoute(Name = "Id")] long id, StudentForCreationDTO student)
            => Ok(await studentService.UpdateAsync(id, student));
    }
}